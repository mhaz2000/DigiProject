using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Infrastructure.DtoModels;
using Infrastructure.Helper;
using Services.Mapper;
using Services.Services;

namespace DigiProject.Controllers
{
    public class MobilesController : Controller
    {
        private readonly MobileService _mobileService;
        private readonly AttachmentFileService _attachmentFileService;
        private readonly PromotionService _promotionService;
        private readonly CommentService _commentService;
        public MobilesController()
        {
            _mobileService = new MobileService();
            _attachmentFileService = new AttachmentFileService();
            _promotionService = new PromotionService();
            _commentService = new CommentService();
        }

        // GET: Mobiles
        public ActionResult Index()
        {
            var mobiles = _mobileService.GetList(null, null, m => m.AttachmentFile);
            return View(mobiles);
        }

        public ActionResult Search(string option, string search)
        {
            if (option == "Name")
                return View("Index", _mobileService.GetList(w => w.Name.Contains(search), null, a => a.AttachmentFile));
            else if (option == "Brand")
                return View("Index", _mobileService.GetList(w => w.Brand.Contains(search), null, a => a.AttachmentFile));
            else
                return View("Index", _mobileService.GetList(w => w.Model.Contains(search), null, a => a.AttachmentFile));
        }

        // GET: Mobiles/Create
        public ActionResult Create()
        {
            ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
            return View();
        }

        // POST: Mobiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MobileDto mobileDto, HttpPostedFileBase file)
        {
            #region AttachmentImage
            var attachmentId = Guid.NewGuid();
            if (file != null && file.ContentLength > 0)
            {
                byte[] imageData = null;
                var fileSize = file.ContentLength;
                using (var binaryReader = new System.IO.BinaryReader(file.InputStream))
                {
                    imageData = binaryReader.ReadBytes(file.ContentLength);
                }

                var img = System.Drawing.Image.FromStream(new System.IO.MemoryStream(imageData));
                int imageWidth = img.Width;
                int imageHeight = img.Height;

                attachmentId = _attachmentFileService.AddAttachment(attachmentId,
                    System.IO.Path.GetFileName(file.FileName),
                    System.IO.Path.GetExtension(file.FileName), fileSize,
                    MimeTypeHelper.GetMimeType(System.IO.Path.GetExtension(file.FileName)),
                    imageWidth, imageHeight, "ArticleImage - " + Guid.NewGuid(), "", imageData, DateTime.Now);

                mobileDto.AttachmentImageId = attachmentId;
            }
            #endregion

            try
            {
                mobileDto.Type = Enums.CommodityType.Mobile;
                _mobileService.Insert(MapToModel.MobileDtoMapToModel(mobileDto));
                _mobileService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(mobileDto);
            }
        }

        // GET: Mobiles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mobile = _mobileService.Get(a => a.ID == id);
            if (mobile == null)
            {
                return HttpNotFound();
            }
            ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
            return View(mobile);
        }

        // POST: Mobiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MobileDto mobileDto, HttpPostedFileBase file)
        {
            IEnumerable<CommentDto> comments = _commentService.GetList(w => w.CommodityId == mobileDto.ID);
            _mobileService.DeleteById(mobileDto.ID);
            #region AttachmentImage
            var attachmentId = Guid.NewGuid();
            if (file != null && file.ContentLength > 0)
            {
                byte[] imageData = null;
                var fileSize = file.ContentLength;
                using (var binaryReader = new System.IO.BinaryReader(file.InputStream))
                {
                    imageData = binaryReader.ReadBytes(file.ContentLength);
                }

                var img = System.Drawing.Image.FromStream(new System.IO.MemoryStream(imageData));
                int imageWidth = img.Width;
                int imageHeight = img.Height;

                attachmentId = _attachmentFileService.AddAttachment(attachmentId,
                    System.IO.Path.GetFileName(file.FileName),
                    System.IO.Path.GetExtension(file.FileName), fileSize,
                    MimeTypeHelper.GetMimeType(System.IO.Path.GetExtension(file.FileName)),
                    imageWidth, imageHeight, "ArticleImage - " + Guid.NewGuid(), "", imageData, DateTime.Now);

                mobileDto.AttachmentImageId = attachmentId;
            }
            #endregion
            try
            {
                mobileDto.Type = Enums.CommodityType.Mobile;
               var id = _mobileService.Update(MapToModel.MobileDtoMapToModel(mobileDto));
                foreach (var item in comments)
                {
                    item.CommodityId = id;
                    _commentService.Update(MapToModel.CommentDtoMapToModel(item));
                    _commentService.Save();
                }
                _mobileService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(mobileDto);
            }
        }

        // GET: Mobiles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mobile = _mobileService.Get(a => a.ID == id);
            if (mobile == null)
            {
                return HttpNotFound();
            }
            return View(mobile);
        }

        // POST: Mobiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _mobileService.DeleteById(id);
            _mobileService.Save();
            return RedirectToAction("Index");
        }

        public ActionResult MobileDetail(Guid Id)
        {
            MobileDetails details = new MobileDetails();
            details.MobileDto = _mobileService.Get(w => w.ID == Id);
            details.CommentDtos = _commentService.GetList(w => w.CommodityId == details.MobileDto.ID).OrderByDescending(o => o.SubmissionDate);
            return View(details);
        }
    }
    public class MobileDetails
    {
        public MobileDto MobileDto { get; set; }
        public IEnumerable<CommentDto> CommentDtos { get; set; }
        public CommentDto NewComment { get; set; }
    }
}

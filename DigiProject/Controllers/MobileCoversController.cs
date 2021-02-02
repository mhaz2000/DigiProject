using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Models;
using Infrastructure.DtoModels;
using Infrastructure.Helper;
using Services.Mapper;
using Services.Services;

namespace DigiProject.Controllers
{
    public class MobileCoversController : Controller
    {
        private readonly MobileCoverService _mobileCoverService;
        private readonly AttachmentFileService _attachmentFileService;
        private readonly PromotionService _promotionService;
        private readonly CommentService _commentService;

        public MobileCoversController()
        {
            _mobileCoverService = new MobileCoverService();
            _attachmentFileService = new AttachmentFileService();
            _promotionService = new PromotionService();
            _commentService = new CommentService();
        }
        // GET: MobileCovers
        public ActionResult Index()
        {
            var mobileCovers = _mobileCoverService.GetList(null, null, a => a.AttachmentFile);
            return View(mobileCovers);
        }


        // GET: MobileCovers/Create
        public ActionResult Create()
        {
            ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
            return View();
        }

        public ActionResult Search(string option, string search)
        {
            if (option == "Name")
                return View("Index", _mobileCoverService.GetList(w => w.Name.Contains(search), null, a => a.AttachmentFile));
            else if (option == "Brand")
                return View("Index", _mobileCoverService.GetList(w => w.Brand.Contains(search), null, a => a.AttachmentFile));
            else
                return View("Index", _mobileCoverService.GetList(w => w.Model.Contains(search), null, a => a.AttachmentFile));
        }

        // POST: MobileCovers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MobileCoverDto mobileCoverDto, HttpPostedFileBase file)
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

                mobileCoverDto.AttachmentImageId = attachmentId;
            }
            #endregion
            try
            {
                mobileCoverDto.Type = Enums.CommodityType.MobileCover;
                _mobileCoverService.Insert(MapToModel.MobileCoverDtoMapToModel(mobileCoverDto));
                _mobileCoverService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(mobileCoverDto);
            }

        }

        // GET: MobileCovers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mobileCover = _mobileCoverService.Get(a => a.ID == id);
            if (mobileCover == null)
            {
                return HttpNotFound();
            }
            ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
            return View(mobileCover);
        }

        // POST: MobileCovers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MobileCoverDto mobileCoverDto, HttpPostedFileBase file)
        {
            IEnumerable<CommentDto> comments = _commentService.GetList(w => w.CommodityId == mobileCoverDto.ID);
            _mobileCoverService.DeleteById(mobileCoverDto.ID);
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

                mobileCoverDto.AttachmentImageId = attachmentId;
            }
            #endregion
            try
            {
                mobileCoverDto.Type = Enums.CommodityType.MobileCover;
                var id = _mobileCoverService.Update(MapToModel.MobileCoverDtoMapToModel(mobileCoverDto));
                foreach (var item in comments)
                {
                    item.CommodityId = id;
                    _commentService.Update(MapToModel.CommentDtoMapToModel(item));
                    _commentService.Save();
                }
                _mobileCoverService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(mobileCoverDto);
            }
        }

        // GET: MobileCovers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mobileCover = _mobileCoverService.Get(a => a.ID == id);
            if (mobileCover == null)
            {
                return HttpNotFound();
            }
            return View(mobileCover);
        }

        // POST: MobileCovers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _mobileCoverService.DeleteById(id);
            _mobileCoverService.Save();
            return RedirectToAction("Index");
        }

        public ActionResult MobileCoverDetail(Guid Id)
        {
            MobileCoverDetails details = new MobileCoverDetails();
            details.MobileCoverDto = _mobileCoverService.Get(w => w.ID == Id);
            details.CommentDtos = _commentService.GetList(w => w.CommodityId == details.MobileCoverDto.ID).OrderByDescending(o => o.SubmissionDate);
            return View(details);
        }
    }
    public class MobileCoverDetails
    {
        public MobileCoverDto MobileCoverDto { get; set; }
        public IEnumerable<CommentDto> CommentDtos { get; set; }
        public CommentDto NewComment { get; set; }
    }
}


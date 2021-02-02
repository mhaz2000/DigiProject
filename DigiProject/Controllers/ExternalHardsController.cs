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
    public class ExternalHardsController : Controller
    {
        private readonly ExternalHardService _externalHardService;
        private readonly AttachmentFileService _attachmentFileService;
        private readonly PromotionService _promotionService;
        private readonly CommentService _commentService;

        public ExternalHardsController()
        {
            _attachmentFileService = new AttachmentFileService();
            _externalHardService = new ExternalHardService();
            _promotionService = new PromotionService();
            _commentService = new CommentService();
        }
        // GET: ExternalHards
        public ActionResult Index()
        {
            var externalHards = _externalHardService.GetList(null, null, a => a.AttachmentFile);
            return View(externalHards);
        }

        public ActionResult Search(string option, string search)
        {
            if (option == "Name")
                return View("Index", _externalHardService.GetList(w => w.Name.Contains(search), null, a => a.AttachmentFile));
            else if (option == "Model")
                return View("Index", _externalHardService.GetList(w => w.Model.Contains(search), null, a => a.AttachmentFile));
            else
                return View("Index", _externalHardService.GetList(w => w.Brand.Contains(search), null, a => a.AttachmentFile));
        }

        // GET: ExternalHards/Create
        public ActionResult Create()
        {
            ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
            return View();
        }

        // POST: ExternalHards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExternalHardDto externalHardDto, HttpPostedFileBase file)
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

                externalHardDto.AttachmentImageId = attachmentId;
            }
            #endregion

            try
            {
                externalHardDto.Type = Enums.CommodityType.ExternalHard;

                _externalHardService.Insert(MapToModel.ExternalHardDtoMapToModel(externalHardDto));
                _externalHardService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(externalHardDto);
            }
        }

        // GET: ExternalHards/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var externalHard = _externalHardService.Get(a => a.ID == id);
            if (externalHard == null)
            {
                return HttpNotFound();

            }
            ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
            return View(externalHard);
        }

        // POST: ExternalHards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExternalHardDto externalHardDto, HttpPostedFileBase file)
        {
            IEnumerable<CommentDto> comments = _commentService.GetList(w => w.CommodityId == externalHardDto.ID);
            _externalHardService.DeleteById(externalHardDto.ID);
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

                externalHardDto.AttachmentImageId = attachmentId;
            }
            #endregion

            try
            {
                externalHardDto.Type = Enums.CommodityType.ExternalHard;
                var id = _externalHardService.Update(MapToModel.ExternalHardDtoMapToModel(externalHardDto));

                foreach (var item in comments)
                {
                    item.CommodityId = id;
                    _commentService.Update(MapToModel.CommentDtoMapToModel(item));
                    _commentService.Save();
                }

                _externalHardService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(externalHardDto);
            }
        }

        // GET: ExternalHards/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var externalHard = _externalHardService.Get(a => a.ID == id);
            if (externalHard == null)
            {
                return HttpNotFound();
            }
            return View(externalHard);
        }

        // POST: ExternalHards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var externalHard = _externalHardService.Get(a => a.ID == id);
            _externalHardService.DeleteById(externalHard.ID);
            _externalHardService.Save();
            return RedirectToAction("Index");
        }

        public ActionResult ExternalHardDetail(Guid Id)
        {
            ExternalHardDetails details = new ExternalHardDetails();
            details.ExternalHardDto = _externalHardService.Get(w => w.ID == Id);
            details.CommentDtos = _commentService.GetList(w => w.CommodityId == details.ExternalHardDto.ID).OrderByDescending(o => o.SubmissionDate);
            return View(details);
        }
    }
    public class ExternalHardDetails
    {
        public ExternalHardDto ExternalHardDto { get; set; }
        public IEnumerable<CommentDto> CommentDtos { get; set; }
        public CommentDto NewComment { get; set; }
    }
}

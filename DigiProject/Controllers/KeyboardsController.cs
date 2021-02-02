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
    public class KeyboardsController : Controller
    {
        private readonly KeyboardService _keyboardService;
        private readonly AttachmentFileService _attachmentFileService;
        private readonly PromotionService _promotionService;
        private readonly CommentService _commentService;

        public KeyboardsController()
        {
            _keyboardService = new KeyboardService();
            _attachmentFileService = new AttachmentFileService();
            _promotionService = new PromotionService();
            _commentService = new CommentService();
        }
        // GET: Keyboards
        public ActionResult Index()
        {
            var keyboards = _keyboardService.GetList(null, null, a => a.AttachmentFile);
            return View(keyboards);
        }

        public ActionResult Search(string option, string search)
        {
            if (option == "Name")
                return View("Index", _keyboardService.GetList(w => w.Name.Contains(search), null, a => a.AttachmentFile));
            else if (option == "Brand")
                return View("Index", _keyboardService.GetList(w => w.Brand.Contains(search), null, a => a.AttachmentFile));
            else 
                return View("Index", _keyboardService.GetList(w => w.Model.Contains(search), null, a => a.AttachmentFile));
        }

        // GET: Keyboards/Create
        public ActionResult Create()
        {
            ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
            return View();
        }

        // POST: Keyboards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KeyboardDto keyboardDto, HttpPostedFileBase file)
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

                keyboardDto.AttachmentImageId = attachmentId;
            }
            #endregion
            try
            {
                keyboardDto.Type = Enums.CommodityType.Keyboard;
                _keyboardService.Insert(MapToModel.KeyboardDtoMapToModel(keyboardDto));
                _keyboardService.Save();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return View(keyboardDto);
            }


        }

        // GET: Keyboards/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var keyboard = _keyboardService.Get(a => a.ID == id);
            if (keyboard == null)
            {
                return HttpNotFound();
            }
            ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
            return View(keyboard);
        }

        // POST: Keyboards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KeyboardDto keyboardDto, HttpPostedFileBase file)
        {
            IEnumerable<CommentDto> comments = _commentService.GetList(w => w.CommodityId == keyboardDto.ID);
            _keyboardService.DeleteById(keyboardDto.ID);
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

                keyboardDto.AttachmentImageId = attachmentId;
            }
            #endregion
            try
            {
                keyboardDto.Type = Enums.CommodityType.Keyboard;
                var id =_keyboardService.Update(MapToModel.KeyboardDtoMapToModel(keyboardDto));
                foreach (var item in comments)
                {
                    item.CommodityId = id;
                    _commentService.Update(MapToModel.CommentDtoMapToModel(item));
                    _commentService.Save();
                }
                _keyboardService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(keyboardDto);
            }

        }

        // GET: Keyboards/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var keyboard = _keyboardService.Get(a => a.ID == id);
            if (keyboard == null)
            {
                return HttpNotFound();
            }
            return View(keyboard);
        }

        // POST: Keyboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var keyboard = _keyboardService.Get(a => a.ID == id);
            _keyboardService.DeleteById(keyboard.ID);
            _keyboardService.Save();
            return RedirectToAction("Index");
        }

        public ActionResult KeyboardDetail(Guid Id)
        {
            KeyboardDetails details = new KeyboardDetails();
            details.KeyboardDto = _keyboardService.Get(w => w.ID == Id);
            details.CommentDtos = _commentService.GetList(w => w.CommodityId == details.KeyboardDto.ID).OrderByDescending(o => o.SubmissionDate);
            return View(details);
        }
    }
    public class KeyboardDetails
    {
        public KeyboardDto KeyboardDto { get; set; }
        public IEnumerable<CommentDto> CommentDtos { get; set; }
        public CommentDto NewComment { get; set; }
    }
}

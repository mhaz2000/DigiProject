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
    public class MobileHoldersController : Controller
    {
        private readonly MobileHolderService _mobileHolderService;
        private readonly AttachmentFileService _attachmentFileService;
        private readonly PromotionService _promotionService;
        private readonly CommentService _commentService;
        public MobileHoldersController()
        {
            _mobileHolderService = new MobileHolderService();
            _attachmentFileService = new AttachmentFileService();
            _promotionService = new PromotionService();
            _commentService = new CommentService();
        }

        // GET: MobileHolders
        public ActionResult Index()
        {
            var mobileHolders = _mobileHolderService.GetList();
            return View(mobileHolders);

        }

        public ActionResult Search(string option, string search)
        {
            if (option == "Name")
                return View("Index", _mobileHolderService.GetList(w => w.Name.Contains(search), null, a => a.AttachmentFile));
            else if (option == "Brand")
                return View("Index", _mobileHolderService.GetList(w => w.Brand.Contains(search), null, a => a.AttachmentFile));
            else 
                return View("Index", _mobileHolderService.GetList(w => w.Model.Contains(search), null, a => a.AttachmentFile));

        }

        // GET: MobileHolders/Create
        public ActionResult Create()
        {
            ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
            return View();
        }

        // POST: MobileHolders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MobileHolderDto mobileHolderDto, HttpPostedFileBase file)
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

                mobileHolderDto.AttachmentImageId = attachmentId;
            }
            #endregion
            try
            {
                mobileHolderDto.Type = Enums.CommodityType.MobileHolder;
                _mobileHolderService.Insert(MapToModel.MobileHolderDtoMapToModel(mobileHolderDto));
                _mobileHolderService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(mobileHolderDto);
            }
        }

        // GET: MobileHolders/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mobileHolder = _mobileHolderService.Get(a => a.ID == id);
            if (mobileHolder == null)
            {
                return HttpNotFound();
            }
            ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
            return View(mobileHolder);
        }

        // POST: MobileHolders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MobileHolderDto mobileHolderDto,HttpPostedFileBase file)
        {
            IEnumerable<CommentDto> comments = _commentService.GetList(w => w.CommodityId == mobileHolderDto.ID);
            _mobileHolderService.DeleteById(mobileHolderDto.ID);
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

                mobileHolderDto.AttachmentImageId = attachmentId;
            }
            #endregion
            try
            {
                mobileHolderDto.Type = Enums.CommodityType.MobileHolder;
                var id = _mobileHolderService.Update(MapToModel.MobileHolderDtoMapToModel(mobileHolderDto));
                foreach (var item in comments)
                {
                    item.CommodityId = id;
                    _commentService.Update(MapToModel.CommentDtoMapToModel(item));
                    _commentService.Save();
                }
                _mobileHolderService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(mobileHolderDto);
            }
        }

        // GET: MobileHolders/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mobileHolder = _mobileHolderService.Get(a => a.ID == id);
            if (mobileHolder == null)
            {
                return HttpNotFound();
            }
            return View(mobileHolder);
        }

        // POST: MobileHolders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _mobileHolderService.DeleteById(id);
            _mobileHolderService.Save();
            return RedirectToAction("Index");
        }

        public ActionResult MobileHolderDetail(Guid Id)
        {
            MobileHolderDetails details = new MobileHolderDetails();
            details.MobileHolderDto = _mobileHolderService.Get(w => w.ID == Id);
            details.CommentDtos = _commentService.GetList(w => w.CommodityId == details.MobileHolderDto.ID).OrderByDescending(o => o.SubmissionDate);
            return View(details);
        }
    }
    public class MobileHolderDetails
    {
        public MobileHolderDto MobileHolderDto { get; set; }
        public IEnumerable<CommentDto> CommentDtos { get; set; }
        public CommentDto NewComment { get; set; }
    }
}

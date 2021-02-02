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
    public class PowerBanksController : Controller
    {
        private readonly PowerBankService _powerBankService;
        private readonly AttachmentFileService _attachmentFileService;
        private readonly PromotionService _promotionService;
        private readonly CommentService _commentService;
        public PowerBanksController()
        {
            _powerBankService = new PowerBankService();
            _attachmentFileService = new AttachmentFileService();
            _promotionService = new PromotionService();
            _commentService = new CommentService();
        }

        // GET: PowerBanks
        public ActionResult Index()
        {
            var powerBanks = _powerBankService.GetList(null, null, p => p.AttachmentFile);
            return View(powerBanks);
        }

        public ActionResult Search(string option, string search)
        {
            if (option == "Name")
                return View("Index", _powerBankService.GetList(w => w.Name.Contains(search), null, a => a.AttachmentFile));
            else if (option == "Brand")
                return View("Index", _powerBankService.GetList(w => w.Brand.Contains(search), null, a => a.AttachmentFile));
            else
                return View("Index", _powerBankService.GetList(w => w.Model.Contains(search), null, a => a.AttachmentFile));
        }

        // GET: PowerBanks/Create
        public ActionResult Create()
        {
            ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
            return View();
        }

        // POST: PowerBanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PowerBankDto powerBankDto, HttpPostedFileBase file)
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

                powerBankDto.AttachmentImageId = attachmentId;
            }
            #endregion
            try
            {
                powerBankDto.Type = Enums.CommodityType.PowerBank;
                _powerBankService.Insert(MapToModel.PowerBankDtoMapToModel(powerBankDto));
                _powerBankService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(powerBankDto);
            }
        }

        // GET: PowerBanks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var powerBank = _powerBankService.Get(a => a.ID == id);
            if (powerBank == null)
            {
                return HttpNotFound();
            }
            ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
            return View(powerBank);
        }

        // POST: PowerBanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PowerBankDto powerBankDto,HttpPostedFile file)
        {
            IEnumerable<CommentDto> comments = _commentService.GetList(w => w.CommodityId == powerBankDto.ID);
            _powerBankService.DeleteById(powerBankDto.ID);
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

                powerBankDto.AttachmentImageId = attachmentId;
            }
            #endregion
            try
            {
                powerBankDto.Type = Enums.CommodityType.PowerBank;
                var id = _powerBankService.Update(MapToModel.PowerBankDtoMapToModel(powerBankDto));
                foreach (var item in comments)
                {
                    item.CommodityId = id;
                    _commentService.Update(MapToModel.CommentDtoMapToModel(item));
                    _commentService.Save();
                }
                _powerBankService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(powerBankDto);
            }

        }

        // GET: PowerBanks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var powerBank = _powerBankService.Get(a => a.ID == id);
            if (powerBank == null)
            {
                return HttpNotFound();
            }
            return View(powerBank);
        }

        // POST: PowerBanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _powerBankService.DeleteById(id);
            _powerBankService.Save();
            return RedirectToAction("Index");
        }
        public ActionResult PowerBankDetail(Guid Id)
        {
            PowerBankDetails details = new PowerBankDetails();
            details.PowerBankDto = _powerBankService.Get(w => w.ID == Id);
            details.CommentDtos = _commentService.GetList(w => w.CommodityId == details.PowerBankDto.ID).OrderByDescending(o => o.SubmissionDate);
            return View(details);
        }
    }
    public class PowerBankDetails
    {
        public PowerBankDto PowerBankDto { get; set; }
        public IEnumerable<CommentDto> CommentDtos { get; set; }
        public CommentDto NewComment { get; set; }
    }
}

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
    public class LaptopsController : Controller
    {
        private readonly LaptopService _laptopService;
        private readonly AttachmentFileService _attachmentFileService;
        private readonly PromotionService _promotionService;
        private readonly CommentService _commentService;
        public LaptopsController()
        {
            _laptopService = new LaptopService();
            _attachmentFileService = new AttachmentFileService();
            _promotionService = new PromotionService();
            _commentService = new CommentService();
        }

        // GET: Laptops
        public ActionResult Index()
        {
            var laptops = _laptopService.GetList(null, null, a => a.AttachmentFile);
            return View(laptops);
        }

        public ActionResult Search(string option, string search)
        {
            if (option == "Name")
                return View("Index", _laptopService.GetList(w => w.Name.Contains(search), null, a => a.AttachmentFile));
            else if (option == "Brand")
                return View("Index", _laptopService.GetList(w => w.Brand.Contains(search), null, a => a.AttachmentFile));
            else if (option == "GPU_Company")
                return View("Index", _laptopService.GetList(w => w.GPU_Company.Contains(search), null, a => a.AttachmentFile));
            else
                return View("Index", _laptopService.GetList(w => w.CPU.Contains(search), null, a => a.AttachmentFile));
        }

        // GET: Laptops/Create
        public ActionResult Create()
        {
            ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LaptopDto laptopDto, HttpPostedFileBase file)
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

                laptopDto.AttachmentImageId = attachmentId;
            }
            #endregion
            try
            {
                laptopDto.Type = Enums.CommodityType.Laptop;
                _laptopService.Insert(MapToModel.LaptopDtoMapToModel(laptopDto));
                _laptopService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(laptopDto);
            }
        }

        // GET: Laptops/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var laptop = _laptopService.Get(a => a.ID == id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
            return View(laptop);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LaptopDto laptopDto, HttpPostedFileBase file)
        {
            IEnumerable<CommentDto> comments = _commentService.GetList(w => w.CommodityId == laptopDto.ID);
            _laptopService.DeleteById(laptopDto.ID);
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

                laptopDto.AttachmentImageId = attachmentId;
            }
            #endregion
            try
            {
                laptopDto.Type = Enums.CommodityType.Laptop;
                var id =_laptopService.Update(MapToModel.LaptopDtoMapToModel(laptopDto));
                foreach (var item in comments)
                {
                    item.CommodityId = id;
                    _commentService.Update(MapToModel.CommentDtoMapToModel(item));
                    _commentService.Save();
                }
                _laptopService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(laptopDto);
            }
        }

        // GET: Laptops/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var laptop = _laptopService.Get(a => a.ID == id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _laptopService.DeleteById(id);
            _laptopService.Save();
            return RedirectToAction("Index");
        }
        public ActionResult LaptopDetail(Guid Id)
        {
            LaptopDetails details = new LaptopDetails();
            details.LaptopDto = _laptopService.Get(w => w.ID == Id);
            details.CommentDtos = _commentService.GetList(w => w.CommodityId == details.LaptopDto.ID).OrderByDescending(o => o.SubmissionDate);
            return View(details);
        }
    }
    public class LaptopDetails
    {
        public LaptopDto LaptopDto { get; set; }
        public IEnumerable<CommentDto> CommentDtos { get; set; }
        public CommentDto NewComment { get; set; }
    }
}


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
    public class AssembledCasesController : Controller
    {
        private readonly AssembledCaseService _assembledCaseService;
        private readonly AttachmentFileService _attachmentFileService;
        private readonly PromotionService _promotionService;
        private readonly CommentService _commentService;
        public AssembledCasesController()
        {
            _assembledCaseService = new AssembledCaseService();
            _attachmentFileService = new AttachmentFileService();
            _promotionService = new PromotionService();
            _commentService = new CommentService();
        }

        // GET: AssembledCases
        public ActionResult Index()
        {
            var assembledCases = _assembledCaseService.GetList(null, null, a => a.AttachmentFile);
            return View(assembledCases);
        }
        public ActionResult Search(string option, string search)
        {
            if (option == "Name")
                return View("Index", _assembledCaseService.GetList(w => w.Name.Contains(search), null, a => a.AttachmentFile));
            else if (option == "Brand")
                return View("Index", _assembledCaseService.GetList(w => w.Brand.Contains(search), null, a => a.AttachmentFile));
            else if (option == "Model")
                return View("Index", _assembledCaseService.GetList(w => w.Model.Contains(search), null, a => a.AttachmentFile));
            else
                return View("Index", _assembledCaseService.GetList(w => w.CPU_Company.Contains(search), null, a => a.AttachmentFile));
        }
        // GET: AssembledCases/Create
        public ActionResult Create()
        {
            ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
            return View();
        }

        // POST: AssembledCases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssembledCaseDto assembledCaseDto, HttpPostedFileBase file)
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

                assembledCaseDto.AttachmentImageId = attachmentId;
            }
            #endregion

            try
            {
                assembledCaseDto.Type = Enums.CommodityType.AssembledCase;

                _assembledCaseService.Insert(MapToModel.AssembledCaseDtoMapToModel(assembledCaseDto));
                _assembledCaseService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
                return View(assembledCaseDto);
            }
        }

        // GET: AssembledCases/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var assembledCase = _assembledCaseService.Get(a => a.ID == id);
            if (assembledCase == null)
            {
                return HttpNotFound();
            }
            ViewBag.PromotionList = _promotionService.GetList(w => w.Status == Enums.PromotionStatus.Active);
            return View(assembledCase);
        }

        // POST: AssembledCases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AssembledCaseDto assembledCaseDto, HttpPostedFileBase file)
        {
            IEnumerable<CommentDto> comments = _commentService.GetList(w => w.CommodityId == assembledCaseDto.ID);
            _assembledCaseService.DeleteById(assembledCaseDto.ID);
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

                assembledCaseDto.AttachmentImageId = attachmentId;
            }
            #endregion

            try
            {
                assembledCaseDto.Type = Enums.CommodityType.AssembledCase;
                var id = _assembledCaseService.Update(MapToModel.AssembledCaseDtoMapToModel(assembledCaseDto));
                foreach (var item in comments)
                {
                    item.CommodityId = id;
                    _commentService.Update(MapToModel.CommentDtoMapToModel(item));
                    _commentService.Save();
                }
                _assembledCaseService.Save();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(assembledCaseDto);
            }
        }

        // GET: AssembledCases/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var assembledCase = _assembledCaseService.Get(a => a.ID == id);
            if (assembledCase == null)
            {
                return HttpNotFound();
            }
            return View(assembledCase);
        }

        // POST: AssembledCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var assembledCase = _assembledCaseService.Get(a => a.ID == id);
            _assembledCaseService.DeleteById(assembledCase.ID);
            _assembledCaseService.Save();
            return RedirectToAction("Index");
        }

        public ActionResult AssembledCaseDetail(Guid Id)
        {
            AssembledCaseDetails details = new AssembledCaseDetails();
            details.AssembledCaseDto = _assembledCaseService.Get(w => w.ID == Id);
            details.CommentDtos = _commentService.GetList(w => w.CommodityId == details.AssembledCaseDto.ID).OrderByDescending(o=>o.SubmissionDate);
            return View(details);
        }
    }

    public class AssembledCaseDetails
    {
        public AssembledCaseDto AssembledCaseDto { get; set; }
        public IEnumerable<CommentDto> CommentDtos { get; set; }
        public CommentDto NewComment { get; set; }
    }
}

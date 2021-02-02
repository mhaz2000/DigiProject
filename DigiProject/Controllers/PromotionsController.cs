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
using Services.Mapper;
using Services.Services;

namespace DigiProject.Controllers
{
    public class PromotionsController : Controller
    {
        private PromotionService _promotionService;
        public PromotionsController()
        {
            _promotionService = new PromotionService();
        }

        // GET: Promotions
        public ActionResult Index()
        {
            return View(_promotionService.GetList().OrderBy(o => o.CreatedTime));
        }

        // GET: Promotions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Promotions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PromotionDto promotionDto)
        {
            if (ModelState.IsValid)
            {
                _promotionService.Insert(MapToModel.PromotionDtoMapToModel(promotionDto));
                _promotionService.Save();
                return RedirectToAction("Index");
            }

            return View(promotionDto);
        }

        // GET: Promotions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var promotion = _promotionService.Get(w => w.ID == id);
            if (promotion == null)
            {
                return HttpNotFound();
            }
            return View(promotion);
        }

        // POST: Promotions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PromotionDto promotionDto)
        {
            if (ModelState.IsValid)
            {
                _promotionService.Update(MapToModel.PromotionDtoMapToModel(promotionDto));
                _promotionService.Save();
                return RedirectToAction("Index");
            }
            return View(promotionDto);
        }

        // GET: Promotions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var promotion = _promotionService.Get(w => w.ID == id);
            if (promotion == null)
            {
                return HttpNotFound();
            }
            return View(promotion);
        }

        // POST: Promotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var promotion = _promotionService.Get(w => w.ID == id);
            _promotionService.DeleteById(promotion.ID);
            _promotionService.Save();
            return RedirectToAction("Index");
        }
    }
}

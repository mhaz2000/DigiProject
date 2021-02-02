using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigiProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly CommodityService _commodityService;
        private readonly AttachmentFileService _attachmentFileService;
        public HomeController()
        {
            _commodityService = new CommodityService();
            _attachmentFileService = new AttachmentFileService();
        }
        public ActionResult Index()
        {
            var result = _commodityService.GetList().OrderByDescending(o => o.CreatedTime);
            foreach (var item in result)
            {
                item.AttachmentImageSource = _attachmentFileService.GetAttachmentSourceValue(item.AttachmentImageId);
            }
            return View(result);
        }

        public ActionResult Search(string search)
        {
            return View("Index", _commodityService.GetList(w => w.Name.Contains(search), null, a => a.AttachmentFile));
        }

        public ActionResult CommodityDetail(Guid Id)
        {
            var commodity = _commodityService.Get(w => w.ID == Id);
            return View(commodity);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
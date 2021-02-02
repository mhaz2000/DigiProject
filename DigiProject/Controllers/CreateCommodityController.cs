using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigiProject.Controllers
{
    public class CreateCommodityController : Controller
    {
        private readonly AssembledCaseService _assembledCaseService;
        private readonly KeyboardService _keyboardService;
        private readonly ExternalHardService _externalHardService;
        private readonly LaptopService _laptopService;
        private readonly MobileService _mobileService;
        private readonly MobileCoverService _mobileCoverService;
        private readonly MobileHolderService _mobileHolderService;
        private readonly MonitorService _monitorService;
        private readonly PowerBankService _powerBankService;
        public CreateCommodityController()
        {
            _assembledCaseService = new AssembledCaseService();
            _keyboardService = new KeyboardService();
            _externalHardService = new ExternalHardService();
            _laptopService = new LaptopService();
            _mobileCoverService = new MobileCoverService();
            _mobileHolderService = new MobileHolderService();
            _mobileService = new MobileService();
            _monitorService = new MonitorService();
            _powerBankService = new PowerBankService();
        }
        // GET: CreateCommodity
        public ActionResult Create()
        {
            CommodityNumber commodityNumber = new CommodityNumber()
            {
                AssembledCaseNumber = _assembledCaseService.GetList().Count,
                ExternalHardNumber = _externalHardService.GetList().Count,
                KeyboardNumber = _keyboardService.GetList().Count,
                LaptopNumber = _laptopService.GetList().Count,
                MobileCoverNumber = _mobileCoverService.GetList().Count,
                MobileHolderNumber = _mobileHolderService.GetList().Count,
                MobileNumber = _mobileService.GetList().Count,
                MonitorNumber = _monitorService.GetList().Count,
                PowerBasnkNumber = _powerBankService.GetList().Count
            };
            return View(commodityNumber);
        }
    }

    public class CommodityNumber
    {
        public int AssembledCaseNumber { get; set; }
        public int ExternalHardNumber { get; set; }
        public int KeyboardNumber { get; set; }
        public int LaptopNumber { get; set; }
        public int MobileNumber { get; set; }
        public int MobileCoverNumber { get; set; }
        public int MobileHolderNumber { get; set; }
        public int MonitorNumber { get; set; }
        public int PowerBasnkNumber { get; set; }
    }
}
using Infrastructure.DtoModels;
using Services.Mapper;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigiProject.Controllers
{
    public class CommentsController : Controller
    {
        private readonly CommentService _commentService;
        public CommentsController()
        {
            _commentService = new CommentService();
        }
        // : Comments
        [HttpPost]
        public ActionResult Create(string name, string description, Guid? Id, string action, string controller)
        {
            _commentService.Insert(new Domain.Models.Comment() { Name = name, Content = description, CommodityId = Id });
            _commentService.Save();
            return RedirectToAction(action, controller, new { Id = Id });
        }
    }
}
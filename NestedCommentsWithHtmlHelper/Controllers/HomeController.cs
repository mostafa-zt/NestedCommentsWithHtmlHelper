using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using NestedCommentsWithExtensionHtmlHelper.ViewModel;
using NestedCommentsWithExtensionHtmlHelper.Model;

namespace NestedCommentsWithExtensionHtmlHelper.Controllers
{
    public class HomeController : Controller
    {
        DAL.AppDbContext dbContext = new DAL.AppDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadComment()
        {
            var comments = dbContext.Comments.Include(x => x.Question).Include(x => x.Responses)
                                     .Where(w => !w.QuestionId.HasValue).AsEnumerable();
            return PartialView("_CommentList", comments);
        }

        [HttpPost]
        public ActionResult Create(CommentViewModel viewModel)
        {
            var model = new Comment()
            {
                Alias = viewModel.Alias,
                CreatorDateTime = DateTime.Now,
                Email = viewModel.Email,
                QuestionId = viewModel.Id,
                Text = viewModel.Text
            };
            dbContext.Comments.Add(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
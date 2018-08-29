using Microsoft.AspNetCore.Mvc;
using Project.Models.BindingModels;
using Project.Services.Interfaces;

namespace Project.Web.Areas.Admin.Controllers
{
    public class ArticlesController : AdminController
    {
        private readonly IArticleService articles;

        public ArticlesController(IArticleService articles)
        {
            this.articles = articles;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var success = this.articles.Delete(id);

            if (!success)
            {
                return this.RedirectToAction("All", "Articles", new { area = "" });
            }

            return this.RedirectToAction("All", "Articles", new { area = "" });
        }

        public IActionResult Edit(int id)
        {
            var model = this.articles.GetEditModel(id);

            if (model == null)
            {
                return this.RedirectToAction("All", "Articles", new { area = "" });
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditArticleBindingModel model)
        {
            this.articles.Edit(model.Id, model.Title, model.Content, model.Category, model.ImageUrl);

            return this.RedirectToAction("All", "Articles", new { area = "" });
        }
    }
}
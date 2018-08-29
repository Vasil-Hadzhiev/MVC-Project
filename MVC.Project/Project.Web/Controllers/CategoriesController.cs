namespace Project.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Project.Services.Interfaces;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categories;

        public CategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        public IActionResult All()
        {
            var categories = this.categories.GetCategories();
            return this.View(categories);
        }

        public IActionResult CategoryArticles(int id)
        {
            var articles = this.categories.GetCategoryArticles(id);
            return this.View(articles);
        }
    }
}
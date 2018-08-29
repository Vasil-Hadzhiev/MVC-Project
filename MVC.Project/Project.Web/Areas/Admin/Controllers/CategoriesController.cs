namespace Project.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Project.Services.Interfaces;

    public class CategoriesController : AdminController
    {
        private readonly ICategoryService categories;

        public CategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var success = this.categories.Delete(id);

            if (!success)
            {
                return this.RedirectToAction("All", "Categories", new { area = "" });
            }

            return this.RedirectToAction("All", "Categories", new { area = "" });
        }
    }
}
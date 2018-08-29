namespace Project.Web.Areas.Admin.Pages.Categories
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Project.Data;
    using Project.Models.BindingModels;
    using Project.Services.Interfaces;

    public class CreateModel : PageModel
    {
        private readonly ICategoryService categories;

        public CreateModel(SportsSystemContext context, ICategoryService categories)
        {
            this.categories = categories;
        }

        [BindProperty]
        public CreateCategoryBindingModel Model { get; set; }

        public void OnGet()
        {
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPost()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            var category = this.categories.Create(this.Model.Name);

            if (category == null)
            {
                return this.Page();
            }

            return this.RedirectToAction("All", "Categories", new { area = "" });
        }
    }
}
namespace Project.Web.Areas.Admin.Pages.Articles
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Project.Models.BindingModels;
    using Project.Services.Interfaces;
    using System.Security.Claims;

    public class CreateModel : PageModel
    {
        private readonly IArticleService articles;

        public CreateModel(IArticleService articles)
        {
            this.articles = articles;
            this.Model = new CreateArticleBindingModel();
        }

        [BindProperty]
        public CreateArticleBindingModel Model { get; set; }

        public void OnGet()
        {
            this.Model.Categories = this.articles.PrepareCategories();
            this.RedirectToPage(this.Model);
        }

        public IActionResult OnPost()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            var article = this.articles.Create(
                    this.Model.Title, 
                    this.Model.Content, 
                    this.Model.Category, 
                    this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (article == null)
            {
                return this.Page();
            }

            return this.RedirectToAction("All", "Articles", new { area = "" });
        }
    }
}
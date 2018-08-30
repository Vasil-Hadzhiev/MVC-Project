namespace Project.Web.Pages.Videos
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Project.Models.BindingModels;
    using Project.Services.Interfaces;

    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IVideoService videos;

        public CreateModel(IVideoService videos)
        {
            this.videos = videos;
            this.Model = new CreateVideoBindingModel();
        }

        [BindProperty]
        public CreateVideoBindingModel Model { get; set; }

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

            this.videos.Create(this.Model);

            return this.RedirectToAction("All", "Videos", new { area = "" });
        }
    }
}
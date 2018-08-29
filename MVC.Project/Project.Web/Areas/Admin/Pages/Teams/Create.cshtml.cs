namespace Project.Web.Areas.Admin.Pages.Teams
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Project.Models.BindingModels;
    using Project.Services.Interfaces;

    public class CreateModel : PageModel
    {
        private readonly ITeamService teams;

        public CreateModel(ITeamService teams)
        {
            this.teams = teams;
        }

        [BindProperty]
        public CreateTeamBindingModel Model { get; set; }

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

            var teamExists = this.teams.Create(this.Model.Name, this.Model.LogoUrl);

            if (teamExists == null)
            {
                return this.Page();
            }

            return this.RedirectToAction("All", "Teams", new { area = "" });
        }
    }
}
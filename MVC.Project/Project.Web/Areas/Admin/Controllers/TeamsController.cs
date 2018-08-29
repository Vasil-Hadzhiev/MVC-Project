namespace Project.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Project.Models.BindingModels;
    using Project.Services.Interfaces;

    public class TeamsController : AdminController
    {
        private readonly ITeamService teams;

        public TeamsController(ITeamService teams)
        {
            this.teams = teams;
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var success = this.teams.Delete(id);

            if (!success)
            {
                return this.RedirectToAction("All", "Teams", new { area = "" });
            }

            return this.RedirectToAction("All", "Teams", new { area = "" });
        }

        public IActionResult Edit(int id)
        {
            var model = this.teams.GetEditModel(id);

            if (model == null)
            {
                return this.RedirectToAction("All", "Articles", new { area = "" });
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditTeamBindingModel model)
        {
            this.teams.Edit(model.Id, model.Name, model.LogoUrl);

            return this.RedirectToAction("All", "Teams", new { area = "" });
        }
    }
}

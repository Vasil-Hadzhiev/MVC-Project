namespace Project.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Project.Services.Interfaces;
    using System.Security.Claims;

    [Authorize]
    public class TeamsController : Controller
    {
        private readonly ITeamService teams;

        public TeamsController(ITeamService teams)
        {
            this.teams = teams;
        }

        public IActionResult All()
        {
            var teams = this.teams.GetTeams(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return this.View(teams);
        }

        [HttpPost]
        public IActionResult Favourite(int id)
        {
            this.teams.FavouriteATeam(this.User.FindFirstValue(ClaimTypes.NameIdentifier), id);
            return this.RedirectToAction("All", "Teams", new { area = "" });
        }

        [HttpPost]
        public IActionResult Unfavourite(int id)
        {
            this.teams.UnfavouriteATeam(this.User.FindFirstValue(ClaimTypes.NameIdentifier), id);
            return this.RedirectToAction("All", "Teams", new { area = "" });
        }
    }
}
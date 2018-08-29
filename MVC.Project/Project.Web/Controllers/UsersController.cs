namespace Project.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Project.Services.Interfaces;

    public class UsersController : Controller
    {
        private readonly IUserService users;

        public UsersController(IUserService users)
        {
            this.users = users;
        }

        public IActionResult Details(string id)
        {
            var user = this.users.Details(id);
            if (user == null)
            {
                return this.RedirectToAction("Index", "Home", new { area = "" });
            }

            return this.View(user);
        }
    }
}
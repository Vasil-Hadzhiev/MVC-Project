namespace Project.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Project.Services.Interfaces;
    using Project.Web.Common;

    [Authorize]
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
                this.Response.StatusCode = 404;
                return new NotFoundViewResult("CustomNotFound");
            }

            return this.View(user);
        }
    }
}
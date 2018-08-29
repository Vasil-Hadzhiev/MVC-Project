namespace Project.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Project.Services.Interfaces;

    public class UsersController : AdminController
    {
        private readonly IUserService users;

        public UsersController(IUserService users)
        {
            this.users = users;
        }

        public IActionResult All()
        {
            var users = this.users.GetUsers();
            return this.View(users);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var success = this.users.Delete(id);

            if (!success)
            {
                return this.RedirectToAction("All", "Users", new { area = "Admin" });
            }

            return this.RedirectToAction("All", "Users", new { area = "Admin" });
        }
    }
}
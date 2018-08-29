namespace Project.Services
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Project.Data;
    using Project.Models.ViewModels;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : Service, IUserService
    {
        public UserService(SportsSystemContext context) 
            : base(context)
        {
        }

        public List<UsersViewModel> GetUsers()
        {
            var users = this.Context
                .Users
                .Where(u => u.UserName != "admin")
                .Select(u => new UsersViewModel
                {
                    Id = u.Id,
                    Username = u.UserName,
                    AvatarUrl = u.AvatarUrl
                })
                .ToList();

            return users;
        }

        public bool Delete(string id)
        {
            var user = this.Context
                .Users
                .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return false;
            }

            this.Context.Users.Remove(user);
            this.Context.SaveChanges();

            return true;
        }

        public UserDetailsViewModel Details(string id)
        {
            var user = this.Context
                .Users
                .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            var userModel = new UserDetailsViewModel
            {
                Id = id,
                Username = user.UserName,
                AvatarUrl = user.AvatarUrl
            };

            return userModel;
        }
    }
}
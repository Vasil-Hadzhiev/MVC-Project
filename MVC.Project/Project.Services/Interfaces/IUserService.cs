namespace Project.Services.Interfaces
{
    using Project.Models.ViewModels;
    using System.Collections.Generic;

    public interface IUserService
    {
        List<UsersViewModel> GetUsers();

        bool Delete(string id);

        UserDetailsViewModel Details(string id);
    }
}
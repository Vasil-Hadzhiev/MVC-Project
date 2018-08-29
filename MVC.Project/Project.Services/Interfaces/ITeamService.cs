namespace Project.Services.Interfaces
{
    using Project.Models.BindingModels;
    using Project.Models.EntityModels;
    using Project.Models.ViewModels;
    using System.Collections.Generic;

    public interface ITeamService
    {
        Team Create(string name, string logoUrl);

        bool Delete(int id);

        EditTeamBindingModel GetEditModel(int id);

        void Edit(int id, string name, string logoUrl);

        void FavouriteATeam(string userId, int teamId);

        void UnfavouriteATeam(string userId, int teamId);

        ICollection<TeamsViewModel> GetTeams(string id);
    }
}
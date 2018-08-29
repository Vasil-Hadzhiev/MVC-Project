namespace Project.Services
{
    using Interfaces;
    using Project.Data;
    using Project.Models.BindingModels;
    using Project.Models.EntityModels;
    using Project.Models.ViewModels;
    using System.Collections.Generic;
    using System.Linq;

    public class TeamService : Service, ITeamService
    {
        public TeamService(SportsSystemContext context) 
            : base(context)
        {
        }

        public Team Create(string name, string logoUrl)
        {
            var teamExists = this.Context
                .Teams
                .FirstOrDefault(t => t.Name == name);

            if (teamExists != null)
            {
                return null;
            }

            var team = new Team
            {
                Name = name,
                LogoUrl = logoUrl
            };

            this.Context.Teams.Add(team);
            this.Context.SaveChanges();

            return team;
        }

        public ICollection<TeamsViewModel> GetTeams(string id)
        {
            var user = this.Context
                .Users
                .FirstOrDefault(u => u.Id == id);

            var favouriteTeam = user.HasFavouriteTeam;

            var teams = this.Context
                .Teams
                .Select(t => new TeamsViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    FansCount = t.Fans.Count,
                    Fans = this.Context
                        .Users
                        .Where(u => u.FavouriteTeam == this.Context.Teams.FirstOrDefault(team => team.Id == t.Id))
                        .ToList(),
                    HasFavouriteTeam = favouriteTeam
                })
                .ToList();

            return teams;
        }

        public bool Delete(int id)
        {
            var team = this.Context
                .Teams
                .FirstOrDefault(c => c.Id == id);

            if (team == null)
            {
                return false;
            }

            this.Context.Teams.Remove(team);
            this.Context.SaveChanges();

            return true;
        }

        public EditTeamBindingModel GetEditModel(int id)
        {
            var team = this.Context
                .Teams
                .FirstOrDefault(a => a.Id == id);

            if (team == null)
            {
                return null;
            }

            var model = new EditTeamBindingModel
            {
                Id = team.Id,
                Name = team.Name,
                LogoUrl = team.LogoUrl
            };

            return model;
        }

        public void Edit(int id, string name, string logoUrl)
        {
            var team = this.Context
                .Teams
                .FirstOrDefault(t => t.Id == id);

            team.Name = name;
            team.LogoUrl = logoUrl;

            this.Context.SaveChanges();
        }

        public void FavouriteATeam(string userId, int teamId)
        {
            var user = this.Context
                .Users
                .FirstOrDefault(u => u.Id == userId);

            var team = this.Context
                .Teams
                .FirstOrDefault(t => t.Id == teamId);

            user.FavouriteTeam = team;
            user.HasFavouriteTeam = true;
            team.Fans.Add(user);

            this.Context.SaveChanges();
        }

        public void UnfavouriteATeam(string userId, int teamId)
        {
            var user = this.Context
                .Users
                .FirstOrDefault(u => u.Id == userId);

            var team = this.Context
                .Teams
                .FirstOrDefault(t => t.Id == teamId);

            user.FavouriteTeam = null;
            user.HasFavouriteTeam = false;
            team.Fans.Remove(user);

            this.Context.SaveChanges();
        }
    }
}
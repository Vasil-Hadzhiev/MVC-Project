namespace Project.Models.ViewModels
{
    using Project.Models.EntityModels;
    using System.Collections.Generic;

    public class TeamsViewModel
    {
        public TeamsViewModel()
        {
            this.Fans = new List<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int FansCount{ get; set; }

        public bool HasFavouriteTeam { get; set; }

        public ICollection<User> Fans { get; set; }
    }
}
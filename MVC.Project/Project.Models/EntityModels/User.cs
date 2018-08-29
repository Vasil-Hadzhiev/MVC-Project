namespace Project.Models.EntityModels
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        public User()
        {
            this.ArticlesVoted = new List<UsersArticles>();
        }      

        [Url]
        public string AvatarUrl { get; set; }

        public Team FavouriteTeam { get; set; }

        public bool HasFavouriteTeam { get; set; }

        public ICollection<UsersArticles> ArticlesVoted { get; set; }
    }
}
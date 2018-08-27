namespace Project.Models.EntityModels
{
    public class UsersArticles
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
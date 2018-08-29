namespace Project.Models.ViewModels
{
    using System;

    public class ArticleDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Upvotes { get; set; }

        public bool HasVoted { get; set; }

        public string ImageUrl { get; set; }
    }
}
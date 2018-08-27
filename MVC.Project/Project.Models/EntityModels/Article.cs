namespace Project.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Article
    {
        public Article()
        {
            this.UsersVoted = new List<UsersArticles>();
            this.Comments = new List<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MinLength(30)]
        [MaxLength(200)]
        public string Content { get; set; }

        public User Author { get; set; }

        public string AuthorId { get; set; }

        public DateTime CreatedOn { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public ICollection<UsersArticles> UsersVoted { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
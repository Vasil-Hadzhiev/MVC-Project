namespace Project.Models.EntityModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public Article Article { get; set; }

        public int ArticleId { get; set; }
    }
}
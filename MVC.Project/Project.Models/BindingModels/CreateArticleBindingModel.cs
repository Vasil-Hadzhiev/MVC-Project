namespace Project.Models.BindingModels
{
    using Project.Models.EntityModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateArticleBindingModel
    {
        private const string TitleMinLengthMsg = "Title must be at least 3 symbols";
        private const string ContentMinLengthMsg = "Content must be at least 30 symbols";
        private const string ContentMaxLengthMsg = "Content must be at least 200 symbols";

        public CreateArticleBindingModel()
        {
            this.Categories = new List<string>();
        }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MinLength(30)]
        [MaxLength(200)]
        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Category { get; set; }

        public ICollection<string> Categories { get; set; }
    }
}
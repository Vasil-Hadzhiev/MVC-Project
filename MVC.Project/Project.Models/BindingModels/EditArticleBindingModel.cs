namespace Project.Models.BindingModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class EditArticleBindingModel
    {
        private const string TitleMinLengthMsg = "Title must be at least 3 symbols";
        private const string ContentMinLengthMsg = "Content must be at least 30 symbols";
        private const string ContentMaxLengthMsg = "Content must be at least 200 symbols";

        public EditArticleBindingModel()
        {
            this.Categories = new List<string>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MinLength(30)]
        [MaxLength(200)]
        public string Content { get; set; }

        public string Category { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public ICollection<string> Categories { get; set; }
    }
}
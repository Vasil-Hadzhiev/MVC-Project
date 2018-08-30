namespace Project.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;

    public class Video
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Url]
        public string VideoUrl { get; set; }
    }
}
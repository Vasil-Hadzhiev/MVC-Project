namespace Project.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateVideoBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [Url]
        public string VideoUrl { get; set; }
    }
}
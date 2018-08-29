namespace Project.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class EditTeamBindingModel
    {
        public int Id { get; set; }

        private const string MinLengthMessage = "Name must be at least 2 symbols";
        private const string MaxLengthMessage = "Name can be max 30 symbols";

        [Required]
        [MinLength(2, ErrorMessage = MinLengthMessage)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Url]
        public string LogoUrl { get; set; }
    }
}
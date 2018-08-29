namespace Project.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryBindingModel
    {
        private const string MinLengthMessage = "Name must be at least 3 symbols";

        [Required]
        [MinLength(3, ErrorMessage = MinLengthMessage)]
        public string Name { get; set; }
    }
}
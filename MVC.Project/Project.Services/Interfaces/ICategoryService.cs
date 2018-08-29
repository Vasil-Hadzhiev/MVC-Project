namespace Project.Services.Interfaces
{
    using Project.Models.EntityModels;
    using Project.Models.ViewModels;
    using System.Collections.Generic;

    public interface ICategoryService
    {
        Category Create(string name);

        bool Delete(int id);

        ICollection<CategoriesViewModel> GetCategories();

        ICollection<ArticlesViewModel> GetCategoryArticles(int id);
    }
}
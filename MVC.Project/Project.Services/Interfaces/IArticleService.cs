namespace Project.Services.Interfaces
{
    using Project.Models.BindingModels;
    using Project.Models.EntityModels;
    using Project.Models.ViewModels;
    using System.Collections.Generic;

    public interface IArticleService
    {
        List<string> PrepareCategories();

        Article Create(string title, string content, string category, string authorId);

        bool Delete(int id);

        void Edit(int id, string title, string content, string category);

        int Like(int id);

        ArticleDetailsViewModel GetDetails(int id);

        List<ArticlesViewModel> GetArticles();

        EditArticleBindingModel GetEditModel(int id);
    }
}
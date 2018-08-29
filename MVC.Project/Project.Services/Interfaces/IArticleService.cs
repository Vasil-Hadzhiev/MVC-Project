namespace Project.Services.Interfaces
{
    using Project.Models.BindingModels;
    using Project.Models.EntityModels;
    using Project.Models.ViewModels;
    using System.Collections.Generic;

    public interface IArticleService
    {
        List<string> PrepareCategories();

        Article Create(string title, string content, string category, string authorId, string url);

        bool Delete(int id);

        void Edit(int id, string title, string content, string category, string url);

        int Upvote(int id, string userId);

        ArticleDetailsViewModel GetDetails(int id, string userId);

        List<ArticlesViewModel> GetArticles();

        EditArticleBindingModel GetEditModel(int id);

        List<IndexViewModel> TopArticles();
    }
}
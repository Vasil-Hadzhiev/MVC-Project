namespace Project.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Project.Services.Interfaces;

    public class ArticlesController : Controller
    {
        private readonly IArticleService articles;

        public ArticlesController(IArticleService articles)
        {
            this.articles = articles;
        }

        public IActionResult All()
        {
            var articles = this.articles.GetArticles();
            return this.View(articles);
        }

        public IActionResult Details(int id)
        {
            var article = this.articles.GetDetails(id);

            if (article == null)
            {
                return this.RedirectToAction("All", "Articles", new { area = "" });
            }

            return this.View(article);
        }

        public int Like(int id)
        {
            int value = this.articles.Like(id);
            return value;
        }
    }
}
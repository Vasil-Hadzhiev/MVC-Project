namespace Project.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Project.Services.Interfaces;
    using Project.Web.Common;
    using System.Security.Claims;
    using X.PagedList;

    [Authorize]
    public class ArticlesController : Controller
    {
        private readonly IArticleService articles;

        public ArticlesController(IArticleService articles)
        {
            this.articles = articles;
        }

        public IActionResult All(int? page)
        {
            var articles = this.articles.GetArticles();
            return this.View(articles);
        }

        public IActionResult Details(int id)
        {
            var article = this.articles.GetDetails(id, this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (article == null)
            {
                this.Response.StatusCode = 404;
                return new NotFoundViewResult("CustomNotFound");
            }

            return this.View(article);
        }

        public int Upvote(int id)
        {
            int value = this.articles.Upvote(id, this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return value;
        }
    }
}
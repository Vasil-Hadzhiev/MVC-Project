namespace Project.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Project.Services.Interfaces;
    using Project.Web.Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IArticleService articles;

        public HomeController(IArticleService articles)
        {
            this.articles = articles;
        }

        public IActionResult Index()
        {
            var articles = this.articles.TopArticles();
            return View(articles);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
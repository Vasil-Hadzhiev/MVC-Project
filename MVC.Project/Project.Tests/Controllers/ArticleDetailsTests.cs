namespace Project.Tests.Controllers
{
    using Microsoft.Extensions.Localization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Project.Services.Interfaces;
    using Project.Web.Areas.Admin.Controllers;

    [TestClass]
    public class ArticleDetailsTests
    {
        [TestMethod]
        public void Details_ReturnsNotFound()
        {
            var mockRepo = new Mock<IArticleService>();

            //var mockLocalizer = new Mock<IStringLocalizer<ArticlesController>>();
        }
    }
}

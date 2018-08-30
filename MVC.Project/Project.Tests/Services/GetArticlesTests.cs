namespace Project.Tests.Services
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Project.Data;
    using Project.Models.EntityModels;
    using Project.Services;
    using System;

    [TestClass]
    public class GetArticlesTests
    {
        [TestMethod]
        public void GetArticles_ShouldReturnAll()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<SportsSystemContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dbContext = new SportsSystemContext(options);
            dbContext.Articles.Add(new Article()
            {
                Id = 1,
                Title = "Football",
            });
            dbContext.Articles.Add(new Article()
            {
                Id = 2,
                Title = "Basketball",
            });
            dbContext.Articles.Add(new Article()
            {
                Id = 3,
                Title = "Tennis",
            });

            dbContext.SaveChanges();

            var service = new ArticleService(dbContext);

            // Act
            var articles = service.GetArticles();

            // Assert
            Assert.AreEqual(3, articles.Count);
        }

        [TestMethod]
        public void GetArticles_ShouldReturnNone()
        {
            var options = new DbContextOptionsBuilder<SportsSystemContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dbContext = new SportsSystemContext(options);

            var service = new ArticleService(dbContext);

            var articles = service.GetArticles();

            Assert.AreEqual(0, articles.Count);
        }
    }
}

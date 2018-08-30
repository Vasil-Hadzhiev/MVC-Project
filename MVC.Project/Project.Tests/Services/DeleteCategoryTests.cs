namespace Project.Tests.Services
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Project.Data;
    using Project.Models.EntityModels;
    using Project.Services;
    using System;
    using System.Linq;

    [TestClass]
    public class DeleteCategoryTests
    {
        [TestMethod]
        public void DeleteCategory_RemovesCorrectly()
        {
            var options = new DbContextOptionsBuilder<SportsSystemContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dbContext = new SportsSystemContext(options);

            dbContext.Categories.Add(new Category{Id = 1, Name = "Football"});

            var service = new CategoryService(dbContext);

            service.Delete(1);

            Assert.AreEqual(0, dbContext.Categories.Count());
        }
    }
}

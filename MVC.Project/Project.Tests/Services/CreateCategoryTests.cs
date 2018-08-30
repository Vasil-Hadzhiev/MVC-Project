namespace Project.Tests.Services
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Project.Data;
    using Project.Services;
    using System;
    using System.Linq;

    [TestClass]
    public class CreateCategoryTests
    {
        [TestMethod]
        public void CreateCategory_ShouldCreateCorrectly()
        {
            var options = new DbContextOptionsBuilder<SportsSystemContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dbContext = new SportsSystemContext(options);

            var service = new CategoryService(dbContext);

            service.Create("Football");

            Assert.AreEqual(1, dbContext.Categories.Count());
        }

        [TestMethod]
        public void CreateCategory_AddsCorrectlyName()
        {
            var options = new DbContextOptionsBuilder<SportsSystemContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dbContext = new SportsSystemContext(options);

            var service = new CategoryService(dbContext);

            service.Create("Football");

            Assert.AreEqual(true, dbContext.Categories.Any(c => c.Name == "Football"));
        }
    }
}

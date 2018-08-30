namespace Project.Tests.Services
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Project.Data;
    using Project.Models.EntityModels;
    using Project.Services;
    using System;

    [TestClass]
    public class FavouriteTeamTests
    {
        [TestMethod]
        public void UserFavouritesATeam_FavouritesCorrectly()
        {
            var options = new DbContextOptionsBuilder<SportsSystemContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dbContext = new SportsSystemContext(options);

            dbContext.Teams.Add(new Team { Id = 1, Name = "Liverpool" });
            dbContext.Users.Add(new User { Id = "1", UserName = "admin" });
            dbContext.SaveChanges();
            var service = new TeamService(dbContext);
            service.FavouriteATeam("1", 1);

            Assert.AreEqual(1, dbContext.Teams.Find(1).Fans.Count);
        }

        [TestMethod]
        public void UserUnfavouritesATeam_UnfavouritesCorrectly()
        {
            var options = new DbContextOptionsBuilder<SportsSystemContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dbContext = new SportsSystemContext(options);

            dbContext.Teams.Add(new Team { Id = 1, Name = "Liverpool" });
            dbContext.SaveChanges();
            var team = dbContext.Teams.Find(1);
            dbContext.Users.Add(new User { Id = "1", UserName = "admin", FavouriteTeam = team });
            dbContext.SaveChanges();

            var service = new TeamService(dbContext);
            service.UnfavouriteATeam("1", 1);

            Assert.AreEqual(0, dbContext.Teams.Find(1).Fans.Count);
        }
    }
}

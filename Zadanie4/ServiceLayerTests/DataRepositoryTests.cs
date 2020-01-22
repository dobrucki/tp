using System;
using System.Linq;
using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer;

namespace ServiceLayerTests
{
    [TestClass]
    public class DataRepositoryTests
    {
        private DataRepository repo = new DataRepository();

        [TestMethod]
        public void GetAllLocationsTest()
        {
            IQueryable<Location> locations = repo.GetAllLocations();
            Assert.AreEqual(14, locations.ToList().Count);
        }

        [TestMethod]
        public void AddLocationTest()
        {
            Location newLocation = new Location
            {
                Name = "Home",
                CostRate = 0.000M,
                Availability = 40.00M,
                ModifiedDate = DateTime.Today,
            };
            repo.AddLocation(newLocation);
            IQueryable<Location> locations = repo.GetAllLocations();
            Assert.AreEqual(15, locations.ToList().Count);
        }

        [TestMethod]
        public void DeleteLocationTest()
        {
            repo.DeleteLocation(repo.GetAllLocations().ToList().Last().LocationID);
            IQueryable<Location> locations = repo.GetAllLocations();
            Assert.AreEqual(14, locations.ToList().Count);
        }

        [TestMethod]
        public void UpdateUpdateLocation()
        {
            repo.UpdateLocation(1, "Warsaw");
            IQueryable<Location> locations = repo.GetAllLocations();
            Assert.AreEqual("Warsaw", locations.ToList()[0].Name);
        }

        [TestMethod]
        public void GetLocationTest()
        {
            Location location = repo.GetLocation(1);
            Assert.AreEqual("Warsaw", location.Name);
        }





    }
}

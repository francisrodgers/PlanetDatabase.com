namespace PlanetDatabase.Service.Tests
{
    using Controllers;
    using Models;
    using System.Collections.Generic;
    using System.Web.Http.Results;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestPlanetsController
    {
        private List<Planet> GetTestPlanets()
        {
            List<Planet> Planets = new List<Planet>();
            Planets.Add(new Planet() { PlanetName = "Mercury", DistanceFromSun = 57900000 });
            Planets.Add(new Planet() { PlanetName = "Venus", DistanceFromSun = 108000000 });
            Planets.Add(new Planet() { PlanetName = "Earth", DistanceFromSun = 150000000 });
            Planets.Add(new Planet() { PlanetName = "Mars", DistanceFromSun = 228000000 });
            Planets.Add(new Planet() { PlanetName = "Jupiter", DistanceFromSun = 778000000 });
            Planets.Add(new Planet() { PlanetName = "Saturn", DistanceFromSun = 1430000000 });
            Planets.Add(new Planet() { PlanetName = "Uranus", DistanceFromSun = 2870000000 });
            Planets.Add(new Planet() { PlanetName = "Neptune", DistanceFromSun = 4500000000 });

            return Planets;
        }



        [TestMethod]
        public void GetPlanet_ShouldReturnCorrectDistanceFromSun()
        {
            var testPlanet = GetTestPlanets();
            var controller = new PlanetsController(testPlanet);

            var result = controller.Get("Mercury") as OkNegotiatedContentResult<Planet>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testPlanet[0].DistanceFromSun, result.Content.DistanceFromSun);
        }
    }
}

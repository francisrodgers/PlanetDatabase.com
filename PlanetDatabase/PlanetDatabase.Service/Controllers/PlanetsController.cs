namespace PlanetDatabase.Service.Controllers
{
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;

    public class PlanetsController : ApiController
    {
        //Just done an in memory database - specific requirement for only 2 parts so no need for real database.
        IList<Planet> Planets;

        public PlanetsController()
        {
            Planets = new List<Planet>();
            Planets.Add(new Planet() { PlanetName = "Mercury", DistanceFromSun = 57900000 });
            Planets.Add(new Planet() { PlanetName = "Venus", DistanceFromSun = 108000000 });
            Planets.Add(new Planet() { PlanetName = "Earth", DistanceFromSun = 150000000 });
            Planets.Add(new Planet() { PlanetName = "Mars", DistanceFromSun = 228000000 });
            Planets.Add(new Planet() { PlanetName = "Jupiter", DistanceFromSun = 778000000 });
            Planets.Add(new Planet() { PlanetName = "Saturn", DistanceFromSun = 1430000000 });
            Planets.Add(new Planet() { PlanetName = "Uranus", DistanceFromSun = 2870000000 });
            Planets.Add(new Planet() { PlanetName = "Neptune", DistanceFromSun = 4500000000 });
        }

        [ResponseType(typeof(Planet))]
        public IHttpActionResult Get([FromUri]string PlanetName)
        {
            Planet planet = Planets.FirstOrDefault(p => p.PlanetName == PlanetName);

            return Ok(planet);
        }
    }
}

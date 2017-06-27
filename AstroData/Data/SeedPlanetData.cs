using System.Collections.Generic;
using AstroData.Models;

namespace AstroData.Data
{
    public class SeedPlanetData
    {
        public static List<Planet> seedPlanetData = new List<Planet>
        {
            new Planet {Name = "Mercury", Description = "It's small and hot", DistanceFromSunKm = 57900000, DiameterKm = 4878},
            new Planet {Name = "Venus", Description = "It rains acid", DistanceFromSunKm = 108200000, DiameterKm = 12104},
            new Planet {Name = "Earth", Description = "It's home", DistanceFromSunKm = 149600000, DiameterKm = 12756},
            new Planet {Name = "Mars", Description = "It's red", DistanceFromSunKm = 227900000, DiameterKm = 6787},
            new Planet {Name = "Jupiter", Description = "It's big", DistanceFromSunKm = 778300000, DiameterKm = 142796},
            new Planet {Name = "Saturn", Description = "It's got rings", DistanceFromSunKm = 1427000000, DiameterKm = 120660},
            new Planet {Name = "Uranus", Description = "It's cloudy", DistanceFromSunKm = 2871000000, DiameterKm = 51118},
            new Planet {Name = "Neptune", Description = "It's blue", DistanceFromSunKm = 4497100000, DiameterKm = 48600},
            new Planet {Name = "Pluto", Description = "It's not a planet anymore", DistanceFromSunKm = 5913000000, DiameterKm = 2274}
        };
    }
}
using System;
using AstroData.Data;
using AstroData.Extensions;
using AstroData.Tables;
using FluentMigrator;

namespace AstroData.Profiles
{
    [Profile("AstroDataSeedDataProfile")]
    public class AstroDataSeedDataProfile : Migration
    {
        public override void Up()
        {
            if (this.TableContainsData(Constants.PlanetsTableName))
            {
                Console.WriteLine($"AstroDataSeedDataProfile already run for {Constants.PlanetsTableName}, skipping.");
                return;
            }

            Console.WriteLine("AstroDataSeedDataProfile");
            foreach (var planet in SeedPlanetData.seedPlanetData)
            {
                Insert.IntoTable(Constants.PlanetsTableName).Row(new
                {
                    planet.Name,
                    planet.Description,
                    Distance_From_Sun_KM = planet.DistanceFromSunKm,
                    Diameter_KM = planet.DiameterKm
                });
            }
        }

        public override void Down()
        {
        }
    }
}
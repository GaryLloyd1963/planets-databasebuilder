using System;
using FluentMigrator;

namespace AstroData.Tables
{
    [Migration(201706261521, "CreatePlanetTable")]
    public class CreatePlanetTable : Migration
    {
        public override void Up()
        {
            Console.WriteLine("CreatePlanetTable");
            Create.Table(Constants.PlanetsTableName)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Distance_From_Sun_KM").AsDecimal(18,2).NotNullable()
                .WithColumn("Diameter_KM").AsDecimal(18, 2).NotNullable();
        }

        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
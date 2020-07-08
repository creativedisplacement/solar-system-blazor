using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolarSystem.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Introduction = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Density = table.Column<double>(nullable: false),
                    Tilt = table.Column<double>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    RotationPeriod = table.Column<double>(nullable: false),
                    Period = table.Column<double>(nullable: false),
                    Radius = table.Column<int>(nullable: false),
                    Moons = table.Column<int>(nullable: false),
                    Au = table.Column<double>(nullable: false),
                    Eccentricity = table.Column<double>(nullable: false),
                    Velocity = table.Column<double>(nullable: false),
                    Mass = table.Column<double>(nullable: false),
                    Inclination = table.Column<double>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Ordinal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test2.Migrations
{
    public partial class Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityDict",
                columns: table => new
                {
                    IdCityDict = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CityDict_pk", x => x.IdCityDict);
                });

            migrationBuilder.CreateTable(
                name: "Passenger",
                columns: table => new
                {
                    IdPassenger = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PassportNum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Passenger_pk", x => x.IdPassenger);
                });

            migrationBuilder.CreateTable(
                name: "Plane",
                columns: table => new
                {
                    IdPlane = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Plane_pk", x => x.IdPlane);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    IdFlight = table.Column<int>(type: "int", nullable: false),
                    FlightDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IdPlane = table.Column<int>(type: "int", nullable: false),
                    IdCityDict = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Flight_pk", x => x.IdFlight);
                    table.ForeignKey(
                        name: "Flight_CityDict",
                        column: x => x.IdCityDict,
                        principalTable: "CityDict",
                        principalColumn: "IdCityDict");
                    table.ForeignKey(
                        name: "Flight_Plane",
                        column: x => x.IdPlane,
                        principalTable: "Plane",
                        principalColumn: "IdPlane");
                });

            migrationBuilder.CreateTable(
                name: "Flight_Passenger",
                columns: table => new
                {
                    IdFlight = table.Column<int>(type: "int", nullable: false),
                    IdPassenger = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Flight_Passenger_pk", x => new { x.IdFlight, x.IdPassenger });
                    table.ForeignKey(
                        name: "Table_4_Flight",
                        column: x => x.IdFlight,
                        principalTable: "Flight",
                        principalColumn: "IdFlight");
                    table.ForeignKey(
                        name: "Table_4_Passenger",
                        column: x => x.IdPassenger,
                        principalTable: "Passenger",
                        principalColumn: "IdPassenger");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_IdCityDict",
                table: "Flight",
                column: "IdCityDict");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_IdPlane",
                table: "Flight",
                column: "IdPlane");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_Passenger_IdPassenger",
                table: "Flight_Passenger",
                column: "IdPassenger");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight_Passenger");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Passenger");

            migrationBuilder.DropTable(
                name: "CityDict");

            migrationBuilder.DropTable(
                name: "Plane");
        }
    }
}

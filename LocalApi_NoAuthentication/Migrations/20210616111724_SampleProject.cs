using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalApi_NoAuthentication.Migrations
{
    public partial class SampleProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forecasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TemperatureC = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecasts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Forecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC", "User" },
                values: new object[] { 1, new DateTime(2021, 6, 17, 13, 17, 24, 590, DateTimeKind.Local).AddTicks(638), "Scorching", 28, "Admin" });

            migrationBuilder.InsertData(
                table: "Forecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC", "User" },
                values: new object[] { 2, new DateTime(2021, 6, 18, 13, 17, 24, 591, DateTimeKind.Local).AddTicks(9038), "Chilly", 12, "Admin" });

            migrationBuilder.InsertData(
                table: "Forecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC", "User" },
                values: new object[] { 3, new DateTime(2021, 6, 19, 13, 17, 24, 591, DateTimeKind.Local).AddTicks(9062), "Warm", 21, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forecasts");
        }
    }
}

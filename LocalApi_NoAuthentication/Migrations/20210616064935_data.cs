using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalApi_NoAuthentication.Migrations
{
    public partial class data : Migration
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
                values: new object[] { 1, new DateTime(2021, 6, 17, 8, 49, 35, 273, DateTimeKind.Local).AddTicks(6343), "Scorching", 28, null });

            migrationBuilder.InsertData(
                table: "Forecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC", "User" },
                values: new object[] { 2, new DateTime(2021, 6, 18, 8, 49, 35, 275, DateTimeKind.Local).AddTicks(4395), "Chilly", 12, null });

            migrationBuilder.InsertData(
                table: "Forecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC", "User" },
                values: new object[] { 3, new DateTime(2021, 6, 19, 8, 49, 35, 275, DateTimeKind.Local).AddTicks(4420), "Warm", 21, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forecasts");
        }
    }
}

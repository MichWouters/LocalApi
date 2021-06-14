using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalApi_NoAuthentication.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forecasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                columns: new[] { "Id", "Date", "Summary", "TemperatureC", "UserId" },
                values: new object[] { 1, new DateTime(2021, 6, 15, 16, 8, 56, 391, DateTimeKind.Local).AddTicks(1393), "Scorching", 28, 0 });

            migrationBuilder.InsertData(
                table: "Forecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC", "UserId" },
                values: new object[] { 2, new DateTime(2021, 6, 16, 16, 8, 56, 393, DateTimeKind.Local).AddTicks(211), "Chilly", 12, 0 });

            migrationBuilder.InsertData(
                table: "Forecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC", "UserId" },
                values: new object[] { 3, new DateTime(2021, 6, 17, 16, 8, 56, 393, DateTimeKind.Local).AddTicks(234), "Warm", 21, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forecasts");
        }
    }
}

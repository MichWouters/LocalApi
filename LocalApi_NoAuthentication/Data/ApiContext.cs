using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LocalApi_NoAuthentication.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<WeatherForecast> Forecasts { get; set; }

        public ApiContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>().HasData(
                new List<WeatherForecast>
                {
                    new WeatherForecast
                    {
                        Id = 1,
                        Summary = "Scorching",
                        Date = DateTime.Now.AddDays(1),
                        TemperatureC = 28
                    },
                    new WeatherForecast
                    {
                        Id = 2,
                        Summary = "Chilly",
                        Date = DateTime.Now.AddDays(2),
                        TemperatureC = 12
                    },
                    new WeatherForecast
                    {
                        Id = 3,
                        Summary = "Warm",
                        Date = DateTime.Now.AddDays(3),
                        TemperatureC = 21
                    },
                });
        }
    }
}
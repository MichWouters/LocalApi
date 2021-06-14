using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalApi_NoAuthentication.Data
{
    public class ApiContext: DbContext
    {
        public DbSet<WeatherForecast> Forecasts { get; set; }

        public ApiContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}

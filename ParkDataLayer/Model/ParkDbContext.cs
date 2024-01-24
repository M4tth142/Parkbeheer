using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ParkDataLayer.Model
{
    public class ParkDbContext : DbContext
    {        
        public DbSet<Park> Parks { get; set; }
        public DbSet<Huis> Huizen { get; set; }
        public DbSet<Huurder> Huurders { get; set; }
        public DbSet<Huurcontract> Huurcontracten { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = LAPTOP - CEMTVGFB\SQLEXPRESS; Initial Catalog = ParkBeheer; Integrated Security = True");
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
        }

    }
}

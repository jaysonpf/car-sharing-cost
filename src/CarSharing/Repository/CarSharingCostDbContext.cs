using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSharing.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSharing.Repository
{

    public class CarSharingCostDbContext : DbContext
    {
        public CarSharingCostDbContext(DbContextOptions<CarSharingCostDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>().ToTable("Car");
            builder.Entity<Consumption>().ToTable("Consumption");

            //base.OnModelCreating(builder);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Consumption> Consumption { get; set; }
    }
}


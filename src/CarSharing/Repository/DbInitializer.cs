using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSharing.Repository.Models;

namespace CarSharing.Repository
{
    public static class DbInitializer
    {

        public static void Initialize(CarSharingCostDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cars.Any()) return;


            context.Cars.Add(new Car {Name = "Agile LT", InitialKm = 0, Year = 2010});

            context.SaveChanges();

        }

    }
}

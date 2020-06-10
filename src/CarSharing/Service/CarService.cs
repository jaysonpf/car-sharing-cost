using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSharing.Repository;
using CarSharing.Repository.Models;

namespace CarSharing.Service
{
    public interface ICarService
    {
        Car FindById(int id);
        Task Add(Car car);
    }

    public class CarService : ICarService
    {
        public CarSharingCostDbContext CarSharingCostDbContext { get; set; }

        public CarService( CarSharingCostDbContext carSharingCostDbContext)
        {

            this.CarSharingCostDbContext = carSharingCostDbContext;
        }

        public Car FindById(int id)
        {
            return CarSharingCostDbContext.Cars.Find(id);
        }

        public async Task Add(Car car)
        {
            CarSharingCostDbContext.Cars.Add(car);
            await CarSharingCostDbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}

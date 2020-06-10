using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSharing.Repository;
using CarSharing.Repository.Models;
using Microsoft.EntityFrameworkCore;


namespace CarSharing.Service
{
    public interface IConsumptionService
    {
        Consumption FindById(int id);
        IEnumerable<Consumption> Find(Func<Consumption, bool> exp);
        Task Add(Consumption consumption);
    }

    public class ConsumptionService : IConsumptionService
    {

        public CarSharingCostDbContext CarSharingCostDbContext { get; set; }

        public ConsumptionService(CarSharingCostDbContext carSharingCostDbContext)
        {

            this.CarSharingCostDbContext = carSharingCostDbContext;
        }


        public Consumption FindById(int id)
        {
            return CarSharingCostDbContext.Consumption.Find(id);
        }


        public IEnumerable<Consumption> Find(Func<Consumption, bool> exp)
        {
            return CarSharingCostDbContext.Consumption.Where(exp).ToList();
        }

        public async Task Add(Consumption consumption)
        {
            CarSharingCostDbContext.Consumption.Add(consumption);
            await CarSharingCostDbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}

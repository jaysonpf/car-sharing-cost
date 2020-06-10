using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarSharing.Repository;
using CarSharing.Repository.Models;
using CarSharing.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CarSharing.Pages
{
    public class ConsumptionBase : ComponentBase
    {
        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected IConsumptionService ConsumptionService { get; set; }

        [Inject]
        protected ICarService CarService { get; set; }

        public Car Car;

        public CarSharing.Repository.Models.Consumption[] Consumptions;

        public ConsumptionInputModel Consumption = new ConsumptionInputModel();

        public ClaimsPrincipal UserLogged { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync().ConfigureAwait(false);
            UserLogged = authState.User;

            LoadPageData();
        }

        private void LoadPageData()
        {
            // for tests
            Car = CarService.FindById(1);

            Consumptions = ConsumptionService.Find(cons => cons.CarId == Car.Id).ToArray();
        }
        public async Task  HandleValidSubmit()
        {
            var fullName = UserLogged.FindFirstValue("FullName");

            var userId = UserLogged.FindFirstValue(ClaimTypes.NameIdentifier);

            var consumption = new CarSharing.Repository.Models.Consumption
            {
                CurrentDate = DateTime.Now,
                Distance = Consumption.Distance,
                FuelConsumption = Consumption.FuelConsumption,
                Observations = Consumption.Observations,
                UserName = fullName,
                UserId = Guid.Parse(userId), 
                Car = Car
            };

             await ConsumptionService.Add(consumption).ConfigureAwait(false);

            Consumption = new ConsumptionInputModel();

            LoadPageData();
        }
    }
}

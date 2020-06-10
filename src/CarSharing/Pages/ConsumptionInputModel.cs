using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarSharing.Pages
{
    public class ConsumptionInputModel
    {
        [Required]
        public int Distance { get; set; }

        public int FuelConsumption { get; set; }

        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Observations { get; set; }

    }
}

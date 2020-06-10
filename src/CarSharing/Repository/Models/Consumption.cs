using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharing.Repository.Models
{
    public class Consumption
    {
        [Key]
        public int Id { get; set; }

        public int Distance { get; set; }
        
        public int FuelConsumption { get; set; }

        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Observations { get; set; }

        public DateTime CurrentDate { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}

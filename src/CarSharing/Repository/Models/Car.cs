using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharing.Repository.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public int InitialKm { get; set; }

        public ICollection<Consumption> Consumptions { get; set; }
    }
}

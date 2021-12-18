using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Buses
{
    public class Bus : IEntity
    {
        [Key]
        public int BusId { get; set; }
        public string DriverName { get; set; }
        public string Brand { get; set; }
        public string Plate { get; set; }
        public int NumberOfSeats { get; set; }

    }
}

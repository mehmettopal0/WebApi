using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Expedition
{
    public class Expedition:IEntity
    {
        [Key]
        public int ExpeditionId { get; set; }
        public int BusId { get; set; }
        public int DepartureCityId { get; set; }
        public int ArrivalCityId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Price { get; set; }
    }
}

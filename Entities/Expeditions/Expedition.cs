using Core.Entities;
using Entities.Buses;
using Entities.Cities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Expeditions
{
    public class Expedition : IEntity
    {
        [Key]
        public int ExpeditionId { get; set; }

        [ForeignKey("Bus")]
        public int BusId { get; set; }
        public Bus Bus { get; set; }

        [ForeignKey("City")]
        public int? DepartureCityId { get; set; }
        public City City { get; set; }

        [ForeignKey("City1")]
        public int? ArrivalCityId { get; set; }
        public City City1 { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Price { get; set; }
    }
}

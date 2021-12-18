using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Reservation
{
    public class Reservation:IEntity
    {
        [Key]
        public int ReservationId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


        [ForeignKey("Expedition")]
        public int ExpeditionId { get; set; }
        public Expedition Expedition { get; set; }

        public int SeatNumber { get; set; }
        public DateTime ReservationTime { get; set; }

        
    }
}

using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Reservation
{
    public class ReservationCreateViewModel
    {
        //public int RoomId { get; set; }

        //public virtual Room Room { get; set; }

        //public int UserId { get; set; }

        public virtual User User { get; set; }

        //public virtual List<Client> Clients { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public bool HasBreakfast { get; set; }

        public bool IsAllInclusive { get; set; }

        public double FinalPrice { get; set; }
    }
}

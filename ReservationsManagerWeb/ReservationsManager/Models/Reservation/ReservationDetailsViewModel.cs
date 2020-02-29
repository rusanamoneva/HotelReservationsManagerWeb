using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Reservation
{
    public class ReservationDetailsViewModel
    {
        public virtual User User { get; set; }

        //public virtual List<Client> Clients { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public bool HasBreakfast { get; set; }

        public bool IsAllInclusive { get; set; }

        public double FinalPrice { get; set; }

        public List<Data.Entities.Client> Clients { get; set; }

    }
}

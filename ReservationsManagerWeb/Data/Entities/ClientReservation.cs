using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class ClientReservation
    {
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }
    }
}

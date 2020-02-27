using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        //public virtual List<Client> Clients { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public bool HasBreakfast { get; set; }

        public bool IsAllInclusive { get; set; }

        public double FinalPrice { get; set; }

        public ICollection<ClientReservation> ClientReservations { get; set; }
    }
}

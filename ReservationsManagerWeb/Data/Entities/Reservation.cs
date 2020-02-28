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

        public string UserId { get; set; }

        public virtual User User { get; set; }

        //public virtual List<Client> Clients { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public bool HasBreakfast { get; set; }

        public bool IsAllInclusive { get; set; }

        public double FinalPrice { get; set; }

        public virtual ICollection<ClientReservation> ClientReservations { get; set; }

        public Reservation()
        { }

        public Reservation(int roomId, Room room, string userId, User user
            , DateTime checkInDate, DateTime checkOutDate, bool hasBreakfast
            , bool isAllInclusive, double finalPrice
            , ICollection<ClientReservation> clientReservations)
        {
            RoomId = roomId;
            Room = room;
            UserId = userId;
            User = user;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            HasBreakfast = hasBreakfast;
            IsAllInclusive = isAllInclusive;
            FinalPrice = finalPrice;
            ClientReservations = clientReservations;
        }
    }
}

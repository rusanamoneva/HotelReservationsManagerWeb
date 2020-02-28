using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class ClientReservation
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public int ReservationId { get; set; }

        public virtual Reservation Reservation { get; set; }

        public ClientReservation()
        { }

        public ClientReservation(int clientId, Client client, int reservationId, Reservation reservation)
        {
            ClientId = clientId;
            Client = client;
            ReservationId = reservationId;
            Reservation = reservation;
        }
    }
}

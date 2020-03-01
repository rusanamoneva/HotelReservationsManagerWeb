using Data.Entities;
using System;
using System.Collections.Generic;

namespace ReservationsManager.Models.Reservation
{
    public class ReservationViewModel
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public bool HasBreakfast { get; set; }

        public bool IsAllInclusive { get; set; }

        public double FinalPrice { get; set; }

        public List<ClientReservation> ClientReservations { get; set; }

        public ReservationViewModel()
        { }

        public ReservationViewModel(int id, User user
            , DateTime checkInDate, DateTime checkOutDate
            , bool hasBreakfast, bool isAllInclusive, double finalPrice
            , List<ClientReservation> clientReservations)
        {
            Id = id;
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

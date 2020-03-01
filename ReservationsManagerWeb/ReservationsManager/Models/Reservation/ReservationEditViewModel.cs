using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Reservation
{
    public class ReservationEditViewModel
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public bool HasBreakfast { get; set; }

        public bool IsAllInclusive { get; set; }

        public double FinalPrice { get; set; }

        public ReservationEditViewModel()
        { }

        public ReservationEditViewModel(int id, User user, DateTime checkInDate
            , DateTime checkOutDate, bool hasBreakfast
            , bool isAllInclusive, double finalPrice)
        {
            Id = id;
            User = user;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            HasBreakfast = hasBreakfast;
            IsAllInclusive = isAllInclusive;
            FinalPrice = finalPrice;
        }
    }
}

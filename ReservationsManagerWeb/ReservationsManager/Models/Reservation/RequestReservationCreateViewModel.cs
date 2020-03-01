using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Reservation
{
    public class RequestReservationCreateViewModel
    {
        //public int RoomId { get; set; }

        public virtual Data.Entities.Room Room { get; set; }

        public virtual User User { get; set; }

        public List<int> ClientsId { get; set; }

        public int RoomId { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        public bool HasBreakfast { get; set; }

        public bool IsAllInclusive { get; set; }

        public double FinalPrice { get; set; }

        public RequestReservationCreateViewModel()
        { }

        public RequestReservationCreateViewModel(Data.Entities.Room room, User user
            , List<int> clientsId, int roomId, DateTime checkInDate, DateTime checkOutDate
            , bool hasBreakfast, bool isAllInclusive, double finalPrice)
        {
            Room = room;
            User = user;
            ClientsId = clientsId;
            RoomId = roomId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            HasBreakfast = hasBreakfast;
            IsAllInclusive = isAllInclusive;
            FinalPrice = finalPrice;
        }
    }
}

using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Reservation
{
    public class ReservationCreateViewModel
    {
        //public int RoomId { get; set; }

        public virtual Data.Entities.Room Room { get; set; }

        //public int UserId { get; set; }

        public virtual User User { get; set; }

        //public virtual List<Client> Clients { get; set; }

        public List<ReservationCreateClientViewModel> CreateClient { get; set; }

        public List<ReservationCreateRoomViewModel> RoomsAdded { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        public bool HasBreakfast { get; set; }

        public bool IsAllInclusive { get; set; }

        public double FinalPrice { get; set; }

        public ReservationCreateViewModel()
        { }

        public ReservationCreateViewModel(Data.Entities.Room room, User user
            , List<ReservationCreateClientViewModel> createClient
            , List<ReservationCreateRoomViewModel> roomsAdded
            , DateTime checkInDate, DateTime checkOutDate
            , bool hasBreakfast, bool isAllInclusive, double finalPrice)
        {
            Room = room;
            User = user;
            CreateClient = createClient;
            RoomsAdded = roomsAdded;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            HasBreakfast = hasBreakfast;
            IsAllInclusive = isAllInclusive;
            FinalPrice = finalPrice;
        }
    }
}

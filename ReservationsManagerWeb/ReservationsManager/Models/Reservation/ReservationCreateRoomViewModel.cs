using Data.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Reservation
{
    public class ReservationCreateRoomViewModel
    {
        public int Id { get; set; }

        public RoomTypeEnum RoomType { get; set; }

        public double PricePerAdult { get; set; }

        public double PricePerChild { get; set; }

        public bool IsFree { get; set; }

        public ReservationCreateRoomViewModel()
        { }

        public ReservationCreateRoomViewModel(int id, RoomTypeEnum roomType, double pricePerAdult, double pricePerChild, bool isFree)
        {
            this.Id = id;
            this.RoomType = roomType;
            this.PricePerAdult = pricePerAdult;
            this.PricePerChild = pricePerChild;
            this.IsFree = isFree;
        }
    }
}

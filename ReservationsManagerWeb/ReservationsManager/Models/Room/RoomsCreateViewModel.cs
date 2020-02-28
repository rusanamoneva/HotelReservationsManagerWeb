using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Data.Enumeration;

namespace ReservationsManager.Models.Room
{
    public class RoomsCreateViewModel
    {
        public int  Capacity { get; set; }

        public RoomTypeEnum RoomType { get; set; }

        public bool IsFree { get; set; }

        [Required]
        public double PricePerAdult { get; set; }

        [Required]
        public double PricePerChild { get; set; }

        public int Number { get; set; }

        public RoomsCreateViewModel()
        { }

        public RoomsCreateViewModel(int capacity, RoomTypeEnum roomType, bool isFree
            , double pricePerAdult, double pricePerChild, int number)
        {
            Capacity = capacity;
            RoomType = roomType;
            IsFree = isFree;
            PricePerAdult = pricePerAdult;
            PricePerChild = pricePerChild;
            Number = number;
        }
    }
}

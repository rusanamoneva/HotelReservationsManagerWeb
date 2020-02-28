using Data.Enumeration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public int Capacity { get; set; }

        public RoomTypeEnum RoomType { get; set; }

        public bool IsFree { get; set; }

        public double PricePerAdult { get; set; }

        public double PricePerChild { get; set; }

        public int Number { get; set; }

        public Room()
        { }

        public Room(int capacity, RoomTypeEnum roomType, bool isFree, double pricePerAdult, double pricePerChild, int number)
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

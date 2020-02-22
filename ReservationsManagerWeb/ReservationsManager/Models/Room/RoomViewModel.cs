﻿using Data.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Room
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        public int Capacity { get; set; }

        public RoomTypeEnum RoomType { get; set; }

        public bool IsFree { get; set; }

        public double PricePerAdult { get; set; }

        public double PricePerChild { get; set; }

        public int Number { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public int Capacitu { get; set; }

        public string Type { get; set; }

        public bool IsFree { get; set; }

        public double PricePerAdult { get; set; }

        public double PricePerChild { get; set; }

        public int Number { get; set; }
    }
}

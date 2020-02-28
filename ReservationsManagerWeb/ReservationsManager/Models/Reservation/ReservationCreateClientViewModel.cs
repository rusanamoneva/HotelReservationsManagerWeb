using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Reservation
{
    public class ReservationCreateClientViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ReservationCreateClientViewModel()
        { }

        public ReservationCreateClientViewModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}

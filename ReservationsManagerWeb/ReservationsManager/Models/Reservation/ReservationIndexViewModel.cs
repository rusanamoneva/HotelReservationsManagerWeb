using ReservationsManager.Models.Room;
using ReservationsManager.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Reservation
{
    public class ReservationIndexViewModel
    {
        public PagerViewModel Pager { get; set; }

        public ICollection<ReservationViewModel> Items { get; set; }
    }
}

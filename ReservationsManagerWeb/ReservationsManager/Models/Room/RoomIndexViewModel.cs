using ReservationsManager.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Room
{
    public class RoomIndexViewModel
    {
        public PagerViewModel Pager { get; set; }

        public ICollection<RoomViewModel> Items { get; set; }
    }
}

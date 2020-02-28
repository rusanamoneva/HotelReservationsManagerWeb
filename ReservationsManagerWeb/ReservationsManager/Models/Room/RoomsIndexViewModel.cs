using ReservationsManager.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Room
{
    public class RoomsIndexViewModel
    {
        public PagerViewModel Pager { get; set; }

        public ICollection<RoomsViewModel> Items { get; set; }

        public RoomsIndexViewModel()
        { }

        public RoomsIndexViewModel(PagerViewModel pager, ICollection<RoomsViewModel> items)
        {
            Pager = pager;
            Items = items;
        }
    }
}

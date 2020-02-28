using ReservationsManager.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Client
{
    public class ClientIndexViewModel
    {
        public PagerViewModel Pager { get; set; }

        public ICollection<ClientViewModel> Items { get; set; }

        public ClientIndexViewModel()
        { }

        public ClientIndexViewModel(PagerViewModel pager, ICollection<ClientViewModel> items)
        {
            Pager = pager;
            Items = items;
        }
    }
}

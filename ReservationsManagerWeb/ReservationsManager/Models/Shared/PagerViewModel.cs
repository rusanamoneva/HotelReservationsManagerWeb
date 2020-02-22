using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Shared
{
    public class PagerViewModel
    {
        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }
    }
}

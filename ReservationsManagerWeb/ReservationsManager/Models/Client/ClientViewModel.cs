using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Client
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsAdult { get; set; }
    }
}

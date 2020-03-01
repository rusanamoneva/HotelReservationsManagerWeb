using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Client
{
    public class ClientEditViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsAdult { get; set; }

        public ClientEditViewModel()
        { }

        public ClientEditViewModel(int id, string name, string surname, string phoneNumber, string email, bool isAdult)
        {
            Id = id;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            IsAdult = isAdult;
        }
    }
}

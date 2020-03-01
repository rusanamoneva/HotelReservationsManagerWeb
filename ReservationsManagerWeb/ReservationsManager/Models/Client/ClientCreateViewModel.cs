using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Client
{
    public class ClientCreateViewModel
    {
        [StringLength(50, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Required]
        public string Surname { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsAdult { get; set; }

        public ClientCreateViewModel()
        { }

        public ClientCreateViewModel(string name, string surname, string phoneNumber, string email, bool isAdult)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            IsAdult = isAdult;
        }
    }
}

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
        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsAdult { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class User

    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Pass { get; set; }

        public string Name { get; set; }

        public string FathersName { get; set; }

        public string Surname { get; set; }

        public int PersonalNumber { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime FiredDate { get; set; }

        public bool IsActive { get; set; }
    }
}

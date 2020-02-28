using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class User : IdentityUser<string>

    {
        //public int Id { get; set; }

        public string Name { get; set; }

        public string Pass { get; set; }

        public string FirstName { get; set; }

        public string FathersName { get; set; }

        public string Surname { get; set; }

        public int PersonalNumber { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime FiredDate { get; set; }

        public bool IsActive { get; set; }

        public User()
        { }

        public User(string name, string pass, string firstName
            , string fathersName, string surname, int personalNumber
            , int phoneNumber, string email, DateTime hireDate
            , DateTime firedDate, bool isActive)
        {
            Name = name;
            Pass = pass;
            FirstName = firstName;
            FathersName = fathersName;
            Surname = surname;
            PersonalNumber = personalNumber;
            PhoneNumber = phoneNumber;
            Email = email;
            HireDate = hireDate;
            FiredDate = firedDate;
            IsActive = isActive;
        }
    }
}

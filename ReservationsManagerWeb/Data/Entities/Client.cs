using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsAdult { get; set; }

        public virtual ICollection<ClientReservation> ClientReservations { get; set; }

        public Client()
        { }

        public Client(string name, string surname, string phoneNumber, string email, bool isAdult, ICollection<ClientReservation> clientReservations)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            IsAdult = isAdult;
            ClientReservations = clientReservations;
        }
    }
}
        
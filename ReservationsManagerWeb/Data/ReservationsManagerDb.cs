using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ReservationsManagerDb : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Room> Rooms { get; set; }

        public virtual DbSet<Reservation> Reservations { get; set; }

        public ReservationsManagerDb()
        { }

        public ReservationsManagerDb(DbContextOptions<ReservationsManagerDb> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=HotelReservationsManagerDb;Trusted_Connection=True;Integrated Security = True;");
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }
    }
}

using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ReservationsManagerDb : IdentityDbContext<User, IdentityRole, string>
    {
        private const string connectionString = Constants.connectionString;

        //public virtual DbSet<User> Users { get; set; }

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
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }
    }
}

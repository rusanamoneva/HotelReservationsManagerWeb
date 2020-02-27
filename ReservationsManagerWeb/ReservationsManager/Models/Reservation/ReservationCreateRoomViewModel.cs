using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Models.Reservation
{
    public class ReservationCreateRoomViewModel
    {
        public int RoomId { get; set; }

        public virtual Data.Entities.Room Room { get; set; }
    }
}

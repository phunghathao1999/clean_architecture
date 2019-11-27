using System;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class SeatReserved
    {
        public int SeatReservedId { get; set; }
        public int? SeatId { get; set; }
        public int? ReservationId { get; set; }
        public int? ScreeningId { get; set; }

        public virtual Reservation Reservation { get; set; }
        public virtual Screening Screening { get; set; }
        public virtual Seat Seat { get; set; }
    }
}

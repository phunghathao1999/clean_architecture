using System;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class Reservation
    {
        public Reservation()
        {
            SeatReserved = new HashSet<SeatReserved>();
        }

        public int ReservationId { get; set; }
        public int? ScreeningId { get; set; }
        public int? PeopleId { get; set; }
        public int? ReservationTypeId { get; set; }
        public string ReservationContact { get; set; }
        public bool? Paid { get; set; }
        public bool? Active { get; set; }

        public virtual People People { get; set; }
        public virtual Screening Screening { get; set; }
        public virtual ICollection<SeatReserved> SeatReserved { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class Screening
    {
        public Screening()
        {
            Reservation = new HashSet<Reservation>();
            SeatReserved = new HashSet<SeatReserved>();
        }

        public int ScreeningId { get; set; }
        public int? MovieId { get; set; }
        public int? AuditoriumId { get; set; }
        public DateTime? ScreeningStart { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }
        public virtual ICollection<SeatReserved> SeatReserved { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class Seat
    {
        public Seat()
        {
            SeatReserved = new HashSet<SeatReserved>();
        }

        public int SeatId { get; set; }
        public string Row { get; set; }
        public int? Number { get; set; }
        public int? AuditoriumId { get; set; }

        public virtual ICollection<SeatReserved> SeatReserved { get; set; }
    }
}

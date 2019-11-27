using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace ApplicationCore.EF
{
    public partial class People : IAggregateRoot
    {
        public People()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int PeopleId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public int? Phone { get; set; }
        public DateTime? Born { get; set; }
        public string Addre { get; set; }
        public string Account { get; set; }
        public string Pass { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}

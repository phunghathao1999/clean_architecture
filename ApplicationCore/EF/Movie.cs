using System;
using System.Collections.Generic;
using ApplicationCore.Interfaces;
namespace ApplicationCore.EF
{
    public partial class Movie : IAggregateRoot
    {
        public Movie()
        {
            Screening = new HashSet<Screening>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Actor { get; set; }
        public string Description { get; set; }
        public int? DurationMin { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Trailer { get; set; }
        public string FilmStudios { get; set; }
        public string Status { get; set; }
        public string Title1 { get; set; }
        public DateTime? Released { get; set; }
        public double? Scores { get; set; }

        public virtual ICollection<Screening> Screening { get; set; }
    }
}

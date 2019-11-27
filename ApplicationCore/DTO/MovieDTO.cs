using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTO
{
    public class MovieDTO
    {
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Vui long nhap tieu de !!!")]
        public string Title { get; set; }
        public string Director { get; set; }
        public string Actor { get; set; }
        public string Description { get; set; }
        public int? DurationMin { get; set; }
        public string img1 { get; set; }
        public string img2 { get; set; }
        public string trailer { get; set; }
        public string film_studios { get; set; }
        public string status { get; set; }
        public string title1 { get; set; }
        public DateTime? released { get; set; }
        public float scores { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTO
{
    public class PeopleDTO
    {
        public int PeopleId { get; set; }

        [Required(ErrorMessage = "Vui long nhap ho !!!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Vui long nhap ten !!!")]
        public string Name { get; set; }
        public int? Phone { get; set; }
        public DateTime? Born { get; set; }
        public string Addre { get; set; }
        public string Account { get; set; }
        public string Pass { get; set; }
    }
}

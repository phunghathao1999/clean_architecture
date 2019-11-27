using System;

namespace ApplicationCore.DTO
{
    public class SignupDTO
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public int? Phone { get; set; }

        public DateTime? Born { get; set; }

        public string Addre { get; set; }

        public string Account { get; set; }

        public string Pass { get; set; }
    }
}

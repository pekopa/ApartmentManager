using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingWebApi
{
    public class ResidentList
    {
        public int ResidentNr { get; set; }
        public int ApartmentNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
        public byte[] Picture { get; set; }

    }
}
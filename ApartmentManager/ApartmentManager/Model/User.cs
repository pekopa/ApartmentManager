using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Model
{
   public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int ApartmentNr { get; set; }

        public User() { }

        public User(string Name, string LastName, int Phone, DateTime BirthDate, string Email, int ApartmentNr)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Phone = Phone;
            this.BirthDate = BirthDate;
            this.Email = Email;
            this.ApartmentNr = ApartmentNr;

        }

        //public override string ToString()
        //{
        //    return string.Format("Hotelno {0} Name {1} Address {2}", Hotel_No, Name, Address);
        //}

    }
}

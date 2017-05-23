using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ApartmentManager.Model
{
   public class User
    {
        public string Username { get; set; }
        public int ApartmentId { get; set; }
        public string Password { get; set; }
        public bool IsBm { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] Picture { get; set; }
        public DateTime? MoveInDate { get; set; }
        public DateTime? MoveOutDate { get; set; }

        public User() { }

        public User(string FirstName, string LastName, string Phone, DateTime BirthDate, string Email, int ApartmentNr)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDate = BirthDate;
            this.Phone = Phone;
            this.Email = Email;
        }

        public override string ToString()
        {
            return string.Format($"First name {FirstName} Last name {LastName} Phone {Phone}");
        }

    }
}

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
        public int ApartmentNr { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Image Picture { get; set; }
        public string SecondName { get; set; }
        public string SecondLastName { get; set; }
        public string SecondBirthDate { get; set; }
        public string SecondPhone { get; set; }
        public string SecondEmail { get; set; }


        public User() { }

        public User(string FirstName, string LastName, string Phone, DateTime BirthDate, string Email, int ApartmentNr)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Phone = Phone;
            this.BirthDate = BirthDate;
            this.Email = Email;
            this.ApartmentNr = ApartmentNr;

        }

        public override string ToString()
        {
            return string.Format($"First name {FirstName} Last name {LastName} Phone {Phone}");
        }

    }
}

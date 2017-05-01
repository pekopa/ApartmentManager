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
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public Image Picture { get; set; }
        public int ApartmentNr { get; set; }
        public string SecondName { get; set; }
        public string SecondLastName { get; set; }
        public string SecondBirthDate { get; set; }
        public string SecondPhone { get; set; }
        public string SecondEmail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


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

        public override string ToString()
        {
            return string.Format($"Name {Name} LastName {LastName} Phone {Phone}");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ApartmentManager.Model
{
    public class Resident
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public Image Picture { get; set; }
        public int ApartmentNr { get; set; }
        public int ResidentNr { get; set; }

        public Resident() { }
        public Resident(string FirstName, string LastName, int Phone, DateTime BirthDate, string Email, int ApartmentNr, int ResidentNr)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Phone = Phone;
            this.BirthDate = BirthDate;
            this.Email = Email;
            this.ApartmentNr = ApartmentNr;
            this.ResidentNr = ResidentNr;
        }
        public override string ToString()
        {
            return string.Format($"Name: {FirstName}, LastName: {LastName}, Birth Date: {BirthDate}, Phone {Phone}, Email {Email} ");
        }
    }
}

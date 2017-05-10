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
        public DateTimeOffset BirthDate { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public int ApartmentNr { get; set; }
        public int ResidentNr { get; set; }
        
        public Resident() { }
        public Resident(string firstName, string lastName, int phone, DateTimeOffset birthDate, string email, int apartmentNr ,int residentNr, string picture)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            BirthDate = birthDate;
            Email = email;
            ApartmentNr = apartmentNr;
            ResidentNr = residentNr;
            Picture = picture;
        }
        //public override string ToString()
        //{
        //    return string.Format($"Name: {FirstName}, LastName: {LastName}, Birth Date: {BirthDate.Date}, Phone {Phone}, Email {Email} ");
        //}
    }
}

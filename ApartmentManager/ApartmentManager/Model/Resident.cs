using System;

namespace ApartmentManager.Model
{
    public class Resident
    {
        public int ResidentId { get; set; }
        public int ApartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }

        public Resident()
        {
            BirthDate = DateTime.Now;
        }
        public Resident(int residentId, int apartmentId, string firstName, string lastName, DateTime birthDate, string phone, string email)
        {
            ResidentId = residentId;
            ApartmentId = apartmentId;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
        }
        public override string ToString()
        {
            return string.Format($"First name: {FirstName}, Last name: {LastName}, Birth date: {BirthDate}, Phone: {Phone}, Email: {Email} ");
        }
    }
}

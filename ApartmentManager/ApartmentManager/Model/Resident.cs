using System;

namespace ApartmentManager.Model
{
    public class Resident
    {
        public int ResidentId { get; set; }
        public int ApartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }

        public Resident()
        {
            BirthDate = DateTime.Now;
        }
    }
}

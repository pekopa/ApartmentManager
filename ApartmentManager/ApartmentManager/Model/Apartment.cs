using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Model
{
    public class Apartment
    {
        public int ApartmentNumber { get; set; }
        public string Size { get; set; }
        public int NumberOfRooms { get; set; }
        public string MonthlyCharge { get; set; }
        public int Floor { get; set; }
        

        public Apartment() { }

        public Apartment(int ApartmentNumber, string Size,int NumberOfRooms,string MonthlyCharge,int Floor)
        {
            this.ApartmentNumber = ApartmentNumber;
            this.Size = Size;
            this.NumberOfRooms = NumberOfRooms;
            this.MonthlyCharge = MonthlyCharge;
            this.Floor = Floor;
            

        }

        //public override string ToString()
        //{
        //    return string.Format($"Name {Name} LastName {LastName} Phone {Phone}");
        //}



    }
}

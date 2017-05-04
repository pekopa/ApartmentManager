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
        public string Address { get; set; }

        public Apartment() { }

        public Apartment(int ApartmentNumber, string Size,int NumberOfRooms,string MonthlyCharge,int Floor, string Address)
        {
            this.ApartmentNumber = ApartmentNumber;
            this.Size = Size;
            this.NumberOfRooms = NumberOfRooms;
            this.MonthlyCharge = MonthlyCharge;
            this.Floor = Floor;
            this.Address = Address;

        }

        public override string ToString()
        {
            return string.Format(
                "Apartment No: {0} Size: {1} NoOfRooms: {2} MonthlyCharge: {3} Floor: {4} Address: {5}",
                ApartmentNumber, Size, NumberOfRooms, MonthlyCharge, Floor, Address);
        }
    }
}

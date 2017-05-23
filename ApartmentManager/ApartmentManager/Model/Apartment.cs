namespace ApartmentManager.Model
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public double? Size { get; set; }
        public int? NumberOfRooms { get; set; }
        public double? MonthlyCharge { get; set; }
        public int? Floor { get; set; }
        public string Address { get; set; }
        public string PlanPicture { get; set; }

        public Apartment() { }

        public Apartment(int apartmentId, double? size, int? numberOfRooms, double? monthlyCharge, int? floor, string address)
        {
            ApartmentId = apartmentId;
            Size = size;
            NumberOfRooms = numberOfRooms;
            MonthlyCharge = monthlyCharge;
            Floor = floor;
            Address = address;
        }

        //public override string ToString()
        //{
        //    return string.Format(
        //        "Apartment No: {0} Size: {1} NoOfRooms: {2} MonthlyCharge: {3} Floor: {4} Address: {5}",
        //        ApartmentNumber, Size, NumberOfRooms, MonthlyCharge, Floor, Address);
        //}

        public override string ToString()
        {
            return string.Format($"Apartment number: {ApartmentId}, Size: {Size} Number of rooms: {NumberOfRooms}, Monthly charge: {MonthlyCharge}, Floor: {Floor}, Address: {Address}");
        }
    }
}

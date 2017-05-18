using System;

namespace ApartmentManager.Model
{
    public class Defect
    {
        public int DefectId { get; set; }
        public int ApartmentId { get; set; }
        public string Name { get; set; }
        public DateTime? UploadDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public Defect() { }

        public Defect(int defectId, int apartmentId, string name, DateTime? uploadDate, string description, string status)
        {
            DefectId = defectId;
            ApartmentId = apartmentId;
            Name = name;
            UploadDate = uploadDate;
            Description = description;
            Status = status;
        }
        public override string ToString()
        {
            return string.Format($"Defect ID: {DefectId}, Apartment number: {ApartmentId}, Name: {Name}, Upload date: {UploadDate}, Description: {Description}, Status: {Status}");
        }
    }
}

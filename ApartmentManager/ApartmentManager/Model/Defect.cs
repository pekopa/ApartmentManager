using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ApartmentManager.Model
{
    public class Defect
    {
        public int DefectNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public string Name { get; set; }
        public DateTime DateUploaded { get; set; }
        public Image Picture { get; set; }
        public Image Picture2 { get; set; }
        public Image Picture3 { get; set; }
        public string Description { get; set; }      
        public string Comment { get; set; }
        public string Status { get; set; }

        public Defect() { }

        public Defect(int DefectNumber, int ApartmentNumber, string Name, DateTime DateUploaded, Image Picture, Image Picture2, Image Picture3, string Description, string Comment, string Status)
        {
            this.DefectNumber = DefectNumber;
            this.ApartmentNumber = ApartmentNumber;
            this.Name = Name;
            this.DateUploaded = DateUploaded;
            this.Picture = Picture;
            this.Picture2 = Picture2;
            this.Picture3 = Picture3;
            this.Description = Description;
            this.Comment = Comment;
            this.Status = Status;
        }
        public override string ToString()
        {
            return string.Format($"Defect Number: {DefectNumber}, Apartment Number: {ApartmentNumber}, Name: {Name}, Date Uploaded {DateUploaded}, {Picture}, {Picture2}, {Picture3}, Description: {Description}, Comment: {Comment}, Status: {Status}");
        }
    }
}

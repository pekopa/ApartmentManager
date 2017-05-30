using ApartmentManager.Annotations;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ApartmentManager.Model
{
    public class Defect : INotifyPropertyChanged
    {
        public int DefectId { get; set; }
        public int ApartmentId { get; set; }
        public string Name { get; set; }
        public DateTime UploadDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string MainPicture { get; set; }
        private ObservableCollection<DefectPicture> _pictures;
        private ObservableCollection<DefectComment> _comments;

        public Defect() { }

        public Defect(int defectId, int apartmentId, string name, DateTime uploadDate, string description, string status)
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

        public ObservableCollection<DefectPicture> Pictures
        {
            get => _pictures;
            set
            {
                _pictures = value;
                OnPropertyChanged(nameof(Pictures));
            }
        }

        public ObservableCollection<DefectComment> Comments
        {
            get => _comments;
            set
            {
                _comments = value;
                OnPropertyChanged(nameof(Comments));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}

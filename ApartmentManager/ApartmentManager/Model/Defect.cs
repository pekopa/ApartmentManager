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
        private ObservableCollection<DefectPicture> _pictures;
        private ObservableCollection<DefectComment> _comments;

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

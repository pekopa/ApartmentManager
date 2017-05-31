using ApartmentManager.Annotations;
using ApartmentManager.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ApartmentManager
{
    public class ApartmentChange : INotifyPropertyChanged
    {
        public int ChangeId { get; set; }
        public int ApartmentId { get; set; }
        public string Name { get; set; }
        public DateTime UploadDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        private ObservableCollection<ChangeDocument> _documents;
        private ObservableCollection<ChangeComment> _comments;

        public ObservableCollection<ChangeDocument> Documents
        {
            get => _documents;
            set
            {
                _documents = value;
                OnPropertyChanged(nameof(Documents));
            }
        }

        public ObservableCollection<ChangeComment> Comments
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

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ApartmentManager.Annotations;

namespace ApartmentManager.Model
{
    public class User : INotifyPropertyChanged
    {
        public string Username { get; set; }
        public int ApartmentId { get; set; }
        public string Password { get; set; }
        public bool IsBm { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string _picture { get; set; }
        public DateTimeOffset? MoveInDate { get; set; }
        public DateTimeOffset? MoveOutDate { get; set; }

        public string Picture
        {
            get => _picture;
            set
            {
                _picture = value;
                OnPropertyChanged(nameof(Picture));
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

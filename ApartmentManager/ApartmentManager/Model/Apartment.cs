using ApartmentManager.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ApartmentManager.Model
{
    public class Apartment : INotifyPropertyChanged
    {
        public int ApartmentId { get; set; }
        public double Size { get; set; }
        public int NumberOfRooms { get; set; }
        public double MonthlyCharge { get; set; }
        public int Floor { get; set; }
        public string Address { get; set; }
        private string _planPicture;

        public Apartment() { }

        public string PlanPicture
        {
            get => _planPicture;
            set
            {
                _planPicture = value;
                OnPropertyChanged(nameof(PlanPicture));
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

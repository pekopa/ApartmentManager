using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentManager.Annotations;
using ApartmentManager.Common;
using ApartmentManager.Model;

namespace ApartmentManager.ViewModel
{
    public class ApartmentViewModel : INotifyPropertyChanged
    {

        public CatalogSingleton CatalogSingleton { get; set; }
        private User _newUser;
        private Resident _newResident;
        public static int ApartmentNumber { get; set; }
        public Handler.ApartmentHandler ApartmentHandler { get; set; }

        //public ICommand CreateCommand { get; set; }
        //public ICommand DeleteCommand { get; set; }
        //public ICommand UpdateCommand { get; set; }
        //public ICommand ViewHotelRooms { get; set; }
        public ApartmentViewModel()
        {
            NewUser = new User();
            NewResident = new Resident();
            ApartmentHandler = new Handler.ApartmentHandler(this);
            CatalogSingleton = CatalogSingleton.Instance;
            ApartmentNumber = CatalogSingleton.User[0].ApartmentNr;
            //CreateCommand = new RelayCommand(HotelHandler.CreateHotel);
            //DeleteCommand = new RelayCommand(HotelHandler.DeleteHotel);
            //UpdateCommand = new RelayCommand(HotelHandler.UpdateHotel);
            //ViewHotelRooms = new RelayCommand();
        }
        public User NewUser
        {
            get => _newUser;
            set
            {
                _newUser = value;
                OnPropertyChanged();
            }
        }
        public Resident NewResident
        {
            get => _newResident;
            set
            {
                _newResident = value;
                OnPropertyChanged();
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

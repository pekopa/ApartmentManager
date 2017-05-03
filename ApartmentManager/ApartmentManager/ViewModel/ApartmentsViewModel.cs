using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ApartmentManager.Annotations;
using ApartmentManager.Model;

namespace ApartmentManager.ViewModel
{
    class ApartmentsViewModel : INotifyPropertyChanged
    {
        public ApartmentsCatalogSingleton ApartmentsCatalogSingleton { get; set; }
        private User _newUser;
        private Resident _newResident;
        private Apartment _newApartment;
        private Defect _newDefect;

        public static int ApartmentsNumber { get; set; }
        public Handler.BoardApartmentsHandler BoardApartmentsHandler { get; set; }

        public ApartmentsViewModel()
        {
            NewUser = new User();
            NewResident = new Resident();
            NewApartment = new Apartment();
            NewDefect = new Defect();
            BoardApartmentsHandler = new Handler.BoardApartmentsHandler(this);
            ApartmentsCatalogSingleton = ApartmentsCatalogSingleton.Instance;
            ApartmentsNumber = ApartmentsCatalogSingleton.User[0].ApartmentNr;
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

        public Apartment NewApartment
        {
            get => _newApartment;
            set
            {
                _newApartment = value;
                OnPropertyChanged();
            }
        }

        public Defect NewDefect
        {
            get => _newDefect;
            set
            {
                _newDefect = value;
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

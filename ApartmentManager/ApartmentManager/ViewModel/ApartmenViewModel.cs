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
using ApartmentManager.Handler;
using ApartmentManager.Model;

namespace ApartmentManager.ViewModel
{
    public class ApartmentViewModel : INotifyPropertyChanged
    {

        public CatalogSingleton CatalogSingleton { get; set; }
        private User _newUser;
        private Resident _newResident;
        public static int ApartmentNumber { get; set; }
        public Handler.ResidentsHandler ResidentsHandler { get; set; }

        public ICommand CreateResidentCommand { get; set; }
        public ICommand DeleteResidentCommand { get; set; }
        public ICommand UpdateResidentCommand { get; set; }

        public ApartmentViewModel()
        {
            NewUser = new User();
            NewResident = new Resident();
            ResidentsHandler = new Handler.ResidentsHandler(this);
            CatalogSingleton = CatalogSingleton.Instance;
            ApartmentNumber = CatalogSingleton.User[0].ApartmentNr;
            CreateResidentCommand = new RelayCommand(ResidentsHandler.CreateResident);
            DeleteResidentCommand = new RelayCommand(ResidentsHandler.DeleteResident);
            UpdateResidentCommand = new RelayCommand(ResidentsHandler.UpdateResident);
            ResidentsHandler.GetApartmentResidents();

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

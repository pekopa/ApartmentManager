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
using ApartmentManager.Persistency;
using ApartmentManager.Singletons;

namespace ApartmentManager.ViewModel
{
    public class ApartmentViewModel : INotifyPropertyChanged
    {
        public ApartmentHandler ApartmentHandler { get; set; }
        public CatalogSingleton CatalogSingleton { get; set; }
        public UserSingleton UserSingleton { get; set; }

        private User _newUser;
        private Resident _newResident;
        private Defect _newDefect;

        public static int ApartmentNumber { get; set; }
        

        public ICommand CreateResidentCommand { get; set; }
        public ICommand DeleteResidentCommand { get; set; }
        public ICommand UpdateResidentCommand { get; set; }
        public ICommand UploadResidentPhoto { get; set; }
        public ICommand UploadUserPhoto { get; set; }
        public ICommand UpdateUser { get; set; }

        public ApartmentViewModel()
        {
            NewUser = new User();
            NewResident = new Resident();
            
            ApartmentHandler = new ApartmentHandler(this);
            CatalogSingleton = CatalogSingleton.Instance;
            UserSingleton = UserSingleton.Instance;
            ApartmentNumber = UserSingleton.CurrentUser.ApartmentId;

            UpdateUser = new RelayCommand(ApartmentHandler.UpdateUser);
            UploadUserPhoto = new RelayCommand(ApartmentHandler.UploadUserPhoto);

            UploadResidentPhoto = new RelayCommand(ApartmentHandler.UploadResidentPhoto);
            CreateResidentCommand = new RelayCommand(ApartmentHandler.CreateResident);
            DeleteResidentCommand = new RelayCommand(ApartmentHandler.DeleteResident);
            UpdateResidentCommand = new RelayCommand(ApartmentHandler.UpdateResident);

            ApartmentHandler.GetApartmentResidents();
            ApartmentHandler.GetApartment();
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
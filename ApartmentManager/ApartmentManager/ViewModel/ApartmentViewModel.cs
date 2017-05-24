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
        private DefectPicture _selectedDefectPicture;

        
        
        public static int ServerResponse { get; set; }

        public ICommand CreateResidentCommand { get; set; }
        public ICommand DeleteResidentCommand { get; set; }
        public ICommand UpdateResidentCommand { get; set; }
        public ICommand UploadResidentPhoto { get; set; }
        public ICommand UploadUserPhoto { get; set; }
        public ICommand UpdateUser { get; set; }
        public ICommand DeleteDefectPicture { get; set; }
        public ICommand UploadDefectPicture { get; set; }
        public ICommand CreateDefect { get; set; }
        public ICommand DefectInfo { get; set; }
        
        public ApartmentViewModel()
        {
            NewUser = new User();
            NewResident = new Resident();
            NewDefect = new Defect();
            SelectedDefectPicture = new DefectPicture();

            ApartmentHandler = new ApartmentHandler(this);
            CatalogSingleton = CatalogSingleton.Instance;
            UserSingleton = UserSingleton.Instance;
            
            ////////// User relay commands//////////
            UpdateUser = new RelayCommand(ApartmentHandler.UpdateUser);
            UploadUserPhoto = new RelayCommand(ApartmentHandler.UploadUserPhoto);
            ////////// Resident relay commands//////////
            UploadResidentPhoto = new RelayCommand(ApartmentHandler.UploadResidentPhoto);
            CreateResidentCommand = new RelayCommand(ApartmentHandler.CreateResident);
            DeleteResidentCommand = new RelayCommand(ApartmentHandler.DeleteResident);
            UpdateResidentCommand = new RelayCommand(ApartmentHandler.UpdateResident);
            ////////// Defect relay commands//////////
            UploadDefectPicture = new RelayCommand(ApartmentHandler.UploadDefectPhoto);
            DeleteDefectPicture = new RelayCommand(ApartmentHandler.DeleteDefectPicture);
            CreateDefect = new RelayCommand(ApartmentHandler.CreateDefect, ApartmentHandler.CreateDefect_CanExecute);
            DefectInfo = new RelayCommand(ApartmentHandler.GetDefectInfo);
            
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
        public DefectPicture SelectedDefectPicture
        {
            get => _selectedDefectPicture;
            set
            {
                _selectedDefectPicture = value;
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
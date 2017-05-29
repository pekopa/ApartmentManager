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
        ////////// Handler //////////
        public ApartmentHandler ApartmentHandler { get; set; }
        ////////// Singletons //////////
        public CatalogSingleton CatalogSingleton { get; set; }
        public UserSingleton UserSingleton { get; set; }
        ////////// Store Data From Interface//////////
        private User _newUser;
        private Resident _newResident;
        private Defect _newDefect;
        private DefectPicture _selectedDefectPicture;
        private DefectComments _newDefectComment;
        ////////// Resident relay commands//////////
        public ICommand CreateResidentCommand { get; set; }
        public ICommand DeleteResidentCommand { get; set; }
        public ICommand UpdateResidentCommand { get; set; }
        public ICommand UploadResidentPhoto { get; set; }
        ////////// User relay commands//////////
        public ICommand UploadUserPhoto { get; set; }
        public ICommand UpdateUser { get; set; }
        ////////// Defect relay commands//////////
        public ICommand DeleteDefectPicture { get; set; }
        public ICommand UploadDefectPicture { get; set; }
        public ICommand CreateDefect { get; set; }
        public ICommand DefectInfo { get; set; }
        public ICommand CreateDefectComment { get; set; }
        ////////// Constructor //////////
        public ApartmentViewModel()
        {
            ////////// Store Data From Interface instance //////////
            NewUser = new User();
            NewResident = new Resident();
            NewDefect = new Defect();
            NewDefectComment = new DefectComments();
            SelectedDefectPicture = new DefectPicture();
            ////////// Handler //////////
            ApartmentHandler = new ApartmentHandler(this);
            ////////// Singletons //////////
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
            CreateDefectComment = new RelayCommand(ApartmentHandler.CreateDefectComment);
        }
        ////////// Store Data From Interface//////////
        public DefectComments NewDefectComment
        {
            get => _newDefectComment;
            set
            {
                _newDefectComment = value;
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
        ////////// INotifyPropertyChanged //////////
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
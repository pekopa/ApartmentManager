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
        //// For defect///
        private Defect _newDefect;
        private DefectPicture _selectedDefectPicture;
        private DefectComment _newDefectComment;
        //// For Changes///
        private ChangeComment _newChangeComment;
        private ApartmentChange _newApartmentChange;
        private ChangeDocument _selectedChangeDocument;
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
        public ICommand CreateDefectComment { get; set; }
        ////////// Change relay commands//////////
        public ICommand DeleteChangePicture { get; set; }
        public ICommand UploadChangePicture { get; set; }
        public ICommand CreateChangeComment { get; set; }
        public ICommand CreateChange { get; set; }
        ////////// Constructor //////////
        public ApartmentViewModel()
        {
            ////////// Store Data From Interface instance //////////
            NewUser = new User();
            NewResident = new Resident();

            NewDefect = new Defect();
            NewDefectComment = new DefectComment();
            SelectedDefectPicture = new DefectPicture();

            NewChangeComment = new ChangeComment();
            SelectedChangeDocument = new ChangeDocument();
            NewChange = new ApartmentChange();
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
            CreateDefectComment = new RelayCommand(ApartmentHandler.CreateDefectComment);
            ////////// changes relay commands//////////
            CreateChangeComment = new RelayCommand(ApartmentHandler.CreateChangeComment);
            DeleteChangePicture = new RelayCommand(ApartmentHandler.DeleteChangePicture);
            UploadChangePicture = new RelayCommand(ApartmentHandler.UploadChangePicture);
            CreateChange = new RelayCommand(ApartmentHandler.CreateChange, ApartmentHandler.CreateChange_CanExecute);
        }
        ////////// Store Data From Interface for defects//////////
        public DefectComment NewDefectComment
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
        public DefectPicture SelectedDefectPicture
        {
            get => _selectedDefectPicture;
            set
            {
                _selectedDefectPicture = value;
                OnPropertyChanged();
            }
        }
        ////////// Store Data From Interface for Changes//////////
        public ChangeComment NewChangeComment
        {
            get => _newChangeComment;
            set
            {
                _newChangeComment = value;
                OnPropertyChanged();
            }
        }
        public ChangeDocument SelectedChangeDocument
        {
            get => _selectedChangeDocument;
            set
            {
                _selectedChangeDocument = value;
                OnPropertyChanged();
            }
        }
        public ApartmentChange NewChange
        {
            get => _newApartmentChange;
            set
            {
                _newApartmentChange = value;
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

        ////////// INotifyPropertyChanged //////////
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ApartmentManager.Annotations;
using ApartmentManager.Common;
using ApartmentManager.Model;
using ApartmentManager.Singletons;
using ApartmentManager.Handler;
using System.Collections.Generic;

namespace ApartmentManager.ViewModel
{
    public class BmViewModel : INotifyPropertyChanged
    {
        public BmSingleton BmSingleton { get; } = BmSingleton.Instance;
        public BmHandler BmHandler { get; }

        public int[] FloorNumbers { get; } = new int[] { 0, 1, 2, 3, 4 };
        public int SelectedFloor { get; set; }

        public ICommand CreateApartmentCommand { get; }
        public ICommand DeleteApartmentCommand { get; }
        public ICommand UpdateApartmentCommand { get; }
        public ICommand UploadApartmentPlanCommand { get; }
        public ICommand ClearApartmentTemplateCommand { get; }
        public ICommand GetApartmentsCommand { get; }

        public ICommand CreateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand UploadUserPhotoCommand { get; }
        public ICommand ClearUserTemplateCommand { get; }

        public ICommand CreateResidentCommand { get; }
        public ICommand DeleteResidentCommand { get; }
        public ICommand UpdateResidentCommand { get; }
        public ICommand UploadResidentPhotoCommand { get; }
        public ICommand ClearResidentTemplateCommand { get; }

        public ICommand CreateDefectCommand { get; }
        public ICommand DeleteDefectCommand { get; }
        public ICommand UpdateDefectCommand { get; }
        public ICommand ClearDefectTemplateCommand { get; }
        public ICommand GetDefectsCommand { get; }
        public ICommand UploadDefectPictureCommand { get; }
        public ICommand UploadDefectPictureTempCommand { get; }
        public ICommand DeleteDefectPictureCommand { get; }
        public ICommand DeleteDefectPictureTempCommand { get; }
        public ICommand CreateDefectCommentCommand { get; }

        private static Apartment _apartmentTemplate = new Apartment();
        private static User _userTemplate = new User();
        private static Resident _residentTemplate = new Resident();
        private static Defect _defectTemplate = new Defect();
        private static DefectPicture _selectedDefectPicture = new DefectPicture();
        private static List<DefectPicture> _deletedDefectPictures = new List<DefectPicture>();
        private static List<DefectPicture> _addedDefectPictures = new List<DefectPicture>();
        private static DefectComment _newDefectComment = new DefectComment();

        public BmViewModel()
        {
            BmHandler = new BmHandler(this);

            CreateApartmentCommand = new RelayCommand(BmHandler.CreateApartment);
            DeleteApartmentCommand = new RelayCommand(BmHandler.DeleteApartment);
            UpdateApartmentCommand = new RelayCommand(BmHandler.UpdateApartment);
            UploadApartmentPlanCommand = new RelayCommand(BmHandler.UploadApartmentPlan);
            ClearApartmentTemplateCommand = new RelayCommand(BmHandler.ClearApartmentTemplate);
            GetApartmentsCommand = new RelayCommand(BmHandler.GetApartments);

            CreateUserCommand = new RelayCommand(BmHandler.CreateUser);
            DeleteUserCommand = new RelayCommand(BmHandler.DeleteUser);
            UpdateUserCommand = new RelayCommand(BmHandler.UpdateUser);
            UploadUserPhotoCommand = new RelayCommand(BmHandler.UploadUserPhoto);
            ClearUserTemplateCommand = new RelayCommand(BmHandler.ClearUserTemplate);

            CreateResidentCommand = new RelayCommand(BmHandler.CreateResident);
            DeleteResidentCommand = new RelayCommand(BmHandler.DeleteResident);
            UpdateResidentCommand = new RelayCommand(BmHandler.UpdateResident);
            UploadResidentPhotoCommand = new RelayCommand(BmHandler.UploadResidentPhoto);
            ClearResidentTemplateCommand = new RelayCommand(BmHandler.ClearResidentTemplate);

            CreateDefectCommand = new RelayCommand(BmHandler.CreateDefect);
            DeleteDefectCommand = new RelayCommand(BmHandler.DeleteDefect);
            UpdateDefectCommand = new RelayCommand(BmHandler.UpdateDefect);
            ClearDefectTemplateCommand = new RelayCommand(BmHandler.ClearDefectTemplate);
            UploadDefectPictureCommand = new RelayCommand(BmHandler.UploadDefectPicture);
            DeleteDefectPictureCommand = new RelayCommand(BmHandler.DeleteDefectPicture);
            DeleteDefectPictureTempCommand = new RelayCommand(BmHandler.DeleteDefectPictureTemp);
            GetDefectsCommand = new RelayCommand(BmHandler.GetDefects);
            CreateDefectCommentCommand = new RelayCommand(BmHandler.CreateDefectComment);
        }

        public Apartment ApartmentTemplate
        {
            get => _apartmentTemplate;
            set
            {
                _apartmentTemplate = value;
                OnPropertyChanged();
            }
        }

        public User UserTemplate
        {
            get => _userTemplate;
            set
            {
                _userTemplate = value;
                OnPropertyChanged();
            }
        }

        public Resident ResidentTemplate
        {
            get => _residentTemplate;
            set
            {
                _residentTemplate = value;
                OnPropertyChanged();
            }
        }

        public Defect DefectTemplate
        {
            get => _defectTemplate;
            set
            {
                _defectTemplate = value;
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

        public List<DefectPicture> DeletedDefectPictures
        {
            get => _deletedDefectPictures;
            set
            {
                _deletedDefectPictures = value;
            }
        }

        public List<DefectPicture> AddedDefectPictures
        {
            get => _addedDefectPictures;
            set
            {
                _addedDefectPictures = value;
            }
        }

        public DefectComment NewDefectComment
        {
            get => _newDefectComment;
            set
            {
                _newDefectComment = value;
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

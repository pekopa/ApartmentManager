using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ApartmentManager.Annotations;
using ApartmentManager.Common;
using ApartmentManager.Model;
using ApartmentManager.Singletons;
using ApartmentManager.Handler;

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

        public ICommand CreateResidentCommand { get; }
        public ICommand DeleteResidentCommand { get; }
        public ICommand UpdateResidentCommand { get; }
        public ICommand UploadResidentPhotoCommand { get; }
        public ICommand ClearResidentTemplateCommand { get; }

        private static Apartment _apartmentTemplate = new Apartment();
        private static Resident _residentTemplate = new Resident();

        public BmViewModel()
        {
            BmHandler = new BmHandler(this);

            CreateApartmentCommand = new RelayCommand(BmHandler.CreateApartment);
            DeleteApartmentCommand = new RelayCommand(BmHandler.DeleteApartment);
            UpdateApartmentCommand = new RelayCommand(BmHandler.UpdateApartment);
            UploadApartmentPlanCommand = new RelayCommand(BmHandler.UploadApartmentPlan);
            ClearApartmentTemplateCommand = new RelayCommand(BmHandler.ClearApartmentTemplate);
            GetApartmentsCommand = new RelayCommand(BmHandler.GetApartments);

            CreateResidentCommand = new RelayCommand(BmHandler.CreateResident);
            DeleteResidentCommand = new RelayCommand(BmHandler.DeleteResident);
            UpdateResidentCommand = new RelayCommand(BmHandler.UpdateResident);
            UploadResidentPhotoCommand = new RelayCommand(BmHandler.UploadResidentPhoto);
            ClearResidentTemplateCommand = new RelayCommand(BmHandler.ClearResidentTemplate);
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

        public Resident ResidentTemplate
        {
            get => _residentTemplate;
            set
            {
                _residentTemplate = value;
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

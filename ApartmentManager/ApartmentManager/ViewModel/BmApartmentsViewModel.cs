using ApartmentManager.Annotations;
using ApartmentManager.Common;
using ApartmentManager.Handler;
using ApartmentManager.Model;
using ApartmentManager.Singletons;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ApartmentManager.ViewModel
{
    public class BmApartmentsViewModel : INotifyPropertyChanged
    {
        public BmSingleton BmSingleton { get; } = BmSingleton.Instance;
        public BmApartmentsHandler BmApartmentsHandler { get; }

        public int[] FloorNumbers { get; } = new int[] { 0, 1, 2, 3, 4 };
        public int SelectedFloor { get; set; }

        public ICommand CreateApartmentCommand { get; }
        public ICommand DeleteApartmentCommand { get; }
        public ICommand UpdateApartmentCommand { get; }
        public ICommand UploadApartmentPlanCommand { get; }
        public ICommand ClearApartmentTemplateCommand { get; }
        public ICommand GetApartmentsCommand { get; }

        private static Apartment _apartmentTemplate = new Apartment();

        public BmApartmentsViewModel()
        {
            BmApartmentsHandler = new BmApartmentsHandler(this);

            CreateApartmentCommand = new RelayCommand(BmApartmentsHandler.CreateApartment);
            DeleteApartmentCommand = new RelayCommand(BmApartmentsHandler.DeleteApartment);
            UpdateApartmentCommand = new RelayCommand(BmApartmentsHandler.UpdateApartment);
            UploadApartmentPlanCommand = new RelayCommand(BmApartmentsHandler.UploadApartmentPlan);
            ClearApartmentTemplateCommand = new RelayCommand(BmApartmentsHandler.ClearApartmentTemplate);
            GetApartmentsCommand = new RelayCommand(BmApartmentsHandler.GetApartments);
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

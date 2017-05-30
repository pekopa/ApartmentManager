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
    public class BmResidentsViewModel : INotifyPropertyChanged
    {
        public BmSingleton BmSingleton { get; } = BmSingleton.Instance;
        public BmResidentsHandler BmResidentsHandler { get; }

        public ICommand CreateResidentCommand { get; }
        public ICommand DeleteResidentCommand { get; }
        public ICommand UpdateResidentCommand { get; }
        public ICommand UploadResidentPhotoCommand { get; }
        public ICommand ClearResidentTemplateCommand { get; }

        private static Resident _residentTemplate = new Resident();

        public BmResidentsViewModel()
        {
            BmResidentsHandler = new BmResidentsHandler(this);

            CreateResidentCommand = new RelayCommand(BmResidentsHandler.CreateResident);
            DeleteResidentCommand = new RelayCommand(BmResidentsHandler.DeleteResident);
            UpdateResidentCommand = new RelayCommand(BmResidentsHandler.UpdateResident);
            UploadResidentPhotoCommand = new RelayCommand(BmResidentsHandler.UploadResidentPhoto);
            ClearResidentTemplateCommand = new RelayCommand(BmResidentsHandler.ClearResidentTemplate);
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


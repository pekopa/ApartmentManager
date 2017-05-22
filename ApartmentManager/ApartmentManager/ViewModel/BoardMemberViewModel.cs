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
using ApartmentManager.Model;

namespace ApartmentManager.ViewModel
{
    public class BoardMemberViewModel : INotifyPropertyChanged
    {
        public BoardMemberCatalogSingleton BoardMemberCatalogSingleton { get; set; }

        public UserSingleton UserSingleton { get; set; }
        private User _newUser;
        private Resident _newResident;
        private Apartment _newApartment;
        private Defect _newDefect;

        public static int ApartmentsNumber { get; set; }
        public Handler.BoardMemberHandler BoardMemberHandler { get; set; }

        public Handler.BoardResidentsHandler BoardResidentsHandler { get; set; }

        public ICommand CreateApartmentCommand { get; set; }
        public ICommand DeleteApartmentCommand { get; set; }
        public ICommand UpdateApartmentCommand { get; set; }

        public ICommand DeleteDefectCommand { get; set; }

        public BoardMemberViewModel()
        {
            NewUser = new User();
            NewResident = new Resident();
            NewApartment = new Apartment();
            NewDefect = new Defect();

            BoardResidentsHandler = new Handler.BoardResidentsHandler(this);
            BoardMemberHandler = new Handler.BoardMemberHandler(this);
            BoardMemberCatalogSingleton = BoardMemberCatalogSingleton.Instance;
            UserSingleton = UserSingleton.Instance;
            ApartmentsNumber = UserSingleton.CurrentUser.ApartmentId;

            CreateApartmentCommand = new RelayCommand(BoardMemberHandler.CreateApartment);
            DeleteApartmentCommand = new RelayCommand(BoardMemberHandler.DeleteApartment);
            UpdateApartmentCommand = new RelayCommand(BoardMemberHandler.UpdateApartment);
            BoardMemberHandler.GetApartments();
            BoardResidentsHandler.GetApartmentsResidents();     
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

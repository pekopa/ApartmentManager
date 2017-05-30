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
    public class BmUsersViewModel : INotifyPropertyChanged
    {
        public BmSingleton BmSingleton { get; } = BmSingleton.Instance;
        public BmUsersHandler BmUsersHandler { get; }

        public ICommand CreateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand UploadUserPhotoCommand { get; }
        public ICommand ClearUserTemplateCommand { get; }

        private static User _userTemplate = new User();

        public BmUsersViewModel()
        {
            BmUsersHandler = new BmUsersHandler(this);

            CreateUserCommand = new RelayCommand(BmUsersHandler.CreateUser);
            DeleteUserCommand = new RelayCommand(BmUsersHandler.DeleteUser);
            UpdateUserCommand = new RelayCommand(BmUsersHandler.UpdateUser);
            UploadUserPhotoCommand = new RelayCommand(BmUsersHandler.UploadUserPhoto);
            ClearUserTemplateCommand = new RelayCommand(BmUsersHandler.ClearUserTemplate);
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

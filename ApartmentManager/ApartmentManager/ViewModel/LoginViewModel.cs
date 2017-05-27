using ApartmentManager.Common;
using ApartmentManager.Handler;
using System.Windows.Input;

namespace ApartmentManager.ViewModel
{
   public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand LogInCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        private LoginHandler loginHandler;

        public LoginViewModel()
        {
            loginHandler = new LoginHandler(this);
            LogInCommand = new RelayCommand(loginHandler.LogIn);
            LogOutCommand = new RelayCommand(loginHandler.LogOut);
        }
    }
}

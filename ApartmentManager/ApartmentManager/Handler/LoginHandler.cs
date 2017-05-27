using ApartmentManager.Model;
using ApartmentManager.Persistency;
using Newtonsoft.Json;
using System;
using ApartmentManager.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ApartmentManager.View;
using Windows.UI.Popups;
using ApartmentManager.Singletons;

namespace ApartmentManager.Handler
{
    public class LoginHandler
    {

        private LoginViewModel _vm;

        public LoginHandler(LoginViewModel vm)
        {
            _vm = vm;
        }

        public void LogIn()
        {
            try
            {
                string serializedUser = ApiClient.GetData($"api/Users/{_vm.Username}");
                if (serializedUser != null)
                {
                    User user = JsonConvert.DeserializeObject<User>(serializedUser);
                    if (user.Password == _vm.Password)
                    {
                        UserSingleton.Instance.CurrentUser = user;
                        NavigateToMainPage();
                    }
                    else throw new Exception("Wrong password!");
                }
                else throw new Exception("Wrong username!");
            }
            catch (Exception ex)
            {
                var msg = new MessageDialog(ex.Message).ShowAsync();
            }
        }

        public void LogOut()
        {
            UserSingleton.Instance.CurrentUser = null;
            NavigateToLoginPage();
        }

        private void NavigateToMainPage()
        {
            AppShell appShell = Window.Current.Content as AppShell;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (appShell == null)
            {
                // Create a AppShell to act as the navigation context and navigate to the first page
                appShell = new AppShell();

                // Set the default language
                appShell.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

            }

            // Place our app shell in the current Window
            Window.Current.Content = appShell;

            if (appShell.AppFrame.Content == null)
            {
                // When the navigation stack isn't restored, navigate to the first page
                // suppressing the initial entrance animation.
                if (UserSingleton.Instance.CurrentUser.IsBm)
                {
                    BmViewModel bvm = new BmViewModel();
                    bvm.BmHandler.GetApartments();
                    appShell.AppFrame.Navigate(typeof(BmMainPage));
                }
                else
                {
                    ApartmentViewModel avm = new ApartmentViewModel();
                    avm.ApartmentHandler.GetApartmentResidents();
                    avm.ApartmentHandler.GetApartment();
                    avm.ApartmentHandler.GetApartmentDefects();
                    appShell.AppFrame.Navigate(typeof(ApartmentPage));
                }
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

        private void NavigateToLoginPage()
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            rootFrame.Navigate(typeof(LoginPage));
            Window.Current.Activate();
        }
    }
}

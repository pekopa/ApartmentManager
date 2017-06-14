using ApartmentManager.Model;
using ApartmentManager.Persistency;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
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
            if (UserSingleton.Instance.CurrentUser.IsBm)
            {
                BmSingleton.Instance.Apartments = new ObservableCollection<Apartment>();
                BmSingleton.Instance.Users = new ObservableCollection<User>();
                BmSingleton.Instance.Residents = new ObservableCollection<Resident>();
                BmSingleton.Instance.Defects = new ObservableCollection<Defect>();
                BmSingleton.Instance.Changes = new ObservableCollection<Change>();
            }
            else
            {
                CatalogSingleton.Instance.SelectedChange = new Change();
                CatalogSingleton.Instance.Apartment = new Apartment();
                CatalogSingleton.Instance.Changes = new ObservableCollection<Change>();
                CatalogSingleton.Instance.Defects = new ObservableCollection<Defect>();
                CatalogSingleton.Instance.Residents = new ObservableCollection<Resident>();
                CatalogSingleton.Instance.SelectedDefect = new Defect();
            }
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
                    appShell.AppFrame.Navigate(typeof(BmMainPage));
                }
                else
                {
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

using ApartmentManager.Common;
using ApartmentManager.Handler;
using ApartmentManager.Model;
using ApartmentManager.View;
using System;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ApartmentManager.ViewModel
{
   public class LoginViewModel
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        public bool IsPasswordCorrect { get; set; }
        public ICommand LogInCommand { get; set; }
        public ICommand LogOutCommand { get; set; }

        public LoginViewModel()
        {
            LogInCommand = new RelayCommand(LogIn);
            LogOutCommand = new RelayCommand(LogOut);
        }

        private void LogIn()
        {
            try
            {
                LoginHandler.LogIn(Username, Password);
                NavigateToMainPage();
            }
            catch(Exception ex)
            {
                var msg = new MessageDialog(ex.Message);
                msg.ShowAsync();
            }
        }

        private void LogOut()
        {
            LoginHandler.LogOut();
            NavigateToLoginPage();
            Username = null;
            Password = null;
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
                if (UserSingleton.Instance.CurrentUser.Type == "B") appShell.AppFrame.Navigate(typeof(BoardMembersMainPage));
                else appShell.AppFrame.Navigate(typeof(ApartmentPage));
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

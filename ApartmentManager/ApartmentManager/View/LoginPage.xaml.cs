using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ApartmentManager.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void click(object sender, RoutedEventArgs e)
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
                appShell.AppFrame.Navigate(typeof(BoardMembersPage));
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }
    }
}

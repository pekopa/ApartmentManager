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
    public sealed partial class ApartmentPage : Page
    {
        public ApartmentPage()
        {
            this.InitializeComponent();
        }

        private void GotoApartmentPlanPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ApartmentPlanPage));
        }

        private void GotoPernalInfoPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PersonalInfoPage));
        }

        private void ResidentPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ApartmentResidentsPage));
        }

        private void DefectPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ApartmentDefectPage));
        }

        private void GotoChangesPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ApartmentChangesPage));
        }
    }
}

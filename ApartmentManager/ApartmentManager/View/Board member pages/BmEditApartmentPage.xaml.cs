using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace ApartmentManager.View
{
    /// <summary>
    /// Page for editing apartment.
    /// </summary>
    public sealed partial class BmEditApartmentPage : Page
    {
        private readonly SystemNavigationManager _currentView = SystemNavigationManager.GetForCurrentView();

        public BmEditApartmentPage()
        {
            InitializeComponent();
            _currentView.BackRequested += OnBackRequested;
            _currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame.Navigate(typeof(BmApartmentsPage));
            _currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }
    }
}

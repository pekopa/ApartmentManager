using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace ApartmentManager.View
{
    /// <summary>
    /// Page for adding new apartment.
    /// </summary>
    public sealed partial class BmCreateApartmentPage : Page
    {
        private readonly SystemNavigationManager _currentView = SystemNavigationManager.GetForCurrentView();

        public BmCreateApartmentPage()
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

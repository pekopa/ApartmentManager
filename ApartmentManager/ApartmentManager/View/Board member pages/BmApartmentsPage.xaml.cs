using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ApartmentManager.View
{
    /// <summary>
    /// Page for managing apartments.
    /// </summary>
    public sealed partial class BmApartmentsPage : Page
    {
        public BmApartmentsPage()
        {
            InitializeComponent();
        }

        private void SelectItem(object sender, RoutedEventArgs e)
        {
            var item = ((Grid)((Button)sender).Parent).DataContext;
            var container = (ListViewItem)ApartmentsList.ContainerFromItem(item);

            container.IsSelected = true;
        }

        private void GoToCreateApartmentPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BmCreateApartmentPage));
        }
    }
}

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ApartmentManager.View
{
    /// <summary>
    /// Page for managing apartment changes.
    /// </summary>
    public sealed partial class BmChangesPage : Page
    {
        public BmChangesPage()
        {
            InitializeComponent();
        }

        private void SelectItem(object sender, RoutedEventArgs e)
        {
            var item = ((Grid)((Button)sender).Parent).DataContext;
            var container = (ListViewItem)ChangesList.ContainerFromItem(item);

            container.IsSelected = true;
        }

        private void GoToCreateChangePage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BmCreateChangePage));
        }
    }
}

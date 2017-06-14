using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ApartmentManager.View
{
    /// <summary>
    /// Page for managing defects.
    /// </summary>
    public sealed partial class BmDefectsPage : Page
    {
        public BmDefectsPage()
        {
            InitializeComponent();
        }

        private void SelectItem(object sender, RoutedEventArgs e)
        {
            var item = ((Grid)((Button)sender).Parent).DataContext;
            var container = (ListViewItem)DefectsList.ContainerFromItem(item);

            container.IsSelected = true;
        }

        private void GoToCreateDefectPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BmCreateDefectPage));
        }
    }
}

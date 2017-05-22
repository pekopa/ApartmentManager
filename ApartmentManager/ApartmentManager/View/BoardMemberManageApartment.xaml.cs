using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ApartmentManager.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ApartmentManager.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BoardMemberManageApartment : Page
    {
        public BoardMemberManageApartment()
        {
            this.InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(InfoForBoardMembers));
        }

        private void CreateApartment(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BoardMemberCreateApartmentPage));
        }

        //private bool ApartmentFilter(object item)
        //{
        //    if (String.IsNullOrEmpty(TextFilter.Text))
        //        return true;
        //    else
        //        return ((item as Apartment).BoardMemberCatalogSingleton.IndexOf(TextFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        //}

        //private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        //{
        //    CollectionViewSource.GetDefaultView(lvUsers.ItemsSource).Refresh();
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using ApartmentManager.Model;
using ApartmentManager.Persistency;
using ApartmentManager.ViewModel;

namespace ApartmentManager.Handler
{
     class BoardApartmentsHandler
    {
        public ApartmentsViewModel ApartmentsViewModel { get; set; }

        public BoardApartmentsHandler(ApartmentsViewModel apartmentsViewModel)
        {
            ApartmentsViewModel = apartmentsViewModel;
        }

        public void CreateApartment()
        {
            try
            {
                Apartment apartment = new Apartment();
                apartment.ApartmentNumber = ApartmentsViewModel.ApartmentsNumber;
              
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
    }
}

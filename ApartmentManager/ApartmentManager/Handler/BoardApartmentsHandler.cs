using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public void GetApartments()
        {
            Apartment apartment = new Apartment();
            apartment.ApartmentNumber = ApartmentsViewModel.ApartmentsNumber;

            var apartmentList = new PersistenceFacade().GetApartments(apartment);
            ApartmentsViewModel.ApartmentsCatalogSingleton.Apartment.Clear();

            foreach (var apartments in apartmentList)
            {
                ApartmentsViewModel.ApartmentsCatalogSingleton.Apartment.Add(apartments);
            }
        }

        public void CreateApartment()
        {
            try
            {
                Apartment apartment = new Apartment();
                apartment.ApartmentNumber = ApartmentsViewModel.ApartmentsCatalogSingleton.Apartment.Count;
                apartment.ApartmentNumber++;
                apartment.ApartmentNumber = ApartmentsViewModel.ApartmentsNumber;
                apartment.Address = ApartmentsViewModel.NewApartment.Address;
                apartment.Floor = ApartmentsViewModel.NewApartment.Floor;
                apartment.MonthlyCharge = ApartmentsViewModel.NewApartment.MonthlyCharge;
                apartment.NumberOfRooms = ApartmentsViewModel.NewApartment.NumberOfRooms;
                apartment.Size = ApartmentsViewModel.NewApartment.Size;

                new PersistenceFacade().CreateApartment(apartment);

                var apartmentslist = new PersistenceFacade().GetApartments(apartment);
                ApartmentsViewModel.ApartmentsCatalogSingleton.Apartment.Clear();

                foreach (var apartmento in apartmentslist)
                {
                    ApartmentsViewModel.ApartmentsCatalogSingleton.Apartment.Add(apartmento);
                }

                //ApartmentsViewModel.ApartmentsCatalogSingleton.Apartment.Clear(apartment);
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
    }
}

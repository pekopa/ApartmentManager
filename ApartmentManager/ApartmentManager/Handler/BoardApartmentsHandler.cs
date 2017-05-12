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
using Newtonsoft.Json;

namespace ApartmentManager.Handler
{
   public class BoardApartmentsHandler
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

            var apartmentsFromDatabase = ApiClient.GetData("api/apartmentsList/" + apartment.ApartmentNumber);
            IEnumerable<Apartment> apartmentslist = JsonConvert.DeserializeObject<IEnumerable<Apartment>>(apartmentsFromDatabase);

            ApartmentsViewModel.ApartmentsCatalogSingleton.Apartment.Clear();
            ApartmentsViewModel.NewApartment = new Apartment();
            foreach (var apartment2 in apartmentslist)
            {
                ApartmentsViewModel.ApartmentsCatalogSingleton.Apartment.Add(apartment2);
            }
        }

        public void CreateApartment()
        {
            try
            {
                Apartment apartment = new Apartment();
                apartment.ApartmentNumber = ApartmentsViewModel.ApartmentsNumber;
                apartment.Address = ApartmentsViewModel.NewApartment.Address;
                apartment.Floor = ApartmentsViewModel.NewApartment.Floor;
                apartment.MonthlyCharge = ApartmentsViewModel.NewApartment.MonthlyCharge;
                apartment.NumberOfRooms = ApartmentsViewModel.NewApartment.NumberOfRooms;
                apartment.Size = ApartmentsViewModel.NewApartment.Size;

                ApiClient.PostData("api/apartments/", apartment);

                var apartmentsFromDatabase = ApiClient.GetData("api/apartmentsList/" + apartment.ApartmentNumber);
                IEnumerable<Apartment> apartmentlist = JsonConvert.DeserializeObject<IEnumerable<Apartment>>(apartmentsFromDatabase);

                ApartmentsViewModel.ApartmentsCatalogSingleton.Apartment.Clear();
                ApartmentsViewModel.NewApartment = new Apartment();
                foreach (var apartment2 in apartmentlist)
                {
                    ApartmentsViewModel.ApartmentsCatalogSingleton.Apartment.Add(apartment2);
                }

            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
    }
}

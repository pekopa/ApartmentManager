using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
   public class BoardMemberHandler
    {
        public BoardMemberViewModel BoardMemberViewModel { get; set; }

        public BoardMemberHandler(BoardMemberViewModel boardMemberViewModel)
        {
            BoardMemberViewModel = boardMemberViewModel;
        }

        public void GetApartments()
        {
            Apartment apartment= new Apartment();
            apartment.ApartmentNumber = BoardMemberViewModel.ApartmentsNumber;

            var apartmentsFromDatabase = ApiClient.GetData("api/Apartments/");
            IEnumerable<Apartment> apartmentslist = JsonConvert.DeserializeObject<IEnumerable<Apartment>>(apartmentsFromDatabase);

            BoardMemberViewModel.BoardMemberCatalogSingleton.Apartment.Clear();
            BoardMemberViewModel.NewApartment = new Apartment();
            foreach (var apartment2 in apartmentslist)
            {
                BoardMemberViewModel.BoardMemberCatalogSingleton.Apartment.Add(apartment2);
            }
        }

        public void CreateApartment()
        {
            try
            {
                Apartment apartment = new Apartment();
                apartment.ApartmentNumber = BoardMemberViewModel.ApartmentsNumber;
                apartment.Address = BoardMemberViewModel.NewApartment.Address;
                apartment.Floor = BoardMemberViewModel.NewApartment.Floor;
                apartment.MonthlyCharge = BoardMemberViewModel.NewApartment.MonthlyCharge;
                apartment.NumberOfRooms = BoardMemberViewModel.NewApartment.NumberOfRooms;
                apartment.Size = BoardMemberViewModel.NewApartment.Size;

                ApiClient.PostData("api/Apartments/", apartment);

                var apartmentsFromDatabase = ApiClient.GetData("api/Apartments/" + apartment.ApartmentNumber);
                IEnumerable<Apartment> apartmentlist = JsonConvert.DeserializeObject<IEnumerable<Apartment>>(apartmentsFromDatabase);

                BoardMemberViewModel.BoardMemberCatalogSingleton.Apartment.Clear();
                BoardMemberViewModel.NewApartment = new Apartment();
                foreach (var apartment2 in apartmentlist)
                {
                    BoardMemberViewModel.BoardMemberCatalogSingleton.Apartment.Add(apartment2);
                }
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
        public void UpdateApartment()
        {
            try
            {
                Apartment apartment = new Apartment();
                apartment.ApartmentNumber = BoardMemberViewModel.ApartmentsNumber;
                apartment.Address = BoardMemberViewModel.NewApartment.Address;
                apartment.Floor = BoardMemberViewModel.NewApartment.Floor;
                apartment.MonthlyCharge = BoardMemberViewModel.NewApartment.MonthlyCharge;
                apartment.NumberOfRooms = BoardMemberViewModel.NewApartment.NumberOfRooms;
                apartment.Size = BoardMemberViewModel.NewApartment.Size;

                ApiClient.PutData("api/Apartments/" + apartment.ApartmentNumber, apartment);
                var apartmentsFromDatabase = ApiClient.GetData("api/Apartments/" + apartment.ApartmentNumber);
                IEnumerable<Apartment> apartmentslist = JsonConvert.DeserializeObject<IEnumerable<Apartment>>(apartmentsFromDatabase);

                BoardMemberViewModel.BoardMemberCatalogSingleton.Apartment.Clear();
                BoardMemberViewModel.NewApartment = new Apartment();
                foreach (var apartment2 in apartmentslist)
                {
                    BoardMemberViewModel.BoardMemberCatalogSingleton.Apartment.Add(apartment2);
                }
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
        public void DeleteApartment()
        {
            try
            {
                Apartment apartment = new Apartment();
                apartment.ApartmentNumber = BoardMemberViewModel.ApartmentsNumber;
                apartment.Address = BoardMemberViewModel.NewApartment.Address;
                apartment.Floor = BoardMemberViewModel.NewApartment.Floor;
                apartment.MonthlyCharge = BoardMemberViewModel.NewApartment.MonthlyCharge;
                apartment.NumberOfRooms = BoardMemberViewModel.NewApartment.NumberOfRooms;
                apartment.Size = BoardMemberViewModel.NewApartment.Size;

                ApiClient.DeleteData("api/Apartments/" + apartment.ApartmentNumber);

                var apartmentsFromDatabase = ApiClient.GetData("api/Apartments/" + apartment.ApartmentNumber);
                IEnumerable<Apartment> apartmentslist = JsonConvert.DeserializeObject<IEnumerable<Apartment>>(apartmentsFromDatabase);

                BoardMemberViewModel.BoardMemberCatalogSingleton.Apartment.Clear();
                BoardMemberViewModel.NewApartment = new Apartment();
                foreach (var apartment2 in apartmentslist)
                {
                    BoardMemberViewModel.BoardMemberCatalogSingleton.Apartment.Add(apartment2);
                }
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
    }
}

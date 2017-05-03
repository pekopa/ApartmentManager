using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using ApartmentManager.Model;
using ApartmentManager.ViewModel;

namespace ApartmentManager.Handler
{
    public class ResidentsHandler
    {
        public ApartmentViewModel ApartmentViewModel { get; set; }

        public ResidentsHandler(ApartmentViewModel apartmenViewModel)
        {
            ApartmentViewModel = apartmenViewModel;
        }

        public void CreateResident()
        {
            try
            {
                Resident resident = new Resident();
                resident.ApartmentNr = ApartmentViewModel.ApartmentNumber;
                resident.Name = ApartmentViewModel.NewResident.Name;
                resident.LastName = ApartmentViewModel.NewResident.LastName;
                resident.BirthDate = ApartmentViewModel.NewResident.BirthDate;
                resident.Email = ApartmentViewModel.NewResident.Email;
                resident.Picture = ApartmentViewModel.NewResident.Picture;
                resident.Phone = ApartmentViewModel.NewResident.Phone;

                //new PersistenceFacade().CreateHotel(hotel);

                ////HotelViewModel.Hotels.Hotels.Add(hotel);
                //var hotelsFromDatabase = new PersistenceFacade().GetHotels();

                //HotelViewModel.HotelCatalogSingleton.Hotels.Clear();
                //foreach (var hotel1 in hotelsFromDatabase)
                //{
                //    ApartmentViewModel.HotelCatalogSingleton.Hotels.Add(hotel1);

                //}
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }

        public void DeleteResident()
        {
            try
            {
                Resident resident = new Resident();
                resident.ApartmentNr = ApartmentViewModel.ApartmentNumber;
                resident.Name = ApartmentViewModel.NewResident.Name;
                resident.LastName = ApartmentViewModel.NewResident.LastName;
                resident.BirthDate = ApartmentViewModel.NewResident.BirthDate;
                resident.Email = ApartmentViewModel.NewResident.Email;
                resident.Picture = ApartmentViewModel.NewResident.Picture;
                resident.Phone = ApartmentViewModel.NewResident.Phone;

                //new PersistenceFacade().CreateHotel(hotel);

                ////HotelViewModel.Hotels.Hotels.Add(hotel);
                //var hotelsFromDatabase = new PersistenceFacade().GetHotels();

                //HotelViewModel.HotelCatalogSingleton.Hotels.Clear();
                //foreach (var hotel1 in hotelsFromDatabase)
                //{
                //    ApartmentViewModel.HotelCatalogSingleton.Hotels.Add(hotel1);

                //}
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
        public void UpdateResident()
        {
            try
            {
                Resident resident = new Resident();
                resident.ApartmentNr = ApartmentViewModel.ApartmentNumber;
                resident.Name = ApartmentViewModel.NewResident.Name;
                resident.LastName = ApartmentViewModel.NewResident.LastName;
                resident.BirthDate = ApartmentViewModel.NewResident.BirthDate;
                resident.Email = ApartmentViewModel.NewResident.Email;
                resident.Picture = ApartmentViewModel.NewResident.Picture;
                resident.Phone = ApartmentViewModel.NewResident.Phone;

                //new PersistenceFacade().CreateHotel(hotel);

                ////HotelViewModel.Hotels.Hotels.Add(hotel);
                //var hotelsFromDatabase = new PersistenceFacade().GetHotels();

                //HotelViewModel.HotelCatalogSingleton.Hotels.Clear();
                //foreach (var hotel1 in hotelsFromDatabase)
                //{
                //    ApartmentViewModel.HotelCatalogSingleton.Hotels.Add(hotel1);

                //}
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }



    }   
}

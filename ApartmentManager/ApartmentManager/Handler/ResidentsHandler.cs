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
    public class ResidentsHandler
    {
        public ApartmentViewModel ApartmentViewModel { get; set; }

        public ResidentsHandler(ApartmentViewModel apartmenViewModel)
        {
            ApartmentViewModel = apartmenViewModel;
        }
        public void GetApartmentResidents()
        {
            Resident resident = new Resident();
            resident.ApartmentNr = ApartmentViewModel.ApartmentNumber;

            var residentlist = new PersistenceFacade().GetApartmentResidents(resident);
            ApartmentViewModel.CatalogSingleton.Residents.Clear();
            
            foreach (var resident2 in residentlist)
            {
                ApartmentViewModel.CatalogSingleton.Residents.Add(resident2);              
            }
        }

        public void CreateResident()
        {
            try
            {
                Resident resident = new Resident();
                resident.ResidentNr = ApartmentViewModel.CatalogSingleton.Residents.Count;
                resident.ResidentNr++;
                resident.ApartmentNr = ApartmentViewModel.ApartmentNumber;
                resident.FirstName = ApartmentViewModel.NewResident.FirstName;
                resident.LastName = ApartmentViewModel.NewResident.LastName;
                resident.BirthDate = ApartmentViewModel.NewResident.BirthDate;
                resident.Email = ApartmentViewModel.NewResident.Email;
                resident.Picture = ApartmentViewModel.NewResident.Picture;
                resident.Phone = ApartmentViewModel.NewResident.Phone;

                new PersistenceFacade().CreateResident(resident);

                
                var residentsFromDatabase = new PersistenceFacade().GetApartmentResidents(resident);
                ApartmentViewModel.CatalogSingleton.Residents.Clear();

                foreach (var resident2 in residentsFromDatabase)
                {
                    ApartmentViewModel.CatalogSingleton.Residents.Add(resident2);
                }
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
                resident.FirstName = ApartmentViewModel.NewResident.FirstName;
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
                resident.FirstName = ApartmentViewModel.NewResident.FirstName;
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

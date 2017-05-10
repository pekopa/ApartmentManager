using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using ApartmentManager.Model;
using ApartmentManager.Persistency;
using ApartmentManager.ViewModel;
using Newtonsoft.Json;

namespace ApartmentManager.Handler
{
    public class ApartmentHandler
    {
        public ApartmentViewModel ApartmentViewModel { get; set; }

        public ApartmentHandler(ApartmentViewModel apartmenViewModel)
        {
            ApartmentViewModel = apartmenViewModel;
        }
        public void GetApartmentResidents()
        {
            Resident resident = new Resident();
            resident.ApartmentNr = ApartmentViewModel.ApartmentNumber;
            
            var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + resident.ApartmentNr);
            IEnumerable<Resident> residentlist = JsonConvert.DeserializeObject<IEnumerable<Resident>>(residentsFromDatabase);

            ApartmentViewModel.CatalogSingleton.Residents.Clear();
            ApartmentViewModel.NewResident = new Resident();
            foreach (var resident2 in residentlist)
            {
                ApartmentViewModel.CatalogSingleton.Residents.Add(resident2);              
            }
            
        }
        public void GetApartment()
        {
            string serializedApartment = ApiClient.GetData("api/Apartments/" + ApartmentViewModel.ApartmentNumber);

            Apartment apartment= JsonConvert.DeserializeObject<Apartment>(serializedApartment);
            ApartmentViewModel.CatalogSingleton.Apartment = apartment;
            

        }

        public void CreateResident()
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

                ApiClient.PostData("api/residents/", resident);

                var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + resident.ApartmentNr);
                IEnumerable<Resident> residentlist = JsonConvert.DeserializeObject<IEnumerable<Resident>>(residentsFromDatabase);

                ApartmentViewModel.CatalogSingleton.Residents.Clear();
                ApartmentViewModel.NewResident = new Resident();
                foreach (var resident2 in residentlist)
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
                resident.ResidentNr = ApartmentViewModel.NewResident.ResidentNr;
                resident.ApartmentNr = ApartmentViewModel.ApartmentNumber;
                resident.FirstName = ApartmentViewModel.NewResident.FirstName;
                resident.LastName = ApartmentViewModel.NewResident.LastName;
                resident.BirthDate = ApartmentViewModel.NewResident.BirthDate;
                resident.Email = ApartmentViewModel.NewResident.Email;
                resident.Picture = ApartmentViewModel.NewResident.Picture;
                resident.Phone = ApartmentViewModel.NewResident.Phone;

                ApiClient.DeleteData("api/residents/" + resident.ResidentNr);

                var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + resident.ApartmentNr);
                IEnumerable<Resident> residentlist = JsonConvert.DeserializeObject<IEnumerable<Resident>>(residentsFromDatabase);

                ApartmentViewModel.CatalogSingleton.Residents.Clear();
                ApartmentViewModel.NewResident = new Resident();
                foreach (var resident2 in residentlist)
                {
                    ApartmentViewModel.CatalogSingleton.Residents.Add(resident2);
                }
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
                resident.ResidentNr = ApartmentViewModel.NewResident.ResidentNr;
                resident.ApartmentNr = ApartmentViewModel.ApartmentNumber;
                resident.FirstName = ApartmentViewModel.NewResident.FirstName;
                resident.LastName = ApartmentViewModel.NewResident.LastName;
                resident.BirthDate = ApartmentViewModel.NewResident.BirthDate;
                resident.Email = ApartmentViewModel.NewResident.Email;
                resident.Picture = ApartmentViewModel.NewResident.Picture;
                resident.Phone = ApartmentViewModel.NewResident.Phone;

                ApiClient.PutData("api/residents/" + resident.ResidentNr,resident);
                var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + resident.ApartmentNr);
                IEnumerable<Resident> residentlist = JsonConvert.DeserializeObject<IEnumerable<Resident>>(residentsFromDatabase);

                ApartmentViewModel.CatalogSingleton.Residents.Clear();
                ApartmentViewModel.NewResident = new Resident();
                foreach (var resident2 in residentlist)
                {
                    ApartmentViewModel.CatalogSingleton.Residents.Add(resident2);
                }
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }

        public async void UploadResidentPhoto()
        {
            try
            {
                ApartmentViewModel.NewResident.Picture = await ImgurPhotoUploader.UploadPhotoAsync();
            }
            catch (Exception e)
            {
                
                
            }
                     
        }
    }   
}

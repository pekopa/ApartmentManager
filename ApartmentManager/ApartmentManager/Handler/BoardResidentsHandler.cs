using System;
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
    class BoardResidentsHandler
    {
        public ApartmentsViewModel ApartmentsViewModel { get; set; }

        public BoardResidentsHandler(ApartmentsViewModel apartmentsViewModel)
        {
            ApartmentsViewModel = apartmentsViewModel;
        }
        public void GetApartmentsResidents()
        {
            Resident resident = new Resident();
            resident.ApartmentNr = ApartmentsViewModel.ApartmentsNumber;

            var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + resident.ApartmentNr);
            IEnumerable<Resident> residentlist = JsonConvert.DeserializeObject<IEnumerable<Resident>>(residentsFromDatabase);

            ApartmentsViewModel.ApartmentsCatalogSingleton.Residents.Clear();
            ApartmentsViewModel.NewResident = new Resident();
            foreach (var resident2 in residentlist)
            {
                ApartmentsViewModel.ApartmentsCatalogSingleton.Residents.Add(resident2);
            }

        }

        public void CreateResident()
        {
            try
            {
                Resident resident = new Resident();

                resident.ApartmentNr = ApartmentsViewModel.ApartmentsNumber;
                resident.FirstName = ApartmentsViewModel.NewResident.FirstName;
                resident.LastName = ApartmentsViewModel.NewResident.LastName;
                resident.BirthDate = ApartmentsViewModel.NewResident.BirthDate;
                resident.Email = ApartmentsViewModel.NewResident.Email;
                resident.Picture = ApartmentsViewModel.NewResident.Picture;
                resident.Phone = ApartmentsViewModel.NewResident.Phone;

                ApiClient.PostData("api/residents/", resident);

                var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + resident.ApartmentNr);
                IEnumerable<Resident> residentlist = JsonConvert.DeserializeObject<IEnumerable<Resident>>(residentsFromDatabase);

                ApartmentsViewModel.ApartmentsCatalogSingleton.Residents.Clear();
                ApartmentsViewModel.NewResident = new Resident();
                foreach (var resident2 in residentlist)
                {
                    ApartmentsViewModel.ApartmentsCatalogSingleton.Residents.Add(resident2);
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
                resident.ResidentNr = ApartmentsViewModel.NewResident.ResidentNr;
                resident.ApartmentNr = ApartmentsViewModel.ApartmentsNumber;
                resident.FirstName = ApartmentsViewModel.NewResident.FirstName;
                resident.LastName = ApartmentsViewModel.NewResident.LastName;
                resident.BirthDate = ApartmentsViewModel.NewResident.BirthDate;
                resident.Email = ApartmentsViewModel.NewResident.Email;
                resident.Picture = ApartmentsViewModel.NewResident.Picture;
                resident.Phone = ApartmentsViewModel.NewResident.Phone;

                ApiClient.DeleteData("api/residents/" + resident.ResidentNr);

                var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + resident.ApartmentNr);
                IEnumerable<Resident> residentlist = JsonConvert.DeserializeObject<IEnumerable<Resident>>(residentsFromDatabase);

                ApartmentsViewModel.ApartmentsCatalogSingleton.Residents.Clear();
                ApartmentsViewModel.NewResident = new Resident();
                foreach (var resident2 in residentlist)
                {
                    ApartmentsViewModel.ApartmentsCatalogSingleton.Residents.Add(resident2);
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
                resident.ResidentNr = ApartmentsViewModel.NewResident.ResidentNr;
                resident.ApartmentNr = ApartmentsViewModel.ApartmentsNumber;
                resident.FirstName = ApartmentsViewModel.NewResident.FirstName;
                resident.LastName = ApartmentsViewModel.NewResident.LastName;
                resident.BirthDate = ApartmentsViewModel.NewResident.BirthDate;
                resident.Email = ApartmentsViewModel.NewResident.Email;
                resident.Picture = ApartmentsViewModel.NewResident.Picture;
                resident.Phone = ApartmentsViewModel.NewResident.Phone;

                ApiClient.PutData("api/residents/" + resident.ResidentNr, resident);
                var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + resident.ApartmentNr);
                IEnumerable<Resident> residentlist = JsonConvert.DeserializeObject<IEnumerable<Resident>>(residentsFromDatabase);

                ApartmentsViewModel.ApartmentsCatalogSingleton.Residents.Clear();
                ApartmentsViewModel.NewResident = new Resident();
                foreach (var resident2 in residentlist)
                {
                    ApartmentsViewModel.ApartmentsCatalogSingleton.Residents.Add(resident2);
                }
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
    }
}
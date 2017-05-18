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
   public class BoardResidentsHandler
    {
        public BoardMemberViewModel BoardMemberViewModel { get; set; }

        public BoardResidentsHandler(BoardMemberViewModel boardMemberViewModel)
        {
            BoardMemberViewModel = boardMemberViewModel;
        }
        public void GetApartmentsResidents()
        {
            Resident resident = new Resident();
            resident.ApartmentId = BoardMemberViewModel.ApartmentsNumber;

            var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + resident.ApartmentId);
            IEnumerable<Resident> residentlist = JsonConvert.DeserializeObject<IEnumerable<Resident>>(residentsFromDatabase);

            BoardMemberViewModel.BoardMemberCatalogSingleton.Residents.Clear();
            BoardMemberViewModel.NewResident = new Resident();
            foreach (var resident2 in residentlist)
            {
                BoardMemberViewModel.BoardMemberCatalogSingleton.Residents.Add(resident2);
            }
        }

        public void CreateResident()
        {
            try
            {
                Resident resident = new Resident();

                resident.ApartmentId = BoardMemberViewModel.ApartmentsNumber;
                resident.FirstName = BoardMemberViewModel.NewResident.FirstName;
                resident.LastName = BoardMemberViewModel.NewResident.LastName;
                resident.BirthDate = BoardMemberViewModel.NewResident.BirthDate;
                resident.Email = BoardMemberViewModel.NewResident.Email;
                resident.Picture = BoardMemberViewModel.NewResident.Picture;
                resident.Phone = BoardMemberViewModel.NewResident.Phone;

                ApiClient.PostData("api/residents/", resident);

                var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + resident.ApartmentId);
                IEnumerable<Resident> residentlist = JsonConvert.DeserializeObject<IEnumerable<Resident>>(residentsFromDatabase);

                BoardMemberViewModel.BoardMemberCatalogSingleton.Residents.Clear();
                BoardMemberViewModel.NewResident = new Resident();
                foreach (var resident2 in residentlist)
                {
                    BoardMemberViewModel.BoardMemberCatalogSingleton.Residents.Add(resident2);
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
                resident.ResidentId = BoardMemberViewModel.NewResident.ResidentId;
                resident.ApartmentId = BoardMemberViewModel.ApartmentsNumber;
                resident.FirstName = BoardMemberViewModel.NewResident.FirstName;
                resident.LastName = BoardMemberViewModel.NewResident.LastName;
                resident.BirthDate = BoardMemberViewModel.NewResident.BirthDate;
                resident.Email = BoardMemberViewModel.NewResident.Email;
                resident.Picture = BoardMemberViewModel.NewResident.Picture;
                resident.Phone = BoardMemberViewModel.NewResident.Phone;

                ApiClient.DeleteData("api/residents/" + resident.ResidentId);

                var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + resident.ApartmentId);
                IEnumerable<Resident> residentlist = JsonConvert.DeserializeObject<IEnumerable<Resident>>(residentsFromDatabase);

                BoardMemberViewModel.BoardMemberCatalogSingleton.Residents.Clear();
                BoardMemberViewModel.NewResident = new Resident();
                foreach (var resident2 in residentlist)
                {
                    BoardMemberViewModel.BoardMemberCatalogSingleton.Residents.Add(resident2);
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
                resident.ResidentId = BoardMemberViewModel.NewResident.ResidentId;
                resident.ApartmentId = BoardMemberViewModel.ApartmentsNumber;
                resident.FirstName = BoardMemberViewModel.NewResident.FirstName;
                resident.LastName = BoardMemberViewModel.NewResident.LastName;
                resident.BirthDate = BoardMemberViewModel.NewResident.BirthDate;
                resident.Email = BoardMemberViewModel.NewResident.Email;
                resident.Picture = BoardMemberViewModel.NewResident.Picture;
                resident.Phone = BoardMemberViewModel.NewResident.Phone;

                ApiClient.PutData("api/residents/" + resident.ResidentId, resident);
                var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + resident.ApartmentId);
                IEnumerable<Resident> residentlist = JsonConvert.DeserializeObject<IEnumerable<Resident>>(residentsFromDatabase);

                BoardMemberViewModel.BoardMemberCatalogSingleton.Residents.Clear();
                BoardMemberViewModel.NewResident = new Resident();
                foreach (var resident2 in residentlist)
                {
                    BoardMemberViewModel.BoardMemberCatalogSingleton.Residents.Add(resident2);
                }
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
    }
}
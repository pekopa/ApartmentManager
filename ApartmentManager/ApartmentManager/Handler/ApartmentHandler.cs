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
using Windows.Storage;
using ApartmentManager.Common;
using Windows.Storage.Pickers;

namespace ApartmentManager.Handler
{
    public class ApartmentHandler
    {
        public ApartmentViewModel ApartmentViewModel { get; set; }

        public ApartmentHandler(ApartmentViewModel apartmenViewModel)
        {
            ApartmentViewModel = apartmenViewModel;
        }


        /// <summary>
        /// APARTMENT HANDLERS
        /// </summary>

        public void GetApartment()
        {
            string serializedApartment = ApiClient.GetData("api/Apartments/" + ApartmentViewModel.ApartmentNumber);

            Apartment apartment = JsonConvert.DeserializeObject<Apartment>(serializedApartment);
            ApartmentViewModel.CatalogSingleton.Apartment = apartment;
        }

        /// <summary>
        /// RESIDENT HANDLERS
        /// </summary>
        public void GetApartmentResidents()
        {
            Resident resident = new Resident();
            resident.ApartmentId = ApartmentViewModel.ApartmentNumber;

            var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + resident.ApartmentId);
            IEnumerable<Resident> residentlist = JsonConvert.DeserializeObject<IEnumerable<Resident>>(residentsFromDatabase);

            ApartmentViewModel.CatalogSingleton.Residents.Clear();
            ApartmentViewModel.NewResident = new Resident();
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
                resident.ApartmentId = ApartmentViewModel.ApartmentNumber;
                resident.FirstName = ApartmentViewModel.NewResident.FirstName;
                resident.LastName = ApartmentViewModel.NewResident.LastName;
                resident.BirthDate = ApartmentViewModel.NewResident.BirthDate;
                resident.Email = ApartmentViewModel.NewResident.Email;
                resident.Picture = ApartmentViewModel.NewResident.Picture;
                resident.Phone = ApartmentViewModel.NewResident.Phone;

                ApiClient.PostData("api/residents/", resident);

                var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + resident.ApartmentId);
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
                resident.ResidentId = ApartmentViewModel.NewResident.ResidentId;
                resident.ApartmentId = ApartmentViewModel.ApartmentNumber;
                resident.FirstName = ApartmentViewModel.NewResident.FirstName;
                resident.LastName = ApartmentViewModel.NewResident.LastName;
                resident.BirthDate = ApartmentViewModel.NewResident.BirthDate;
                resident.Email = ApartmentViewModel.NewResident.Email;
                resident.Picture = ApartmentViewModel.NewResident.Picture;
                resident.Phone = ApartmentViewModel.NewResident.Phone;

                ApiClient.DeleteData("api/residents/" + resident.ResidentId);

                var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + resident.ApartmentId);
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
                resident.ResidentId = ApartmentViewModel.NewResident.ResidentId;
                resident.ApartmentId = ApartmentViewModel.ApartmentNumber;
                resident.FirstName = ApartmentViewModel.NewResident.FirstName;
                resident.LastName = ApartmentViewModel.NewResident.LastName;
                resident.BirthDate = ApartmentViewModel.NewResident.BirthDate;
                resident.Email = ApartmentViewModel.NewResident.Email;
                resident.Picture = ApartmentViewModel.NewResident.Picture;
                resident.Phone = ApartmentViewModel.NewResident.Phone;

                ApiClient.PutData("api/residents/" + resident.ResidentId, resident);
                var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + resident.ApartmentId);
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
                var tmp = ApartmentViewModel.NewResident;
                ApartmentViewModel.NewResident = new Resident();
                ApartmentViewModel.NewResident = tmp;
            }
            catch (Exception e)
            {
            }
        }
        /// <summary>
        /// USER HANDLERS
        /// </summary>
        /// 
        public async void UploadUserPhoto()
        {
            try
            {
                ApartmentViewModel.UserSingleton.CurrentUser.Picture = await ImgurPhotoUploader.UploadPhotoAsync();
                var tmp = ApartmentViewModel.UserSingleton.CurrentUser;
                ApartmentViewModel.UserSingleton.CurrentUser = new User();
                ApartmentViewModel.UserSingleton.CurrentUser = tmp;
            }
            catch (Exception e)
            {
            }
        }

        public void UpdateUser()
        {
            try
            {
                User user = new User();
                user = ApartmentViewModel.UserSingleton.CurrentUser;
                ApiClient.PutData("api/users/" + user.Username, user);
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
        /// <summary>
        /// Defect HANDLERS
        /// </summary>
        public void GetApartmentDefects()
        {
            Defect defect = new Defect();
            defect.ApartmentId = ApartmentViewModel.ApartmentNumber;

            var defectsFromDatabase = ApiClient.GetData("api/ApartmentDefects/" + defect.ApartmentId);
            IEnumerable<Defect> defecttlist = JsonConvert.DeserializeObject<IEnumerable<Defect>>(defectsFromDatabase);

            foreach (var qwe in defecttlist)
            {
                var picturesFromDatabase = ApiClient.GetData("api/DefectPictures/" + qwe.DefectId);
                if (picturesFromDatabase != "[]")
                {
                    IEnumerable<DefectPicture> picturetlist = JsonConvert.DeserializeObject<IEnumerable<DefectPicture>>(picturesFromDatabase);
                    ApartmentViewModel.CatalogSingleton.DefectPictures.Clear();
                    foreach (var asd in picturetlist)
                    {

                        ApartmentViewModel.CatalogSingleton.DefectPictures.Add(asd);
                    }
                    qwe.MainPicture = ApartmentViewModel.CatalogSingleton.DefectPictures[0].Picture;
                }
                

            }

            ApartmentViewModel.CatalogSingleton.Defects.Clear();
            ApartmentViewModel.NewResident = new Resident();
            foreach (var defect2 in defecttlist)
            {

                ApartmentViewModel.CatalogSingleton.Defects.Add(defect2);
            }
            ApartmentViewModel.CatalogSingleton.DefectPictures.Clear();
        }

        public void DeleteDefectPicture()
        {
            ApartmentViewModel.CatalogSingleton.DefectPictures.Remove(ApartmentViewModel.SelectedDefectPicture);
        }
        public async void UploadDefectPhoto()
        {
            try
            {
                ApartmentViewModel.SelectedDefectPicture = new DefectPicture();
                
                ApartmentViewModel.SelectedDefectPicture.Picture = await ImgurPhotoUploader.UploadPhotoAsync();
                ApartmentViewModel.CatalogSingleton.DefectPictures.Add(ApartmentViewModel.SelectedDefectPicture);
                
            }
            catch (Exception e)
            {
            }
        }
        public void CreateDefect()
        {
            try
            {
                Defect defect = new Defect();
                defect = ApartmentViewModel.NewDefect;
                defect.ApartmentId = ApartmentViewModel.ApartmentNumber;
                defect.Status = "New";
                defect.UploadDate = DateTime.Now;
                
                ApiClient.PostData("api/defects/", defect);
                defect.DefectId = Int32.Parse(ApartmentViewModel.ServerResponse);
                foreach (var picture in ApartmentViewModel.CatalogSingleton.DefectPictures)
                {
                    picture.DefectId = defect.DefectId;
                    ApiClient.PostData("api/defectpictures/", picture);
                }

                GetApartmentDefects();
                
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }

        public void GetDefectInfo()
        {
            var id = ApartmentViewModel.NewDefect.DefectId;
            Defect defect = new Defect();
            defect.DefectId = id;

            var defectFromDatabase = ApiClient.GetData("api/defects/" + defect.DefectId);
            var defect2 = JsonConvert.DeserializeObject<Defect>(defectFromDatabase);
            ApartmentViewModel.CatalogSingleton.Defect = defect2;

            var picturesFromDatabase = ApiClient.GetData("api/DefectPictures/" + defect.DefectId);
            ApartmentViewModel.CatalogSingleton.DefectPictures2.Clear();
            if (picturesFromDatabase != "[]")
            {
                IEnumerable<DefectPicture> picturetlist =
                JsonConvert.DeserializeObject<IEnumerable<DefectPicture>>(picturesFromDatabase);               
                foreach (var asd in picturetlist)
                {

                    ApartmentViewModel.CatalogSingleton.DefectPictures2.Add(asd);
                }


            }
        }
    }
}

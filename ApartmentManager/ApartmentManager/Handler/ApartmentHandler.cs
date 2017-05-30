using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ApartmentManager.Singletons;
using ApartmentManager.View;

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
            try
            {
                string serializedApartment = ApiClient.GetData("api/Apartments/" + ApartmentViewModel.UserSingleton.CurrentUser.ApartmentId);
                Apartment apartment = JsonConvert.DeserializeObject<Apartment>(serializedApartment);
                ApartmentViewModel.CatalogSingleton.Apartment = apartment;
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }

        /// <summary>
        /// RESIDENT HANDLERS
        /// </summary>
        public void GetApartmentResidents()
        {
            try
            {
                var residentsFromDatabase = ApiClient.GetData("api/ApartmentResidents/" + UserSingleton.Instance.CurrentUser.ApartmentId);
                var residentlist = JsonConvert.DeserializeObject<ObservableCollection<Resident>>(residentsFromDatabase);
                ApartmentViewModel.CatalogSingleton.Residents.Clear();
                foreach (var resident in residentlist)
                {
                    ApartmentViewModel.CatalogSingleton.Residents.Add(resident);
                }
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }

        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public void CreateResident()
        {
            try
            {

                Resident resident = ApartmentViewModel.NewResident ?? new Resident();
                resident.ApartmentId = ApartmentViewModel.UserSingleton.CurrentUser.ApartmentId;
                if (string.IsNullOrEmpty(resident.Picture))
                {
                    resident.Picture = "http://i.imgur.com/8KNkU26.png";
                }
                if (!string.IsNullOrEmpty(resident.FirstName) && !string.IsNullOrEmpty(resident.FirstName))
                {
                    ApiClient.PostData("api/residents/", resident);
                }
                GetApartmentResidents();
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public void DeleteResident()
        {
            try
            {
                Resident resident = ApartmentViewModel.NewResident ?? new Resident();
                resident.ApartmentId = ApartmentViewModel.UserSingleton.CurrentUser.ApartmentId;

                ApiClient.DeleteData("api/residents/" + resident.ResidentId);
                GetApartmentResidents();
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public void UpdateResident()
        {
            try
            {
                Resident resident = ApartmentViewModel.NewResident ?? new Resident();
                resident.ApartmentId = ApartmentViewModel.UserSingleton.CurrentUser.ApartmentId;

                ApiClient.PutData("api/residents/" + resident.ResidentId, resident);
                GetApartmentResidents();
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
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
                new MessageDialog(e.Message).ShowAsync();
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
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public void UpdateUser()
        {
            try
            {
                User user = ApartmentViewModel.UserSingleton.CurrentUser ?? new User();
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
            Defect Defect = new Defect();
            Defect.ApartmentId = ApartmentViewModel.UserSingleton.CurrentUser.ApartmentId;

            var defectsFromDatabase = ApiClient.GetData("api/ApartmentDefects/" + Defect.ApartmentId);
            var defecttlist = JsonConvert.DeserializeObject<ObservableCollection<Defect>>(defectsFromDatabase);

            foreach (var defect in defecttlist)
            {
                var picturesFromDatabase = ApiClient.GetData("api/DefectPicturesById/" + defect.DefectId);
                if (picturesFromDatabase != "[]")
                {
                    ApartmentViewModel.CatalogSingleton.DefectPictures = JsonConvert.DeserializeObject<ObservableCollection<DefectPicture>>(picturesFromDatabase);
                    defect.MainPicture = ApartmentViewModel.CatalogSingleton.DefectPictures[0].Picture;
                }
            }
            ApartmentViewModel.CatalogSingleton.Defects = defecttlist;
            ApartmentViewModel.CatalogSingleton.DefectPictures.Clear();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public void DeleteDefectPicture()
        {
            try
            {
                ApartmentViewModel.CatalogSingleton.DefectPictures.Remove(ApartmentViewModel.SelectedDefectPicture);
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
        public async void UploadDefectPhoto()
        {
            try
            {
                ApartmentViewModel.SelectedDefectPicture.Picture = await ImgurPhotoUploader.UploadPhotoAsync();
                ApartmentViewModel.CatalogSingleton.DefectPictures.Add(ApartmentViewModel.SelectedDefectPicture);
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public void CreateDefect()
        {
            try
            {
                Defect defect = ApartmentViewModel.NewDefect;
                defect.ApartmentId = ApartmentViewModel.UserSingleton.CurrentUser.ApartmentId;
                defect.Status = "New";
                defect.UploadDate = DateTime.Now;

                var response = ApiClient.PostData("api/defects/", defect);
                var defectResponse = JsonConvert.DeserializeObject<Defect>(response);
                defect.DefectId = defectResponse.DefectId;

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
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public bool CreateDefect_CanExecute()
        {
            if (string.IsNullOrEmpty(ApartmentViewModel.NewDefect.Description) || string.IsNullOrEmpty(ApartmentViewModel.NewDefect.Name))
                return false;
            else
                return true;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public void GetDefectInfo()
        {
            try
            {
                var defectFromDatabase = ApiClient.GetData("api/defects/" + ApartmentViewModel.NewDefect.DefectId);
                ApartmentViewModel.CatalogSingleton.Defect = JsonConvert.DeserializeObject<Defect>(defectFromDatabase);
                var picturesFromDatabase = ApiClient.GetData("api/DefectPicturesById/" + ApartmentViewModel.NewDefect.DefectId);
                ApartmentViewModel.CatalogSingleton.DefectPictures = JsonConvert.DeserializeObject<ObservableCollection<DefectPicture>>(picturesFromDatabase);
                var defectComments = ApiClient.GetData("api/Defectcomments/" + ApartmentViewModel.NewDefect.DefectId);
                ApartmentViewModel.CatalogSingleton.DefectComments = JsonConvert.DeserializeObject<ObservableCollection<DefectComment>>(defectComments);
                CatalogSingleton.Instance.DefectId = ApartmentViewModel.NewDefect.DefectId;
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
            
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public void CreateDefectComment()
        {
            try
            {
                DefectComment Comment = new DefectComment();
                Comment.Comment = ApartmentViewModel.NewDefectComment.Comment;
                Comment.DefectId = CatalogSingleton.Instance.Defect.DefectId;
                Comment.Name = UserSingleton.Instance.CurrentUser.FirstName + " " + UserSingleton.Instance.CurrentUser.LastName;
                Comment.Date = DateTimeOffset.Now;
                if (!string.IsNullOrEmpty(Comment.Comment))
                {
                    ApiClient.PostData("api/Defectcomments/", Comment);
                }
                var response = ApiClient.GetData("api/Defectcomments/" + CatalogSingleton.Instance.DefectId);
                var commentlist = JsonConvert.DeserializeObject<ObservableCollection<DefectComment>>(response);
                CatalogSingleton.Instance.DefectComments.Clear();
                foreach (var comment in commentlist)
                {
                    CatalogSingleton.Instance.DefectComments.Add(comment);
                }
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }    
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
    }
}

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
            GetApartment();
            if (CatalogSingleton.Instance.Residents.Count==0) GetApartmentResidents();
            if (CatalogSingleton.Instance.Defects.Count == 0) GetApartmentDefects();
            if (CatalogSingleton.Instance.Changes.Count == 0) GetApartmentChanges();
        }


        /// <summary>
        /// APARTMENT HANDLERS
        /// </summary>

        public void GetApartment()
        {
            try
            {
                string serializedApartment = ApiClient.GetData("api/Apartments/" + UserSingleton.Instance.CurrentUser.ApartmentId);
                Apartment apartment = JsonConvert.DeserializeObject<Apartment>(serializedApartment);
                CatalogSingleton.Instance.Apartment = apartment;
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
                CatalogSingleton.Instance.Residents.Clear();
                foreach (var resident in residentlist)
                {
                    CatalogSingleton.Instance.Residents.Add(resident);
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
                if (!string.IsNullOrEmpty(resident.FirstName) && !string.IsNullOrEmpty(resident.LastName))
                {
                    var response = ApiClient.PostData("api/residents/", resident);
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
            Defect.ApartmentId = UserSingleton.Instance.CurrentUser.ApartmentId;
            var defectsFromDatabase = ApiClient.GetData("api/ApartmentDefects/" + Defect.ApartmentId);
            var defecttlist = JsonConvert.DeserializeObject<ObservableCollection<Defect>>(defectsFromDatabase);
            CatalogSingleton.Instance.Defects = new ObservableCollection<Defect>();
            CatalogSingleton.Instance.Defects.Clear();
            foreach (var defect in defecttlist)
            {
                defect.Pictures = JsonConvert.DeserializeObject<ObservableCollection<DefectPicture>>(ApiClient.GetData("api/DefectPicturesById/" + defect.DefectId));
                defect.Comments = JsonConvert.DeserializeObject<ObservableCollection<DefectComment>>(ApiClient.GetData("api/DefectComments/" + defect.DefectId));
                CatalogSingleton.Instance.Defects.Add(defect);
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        public void DeleteDefectPicture()
        {
            try
            {
                ApartmentViewModel.NewDefect.Pictures.Remove(ApartmentViewModel.SelectedDefectPicture);
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
                if (ApartmentViewModel.NewDefect.Pictures == null) ApartmentViewModel.NewDefect.Pictures = new ObservableCollection<DefectPicture>();
                var picture = new DefectPicture() { Picture = await ImgurPhotoUploader.UploadPhotoAsync() };
                ApartmentViewModel.NewDefect.Pictures.Add(picture);
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
                foreach (var picture in defect.Pictures)
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
        public void CreateDefectComment()
        {
            try
            {
                DefectComment Comment = new DefectComment();
                Comment.Comment = ApartmentViewModel.NewDefectComment.Comment;
                Comment.DefectId = CatalogSingleton.Instance.SelectedDefect.DefectId;
                Comment.Name = UserSingleton.Instance.CurrentUser.FirstName + " " + UserSingleton.Instance.CurrentUser.LastName;
                Comment.Date = DateTimeOffset.Now;
                if (!string.IsNullOrEmpty(Comment.Comment))
                {
                    ApiClient.PostData("api/Defectcomments/", Comment);
                }
                var response = ApiClient.GetData("api/Defectcomments/" + CatalogSingleton.Instance.SelectedDefect.DefectId);
                var commentlist = JsonConvert.DeserializeObject<ObservableCollection<DefectComment>>(response);

                CatalogSingleton.Instance.SelectedDefect.Comments.Clear();
                foreach (var comment in commentlist)
                {
                    CatalogSingleton.Instance.SelectedDefect.Comments.Add(comment);
                }
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
        /// <summary>
        /// Defect HANDLERS
        /// </summary>
        public void GetApartmentChanges()
        {
            Change change = new Change();
            change.ApartmentId = UserSingleton.Instance.CurrentUser.ApartmentId;
            var changesFromDatabase = ApiClient.GetData("api/ChangesByApartmentId/" + change.ApartmentId);
            var changeslist = JsonConvert.DeserializeObject<ObservableCollection<Change>>(changesFromDatabase);
            CatalogSingleton.Instance.Changes = new ObservableCollection<Change>();
            CatalogSingleton.Instance.Changes.Clear();
            foreach (var apartmentChange in changeslist)
            {
                apartmentChange.Documents = JsonConvert.DeserializeObject<ObservableCollection<ChangeDocument>>(ApiClient.GetData("api/DocumentsByChangeId/" + apartmentChange.ChangeId));
                apartmentChange.Comments = JsonConvert.DeserializeObject<ObservableCollection<ChangeComment>>(ApiClient.GetData("api/CommentsByChangeId/" + apartmentChange.ChangeId));
                CatalogSingleton.Instance.Changes.Add(apartmentChange);
            }
        }
        public void CreateChangeComment()
        {
            try
            {
                ChangeComment Comment = new ChangeComment();
                Comment.Comment = ApartmentViewModel.NewChangeComment.Comment;
                Comment.ChangeId = CatalogSingleton.Instance.SelectedChange.ChangeId;
                Comment.Name = UserSingleton.Instance.CurrentUser.FirstName + " " + UserSingleton.Instance.CurrentUser.LastName;
                Comment.Date = DateTimeOffset.Now;
                if (!string.IsNullOrEmpty(Comment.Comment))
                {
                    var asd =ApiClient.PostData("api/ChangeComments/", Comment);
                }
                var response = ApiClient.GetData("api/CommentsByChangeId/" + CatalogSingleton.Instance.SelectedChange.ChangeId);
                var commentlist = JsonConvert.DeserializeObject<ObservableCollection<ChangeComment>>(response);

                CatalogSingleton.Instance.SelectedChange.Comments.Clear();
                foreach (var comment in commentlist)
                {
                    CatalogSingleton.Instance.SelectedChange.Comments.Add(comment);
                }
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
        public void DeleteChangePicture()
        {
            try
            {
                ApartmentViewModel.NewChange.Documents.Remove(ApartmentViewModel.SelectedChangeDocument);
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
        public async void UploadChangePicture()
        {
            try
            {
                if (ApartmentViewModel.NewChange.Documents == null) ApartmentViewModel.NewChange.Documents = new ObservableCollection<ChangeDocument>();
                var picture = new ChangeDocument() { Document = await ImgurPhotoUploader.UploadPhotoAsync() };
                ApartmentViewModel.NewChange.Documents.Add(picture);
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
        public void CreateChange()
        {
            try
            {
                Change change = ApartmentViewModel.NewChange;
                change.ApartmentId = ApartmentViewModel.UserSingleton.CurrentUser.ApartmentId;
                change.Status = "New";
                change.UploadDate = DateTime.Now;
                var response = ApiClient.PostData("api/Changes/", change);
                var changeResponse = JsonConvert.DeserializeObject<Change>(response);
                change.ChangeId = changeResponse.ChangeId;
                if (change.Documents !=null)
                {
                    foreach (var document in change.Documents)
                    {
                        document.ChangeId = change.ChangeId;
                        ApiClient.PostData("api/ChangeDocuments/", document);
                    }
                }      
                GetApartmentChanges();
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
        public bool CreateChange_CanExecute()
        {
            if (string.IsNullOrEmpty(ApartmentViewModel.NewChange.Description) || string.IsNullOrEmpty(ApartmentViewModel.NewChange.Name))
                return false;
            else
                return true;
        }

    }
}

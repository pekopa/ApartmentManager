using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using ApartmentManager.Model;
using ApartmentManager.Persistency;
using ApartmentManager.ViewModel;
using Newtonsoft.Json;
using ApartmentManager.Singletons;
using System.Collections.Generic;

namespace ApartmentManager.Handler
{
    public class BmHandler
    {
        private BmViewModel _vm;

        public BmHandler(BmViewModel vm)
        {
            _vm = vm;
        }


        #region APARTMENTS

        public void GetApartments()
        {
            BmSingleton.Instance.Apartments = JsonConvert.DeserializeObject<ObservableCollection<Apartment>>(ApiClient.GetData("api/Apartments/"));
        }

        public void CreateApartment()
        {
            try
            {
                ApiClient.PostData("api/Apartments/", _vm.ApartmentTemplate);
                GetApartments();
                _vm.ApartmentTemplate = new Apartment();
            }
            catch (Exception e)
            {
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }
        public void UpdateApartment()
        {
            try
            {
                ApiClient.PutData("api/Apartments/" + _vm.ApartmentTemplate.ApartmentId, _vm.ApartmentTemplate);
                GetApartments();
            }
            catch (Exception e)
            {
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }
        public void DeleteApartment()
        {
            try
            {
                ApiClient.DeleteData("api/Apartments/" + _vm.ApartmentTemplate.ApartmentId);
                BmSingleton.Instance.Apartments.Remove(_vm.ApartmentTemplate);
                GetApartments();
            }
            catch (Exception e)
            {
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }

        public async void UploadApartmentPlan()
        {
            _vm.ApartmentTemplate.PlanPicture = await ImgurPhotoUploader.UploadPhotoAsync();
        }

        public void ClearApartmentTemplate()
        {
            _vm.ApartmentTemplate = new Apartment();
        }
        #endregion

        #region USERS

        public void GetUsers()
        {
            var users = JsonConvert.DeserializeObject<ObservableCollection<User>>(ApiClient.GetData("api/Users/"));
            BmSingleton.Instance.Users.Clear();
            foreach (var user in users) BmSingleton.Instance.Users.Add(user);
        }

        public void CreateUser()
        {
            try
            {
                ApiClient.PostData("api/Users/", _vm.UserTemplate);
                GetUsers();
                _vm.UserTemplate = new User();
            }
            catch (Exception e)
            {
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }
        public void UpdateUser()
        {
            try
            {
                ApiClient.PutData("api/Users/" + _vm.UserTemplate.Username, _vm.UserTemplate);
                GetUsers();
            }
            catch (Exception e)
            {
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }
        public void DeleteUser()
        {
            try
            {
                ApiClient.DeleteData("api/Users/" + _vm.UserTemplate.Username);
                BmSingleton.Instance.Users.Remove(_vm.UserTemplate);
                GetUsers();
            }
            catch (Exception e)
            {
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }

        public async void UploadUserPhoto()
        {
            var picture = await ImgurPhotoUploader.UploadPhotoAsync();
            if (picture != "")
            {
                _vm.UserTemplate.Picture = picture;
                var tmp = _vm.UserTemplate;
                _vm.UserTemplate = new User();
                _vm.UserTemplate = tmp;
            }
        }

        public void ClearUserTemplate()
        {
            _vm.UserTemplate = new User();
        }
        #endregion

        #region RESIDENTS

        public void GetResidents()
        {
            var residents = JsonConvert.DeserializeObject<ObservableCollection<Resident>>(ApiClient.GetData("api/Residents/"));
            BmSingleton.Instance.Residents.Clear();
            foreach (var resident in residents) BmSingleton.Instance.Residents.Add(resident);
        }

        public void CreateResident()
        {
            try
            {
                ApiClient.PostData("api/Residents/", _vm.ResidentTemplate);
                GetResidents();
                _vm.ResidentTemplate = new Resident();
            }
            catch (Exception e)
            {
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }
        public void UpdateResident()
        {
            try
            {
                ApiClient.PutData("api/Residents/" + _vm.ResidentTemplate.ResidentId, _vm.ResidentTemplate);
                GetResidents();
            }
            catch (Exception e)
            {
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }
        public void DeleteResident()
        {
            try
            {
                ApiClient.DeleteData("api/Residents/" + _vm.ResidentTemplate.ResidentId);
                BmSingleton.Instance.Residents.Remove(_vm.ResidentTemplate);
                GetResidents();
            }
            catch (Exception e)
            {
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }

        public async void UploadResidentPhoto()
        {
            _vm.ResidentTemplate.Picture = await ImgurPhotoUploader.UploadPhotoAsync();
            var tmp = _vm.ResidentTemplate;
            _vm.ResidentTemplate = new Resident();
            _vm.ResidentTemplate = tmp;
        }

        public void ClearResidentTemplate()
        {
            _vm.ResidentTemplate = new Resident();
        }
        #endregion

        #region DEFECTS

        public void GetDefects()
        {
            var defects = JsonConvert.DeserializeObject<ObservableCollection<Defect>>(ApiClient.GetData("api/Defects/"));
            BmSingleton.Instance.Defects.Clear();
            foreach (var defect in defects)
            {
                defect.Pictures = JsonConvert.DeserializeObject<ObservableCollection<DefectPicture>>(ApiClient.GetData("api/DefectPicturesById/" + defect.DefectId));
                defect.Comments = JsonConvert.DeserializeObject<ObservableCollection<DefectComment>>(ApiClient.GetData("api/DefectComments/" + defect.DefectId));
                BmSingleton.Instance.Defects.Add(defect);
            }
        }

        public void CreateDefect()
        {
            try
            {
                _vm.DefectTemplate.Status = "New";
                _vm.DefectTemplate.UploadDate = DateTime.Now;
                var response = JsonConvert.DeserializeObject<Defect>(ApiClient.PostData("api/Defects/", _vm.DefectTemplate));
                foreach(var defectPicture in _vm.DefectTemplate.Pictures)
                {
                    defectPicture.DefectId = response.DefectId;
                    ApiClient.PostData("api/DefectPictures", defectPicture);
                }
                GetDefects();
                _vm.DefectTemplate = new Defect();
            }
            catch (Exception e)
            {
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }
        public void UpdateDefect()
        {
            try
            {
                ApiClient.PutData("api/Defects/" + _vm.DefectTemplate.DefectId, _vm.DefectTemplate);
                var deletedDefectPictures = new List<DefectPicture>(_vm.DeletedDefectPictures);
                var addedDefectPictures = new List<DefectPicture>(_vm.AddedDefectPictures);

                foreach (var defectPicture in deletedDefectPictures)
                {
                    ApiClient.DeleteData("api/DefectPictures/" + defectPicture.Pictureid);
                    _vm.DeletedDefectPictures.Remove(defectPicture);
                }
                foreach (var defectPicture in addedDefectPictures)
                {
                    defectPicture.DefectId = _vm.DefectTemplate.DefectId;
                    ApiClient.PostData("api/DefectPictures", defectPicture);
                    addedDefectPictures.Remove(defectPicture);
                }
                GetDefects();
            }
            catch (Exception e)
            {
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }
        public void DeleteDefect()
        {
            try
            {
                ApiClient.DeleteData("api/Defects/" + _vm.DefectTemplate.DefectId);
                BmSingleton.Instance.Defects.Remove(_vm.DefectTemplate);
                GetDefects();
            }
            catch (Exception e)
            {
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }

        public void ClearDefectTemplate()
        {
            _vm.DefectTemplate = new Defect();
        }

        public async void UploadDefectPicture()
        {
            if (_vm.DefectTemplate.Pictures == null) _vm.DefectTemplate.Pictures = new ObservableCollection<DefectPicture>();
            var picture = new DefectPicture() { Picture = await ImgurPhotoUploader.UploadPhotoAsync() };
            _vm.DefectTemplate.Pictures.Add(picture);
            _vm.AddedDefectPictures.Add(picture);
        }

        public void DeleteDefectPicture()
        {
            _vm.DefectTemplate.Pictures.Remove(_vm.SelectedDefectPicture);
        }

        public void DeleteDefectPictureTemp()
        {
            _vm.DeletedDefectPictures.Add(_vm.SelectedDefectPicture);
            _vm.DefectTemplate.Pictures.Remove(_vm.SelectedDefectPicture);
        }

        public void CreateDefectComment()
        {
            try
            {
                var comment = new DefectComment()
                {
                    Comment = _vm.NewDefectComment.Comment,
                    DefectId = _vm.DefectTemplate.DefectId,
                    Name = UserSingleton.Instance.CurrentUser.FirstName + " " + UserSingleton.Instance.CurrentUser.LastName,
                    Date = DateTimeOffset.Now
                };
                if (!string.IsNullOrEmpty(comment.Comment))
                {
                    ApiClient.PostData("api/DefectComments/", comment);
                    _vm.DefectTemplate.Comments.Add(comment);
                    _vm.NewDefectComment = new DefectComment();
                }
            }
            catch (Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
        #endregion
    }
}

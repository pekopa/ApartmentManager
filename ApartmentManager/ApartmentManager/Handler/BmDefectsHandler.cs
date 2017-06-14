using ApartmentManager.Model;
using ApartmentManager.Persistency;
using ApartmentManager.Singletons;
using ApartmentManager.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

namespace ApartmentManager.Handler
{
    public class BmDefectsHandler
    {
        private BmDefectsViewModel _vm;

        public BmDefectsHandler(BmDefectsViewModel vm)
        {
            _vm = vm;
            if (BmSingleton.Instance.Defects.Count == 0) GetDefects();
        }

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
                foreach (var defectPicture in _vm.DefectTemplate.Pictures)
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
                    _vm.AddedDefectPictures.Remove(defectPicture);
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
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }
    }
}

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
    public class BmChangesHandler
    {
        private BmChangesViewModel _vm;

        public BmChangesHandler(BmChangesViewModel vm)
        {
            _vm = vm;
            if (BmSingleton.Instance.Changes == null) GetChanges();
        }

        public void GetChanges()
        {
            var changes = JsonConvert.DeserializeObject<ObservableCollection<Change>>(ApiClient.GetData("api/Changes/"));
            BmSingleton.Instance.Changes = new ObservableCollection<Change>();
            foreach (var change in changes)
            {
                change.Documents = JsonConvert.DeserializeObject<ObservableCollection<ChangeDocument>>(ApiClient.GetData("api/DocumentsByChangeId/" + change.ChangeId));
                change.Comments = JsonConvert.DeserializeObject<ObservableCollection<ChangeComment>>(ApiClient.GetData("api/CommentsByChangeId/" + change.ChangeId));
                BmSingleton.Instance.Changes.Add(change);
            }
        }

        public void CreateChange()
        {
            try
            {
                _vm.ChangeTemplate.Status = "New";
                _vm.ChangeTemplate.UploadDate = DateTime.Now;
                if (_vm.ChangeTemplate.Documents == null) _vm.ChangeTemplate.Documents = new ObservableCollection<ChangeDocument>();
                var response = JsonConvert.DeserializeObject<Change>(ApiClient.PostData("api/Changes/", _vm.ChangeTemplate));
                foreach (var changeDocument in _vm.ChangeTemplate.Documents)
                {
                    changeDocument.ChangeId = response.ChangeId;
                    ApiClient.PostData("api/ChangeDocuments/", changeDocument);
                }
                GetChanges();
                _vm.ChangeTemplate = new Change();
            }
            catch (Exception e)
            {
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }
        public void UpdateChange()
        {
            try
            {
                ApiClient.PutData("api/Changes/" + _vm.ChangeTemplate.ChangeId, _vm.ChangeTemplate);
                var deletedChangeDocuments = new List<ChangeDocument>(_vm.DeletedChangeDocuments);
                var addedChangeDocuments = new List<ChangeDocument>(_vm.AddedChangeDocuments);

                foreach (var changeDocument in deletedChangeDocuments)
                {
                    ApiClient.DeleteData("api/ChangeDocuments/" + changeDocument.DocumentId);
                    _vm.DeletedChangeDocuments.Remove(changeDocument);
                }
                foreach (var changeDocument in addedChangeDocuments)
                {
                    changeDocument.ChangeId = _vm.ChangeTemplate.ChangeId;
                    ApiClient.PostData("api/ChangeDocuments", changeDocument);
                    _vm.AddedChangeDocuments.Remove(changeDocument);
                }
                GetChanges();
            }
            catch (Exception e)
            {
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }
        public void DeleteChange()
        {
            try
            {
                ApiClient.DeleteData("api/Changes/" + _vm.ChangeTemplate.ChangeId);
                BmSingleton.Instance.Changes.Remove(_vm.ChangeTemplate);
                GetChanges();
            }
            catch (Exception e)
            {
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }

        public void ClearChangeTemplate()
        {
            _vm.ChangeTemplate = new Change();
        }

        public async void UploadChangeDocument()
        {
            if (_vm.ChangeTemplate.Documents == null) _vm.ChangeTemplate.Documents = new ObservableCollection<ChangeDocument>();
            var document = new ChangeDocument() { Document = await ImgurPhotoUploader.UploadPhotoAsync() };
            _vm.ChangeTemplate.Documents.Add(document);
            _vm.AddedChangeDocuments.Add(document);
        }

        public void DeleteChangeDocument()
        {
            _vm.ChangeTemplate.Documents.Remove(_vm.SelectedChangeDocument);
        }

        public void DeleteChangeDocumentTemp()
        {
            _vm.DeletedChangeDocuments.Add(_vm.SelectedChangeDocument);
            _vm.ChangeTemplate.Documents.Remove(_vm.SelectedChangeDocument);
        }

        public void CreateChangeComment()
        {
            try
            {
                var comment = new ChangeComment()
                {
                    Comment = _vm.NewChangeComment.Comment,
                    ChangeId = _vm.ChangeTemplate.ChangeId,
                    Name = UserSingleton.Instance.CurrentUser.FirstName + " " + UserSingleton.Instance.CurrentUser.LastName,
                    Date = DateTimeOffset.Now
                };
                if (!string.IsNullOrEmpty(comment.Comment))
                {
                    ApiClient.PostData("api/ChangeComments/", comment);
                    _vm.ChangeTemplate.Comments.Add(comment);
                    _vm.NewChangeComment = new ChangeComment();
                }
            }
            catch (Exception e)
            {
                var msg = new MessageDialog(e.Message).ShowAsync();
            }
        }
    }
}

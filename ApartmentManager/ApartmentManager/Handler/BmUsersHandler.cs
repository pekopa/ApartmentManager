using ApartmentManager.Model;
using ApartmentManager.Persistency;
using ApartmentManager.Singletons;
using ApartmentManager.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace ApartmentManager.Handler
{
    public class BmUsersHandler
    {
        private BmUsersViewModel _vm;

        public BmUsersHandler(BmUsersViewModel vm)
        {
            _vm = vm;
            if (BmSingleton.Instance.Users.Count == 0) GetUsers();
        }

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
    }
}

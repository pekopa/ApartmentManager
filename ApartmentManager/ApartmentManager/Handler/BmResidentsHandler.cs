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
    public class BmResidentsHandler
    {
        private BmResidentsViewModel _vm;

        public BmResidentsHandler(BmResidentsViewModel vm)
        {
            _vm = vm;
        }

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
    }
}

using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using ApartmentManager.Model;
using ApartmentManager.Persistency;
using ApartmentManager.ViewModel;
using Newtonsoft.Json;
using ApartmentManager.Singletons;

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

    }
}

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
        public void GetApartment()
        {
            string serializedApartment = ApiClient.GetData("api/Apartments/" + ApartmentViewModel.ApartmentNumber);

            Apartment apartment = JsonConvert.DeserializeObject<Apartment>(serializedApartment);
            ApartmentViewModel.CatalogSingleton.Apartment = apartment;
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
                //Create new file picker
                FileOpenPicker fp = new FileOpenPicker()
                {
                    SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                    ViewMode = PickerViewMode.Thumbnail,
                    CommitButtonText = "Upload"
                };
                fp.FileTypeFilter.Add(".jpg");
                fp.FileTypeFilter.Add(".jpeg");
                fp.FileTypeFilter.Add(".png");
                fp.FileTypeFilter.Add(".gif");
                fp.FileTypeFilter.Add(".apng");
                fp.FileTypeFilter.Add(".tiff");
                fp.FileTypeFilter.Add(".tif");
                fp.FileTypeFilter.Add(".bmp");
                fp.FileTypeFilter.Add(".pdf");
                fp.FileTypeFilter.Add(".xcf");
                fp.FileTypeFilter.Add(".webp");

                //Get image file with picker
                StorageFile file = await fp.PickSingleFileAsync();

                ByteArrayToImageConverter converter = new ByteArrayToImageConverter();
                ApartmentViewModel.NewResident.Picture = (byte[]) await converter.ConvertToByte(file, typeof(System.Byte), null, "");

                var tmp = ApartmentViewModel.NewResident;
                ApartmentViewModel.NewResident = new Resident();
                ApartmentViewModel.NewResident = tmp;
            }
            catch (Exception e)
            {


            }

        }
    }
}

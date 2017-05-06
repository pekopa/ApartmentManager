using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace ApartmentManager.Persistency
{
    public static class ImgurPhotoUploader
    {
        /// <summary>
        /// Opens file picker, uploads chosen image and returns link to it.
        /// </summary>
        public async static Task<string> UploadPhotoAsync()
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

            //Upload to Imgur and return link
            var client = new ImgurClient("7b05a61ed8df74f", "ade6f79163e19f92f852bc553bbe399d7d4218fe");
            var endpoint = new ImageEndpoint(client);
            IImage image = await endpoint.UploadImageStreamAsync(await file.OpenStreamForReadAsync());
            return image.Link;
        }
    }
}
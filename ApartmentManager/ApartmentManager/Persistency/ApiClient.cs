using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using ApartmentManager.Model;
using ApartmentManager.ViewModel;

namespace ApartmentManager.Persistency
{
    public static class ApiClient
    {
        private const string ServerUrl = "http://localhost:60916";

        public static string GetData(string url)
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsStringAsync().Result;

                    }
                    else return null;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static void PutData(string url, object objectToPut)
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string serializedData = JsonConvert.SerializeObject(objectToPut);
                    StringContent content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                    var response = client.PutAsync(url, content).Result;
                }
                catch (Exception)
                {
                }
            }
        }

        public static void PostData(string url, object objectToPost)
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string serializedData = JsonConvert.SerializeObject(objectToPost);
                    StringContent content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                    var response = new HttpResponseMessage();
                        response = client.PostAsync(url, content).Result;
                    var def = JsonConvert.DeserializeObject<Defect>(response.Content.ReadAsStringAsync().Result);
                    //var response = client.PostAsync(url, content).Result.Headers.Location.AbsolutePath.Remove(0,13);
                    ApartmentViewModel.ServerResponse = def.DefectId;
                }
                catch (Exception)
                {
                    
                }
            }
        }

        public static void DeleteData(string url)
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.DeleteAsync(url).Result;
                }
                catch (Exception)
                {
                }
            }
        }
    }
}

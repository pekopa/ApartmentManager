using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using ApartmentManager.Model;
using Newtonsoft.Json;

namespace ApartmentManager.Persistency
{
    class PersistenceFacade
    {

        const string ServerUrl = "http://localhost:60916";
        HttpClientHandler handler;

        public PersistenceFacade()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
        }

        // Get apartments

        public List<Apartment> GetApartments(Apartment apartment)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string apartments = "api/apartments/" + apartment.ApartmentNumber;
                    var response = client.GetAsync(apartments).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var apartmentList = response.Content.ReadAsAsync<IEnumerable<Apartment>>().Result;
                        return apartmentList.ToList();
                    }
                }
                catch (Exception e)
                {
                    new MessageDialog("Cyka blyat").ShowAsync();
                   
                }
                return null;
            }
        }

        public void CreateApartment(Apartment apartment)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(apartment);
                    var response = client.PostAsync("api/apartments/",
                            new StringContent(postBody, Encoding.UTF8, "application/json"))
                        .Result;
                    if (response.IsSuccessStatusCode)
                    {
                        new MessageDialog("Success").ShowAsync();
                    }
                    else
                    {
                        new MessageDialog("Error").ShowAsync();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        ///Get Get Residents///
        public List<Resident> GetApartmentResidents(Resident resident)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string residentsBody = "api/residents/" + resident.ApartmentNr;
                    var response = client.GetAsync(residentsBody).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var residentList = response.Content.ReadAsAsync<IEnumerable<Resident>>().Result;
                        return residentList.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
        ///Get Get Residents///
        public void CreateResident(Resident resident)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(resident);
                    var response = client.PostAsync("api/Residents",
                            new StringContent(postBody, Encoding.UTF8, "application/json"))
                        .Result;
                    if (response.IsSuccessStatusCode)
                    {
                        new MessageDialog("Success").ShowAsync();
                    }
                    else
                    {
                        new MessageDialog("Error").ShowAsync();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }

        }

    }
}

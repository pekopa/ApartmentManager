using ApartmentManager.Model;
using ApartmentManager.Persistency;
using Newtonsoft.Json;
using System;
using ApartmentManager.Singletons;
using ApartmentManager.ViewModel;

namespace ApartmentManager.Handler
{
    public static class LoginHandler
    {
        public static void LogIn(string username, string password)
        {
                string serializedUser = ApiClient.GetData($"api/Users/{username}");
                if (serializedUser != null)
                {
                    User user = JsonConvert.DeserializeObject<User>(serializedUser);
                    if (user.Password == password)
                    {
                        UserSingleton.Instance.CurrentUser = user;
                        

                }
                    else throw new Exception("Wrong password!");
                }
                else throw new Exception("Wrong username!");
            
        }

        public static void LogOut()
        {
            UserSingleton.Instance.CurrentUser = null;
        }
    }
}

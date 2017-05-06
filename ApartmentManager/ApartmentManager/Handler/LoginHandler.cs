using ApartmentManager.Model;
using ApartmentManager.Persistency;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Handler
{
    public static class LoginHandler
    {
        public static void LogIn(string username, string password)
        {
            
                string serializedUser = ApiClient.GetData($"api/Users/by-username/{username}");
                if (serializedUser != null)
                {
                    User user = JsonConvert.DeserializeObject<User>(serializedUser);
                    if (user.Password == password)
                    {
                        UserSingleton.CurrentUser = user;
                    }
                    else throw new Exception("Wrong password!");
                }
                else throw new Exception("Wrong username!");
            
        }

        public static void LogOut()
        {
            UserSingleton.CurrentUser = null;
        }
    }
}

using ApartmentManager.Model;

namespace ApartmentManager.Singletons
{
    public class UserSingleton
    {
        private static UserSingleton _instance;
        public static UserSingleton Instance => _instance ?? (_instance = new UserSingleton());

        public User CurrentUser { get; set; }

        private UserSingleton() { }
    }
}

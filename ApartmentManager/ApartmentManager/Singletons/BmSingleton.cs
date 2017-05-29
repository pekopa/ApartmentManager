using ApartmentManager.Model;
using System.Collections.ObjectModel;

namespace ApartmentManager.Singletons
{
   public class BmSingleton
    {
        private static BmSingleton _instance;
        public static BmSingleton Instance => _instance ?? (_instance = new BmSingleton());

        public ObservableCollection<Apartment> Apartments { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Resident> Residents { get; set; }
        public ObservableCollection<Defect> Defects { get; set; }

        private BmSingleton()
        {
            Users = new ObservableCollection<User>();
            Residents = new ObservableCollection<Resident>();
        }
    }
}

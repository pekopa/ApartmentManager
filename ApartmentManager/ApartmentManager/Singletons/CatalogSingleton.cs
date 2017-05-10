using System.Collections.ObjectModel;
using ApartmentManager.Model;

namespace ApartmentManager.Singletons
{
    public class CatalogSingleton
    {
        private static CatalogSingleton instance = new CatalogSingleton();

        public static CatalogSingleton Instance => instance;

        
        public Apartment Apartment { get; set; }
        public ObservableCollection<Resident> Residents { get; set; }
        private CatalogSingleton()
        {                                         
           Residents = new ObservableCollection<Resident>();
           
        }
    }
}

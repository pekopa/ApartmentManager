using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Model
{
    public class CatalogSingleton
    {
        private static CatalogSingleton instance = new CatalogSingleton();

        public static CatalogSingleton Instance => instance;

        
        public Apartment Apartment { get; set; }
        public ObservableCollection<Resident> Residents { get; set; }
        private CatalogSingleton()
        {                                         
           
            Residents.Add(new Resident("Donis","banana",12345,new DateTime(1990,07,26,0,0,0,0), "Donis@donis.lt",1,1));
        }
    }
}

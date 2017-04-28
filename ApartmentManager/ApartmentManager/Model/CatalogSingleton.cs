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

        public ObservableCollection<User> User { get; set; }

        private CatalogSingleton()
        {
            User = new ObservableCollection<User>();
            User.Add(new User("Bibis","Kiausiai",3214568, new DateTime(2017, 1, 5, 2, 27, 0),"Bibis@mail.com",1));
        }
    }
}

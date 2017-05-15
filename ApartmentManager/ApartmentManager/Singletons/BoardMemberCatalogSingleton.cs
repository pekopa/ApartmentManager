using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ApartmentManager.Model
{
   public class BoardMemberCatalogSingleton
    {
        private static BoardMemberCatalogSingleton instance = new BoardMemberCatalogSingleton();

        public static BoardMemberCatalogSingleton Instance => instance;

        public ObservableCollection<Apartment> Apartment { get; set; }
        public ObservableCollection<User> User { get; set; }
        public ObservableCollection<Resident> Residents { get; set; }      
        public ObservableCollection<Defect> Defects { get; set; }
        private BoardMemberCatalogSingleton()
        {
            Apartment = new ObservableCollection<Apartment>();

            User = new ObservableCollection<User>();
            //User.Add(new User("Bibis", "Kiausiai", "3214568", new DateTime(2017, 1, 5, 2, 27, 0), "Bibis@mail.com", 1));
            //Apartment = new ObservableCollection<Apartment>();
            //Apartment.Add(new Apartment(1, "30 Square meters", 2, "200", 0, "adresas"));
            //Apartment.Add(new Apartment(2, "40 Square meters", 4, "300", 1, "kvaerkebyvej"));
            //Apartment.Add(new Apartment(3, "28 Square meters", 1, "125", 0, "ugandavej"));

            Residents = new ObservableCollection<Resident>();
            //Residents.Add(new Resident("Bibis", "Kiausiai", 3214568, new DateTime(2017, 1, 5, 0, 0, 0), "Bibis@mail.com", 1));
            //Residents.Add(new Resident("Bibis", "Kiausiai", 3214568, new DateTime(2017, 1, 5, 0, 0, 0), "Bibis@mail.com", 1));
            //Residents.Add(new Resident("Bibis", "Kiausiai", 3214568, new DateTime(2017, 1, 5, 0, 0, 0), "Bibis@mail.com", 1));
            //Residents.Add(new Resident("Bibis", "Kiausiai", 3214568, new DateTime(2017, 1, 5, 0, 0, 0), "Bibis@mail.com", 1));

            Defects = new ObservableCollection<Defect>();
            //Defects.Add(new Defect(1, 2, "Leaking downpipe", DateTime.Now, new Image(), new Image(), new Image(), "downpipe will explode, do something!", "hello", "Not fixed"));
            //Defects.Add(new Defect(1, 2, "Leaking downpipe", DateTime.Now, new Image(), new Image(), new Image(), "downpipe will explode, do something!", "hello", "Not fixed"));
            //Defects.Add(new Defect(1, 2, "Leaking downpipe", DateTime.Now, new Image(), new Image(), new Image(), "downpipe will explode, do something!", "hello", "Fixed"));
        }
    }
}

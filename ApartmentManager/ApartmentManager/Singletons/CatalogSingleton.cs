using System;
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
        public ObservableCollection<Defect> Defects { get; set; }
        public ObservableCollection<DefectPicture> DefectPictures { get; set; }
        public ObservableCollection<DefectPicture> DefectPictures2 { get; set; }
        public Defect Defect { get; set; }

        private CatalogSingleton()
        {
            
            Residents = new ObservableCollection<Resident>();
            Defects = new ObservableCollection<Defect>();
            DefectPictures = new ObservableCollection<DefectPicture>();
            DefectPictures2 = new ObservableCollection<DefectPicture>();
        }
    }
}

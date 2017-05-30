using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ApartmentManager.Annotations;
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
        public int DefectId { get; set; }
       
        public ObservableCollection<DefectComment> DefectComments { get; set; }
        public Defect Defect { get; set; }
        private CatalogSingleton()
        {
            DefectComments = new ObservableCollection<DefectComment>();
            Residents = new ObservableCollection<Resident>();
            Defects = new ObservableCollection<Defect>();
            DefectPictures = new ObservableCollection<DefectPicture>();
            
        }
       
    }
}

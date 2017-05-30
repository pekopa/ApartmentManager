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
        ////////// Singleton //////////
        private static CatalogSingleton _instance;
        public static CatalogSingleton Instance => _instance ?? (_instance = new CatalogSingleton());
        ////////// For Apartment //////////
        public Apartment Apartment { get; set; }
        ////////// For Residents //////////
        public ObservableCollection<Resident> Residents { get; set; }
        ////////// For Defects //////////
        public ObservableCollection<Defect> Defects { get; set; }
        public ObservableCollection<DefectPicture> DefectPictures { get; set; }        
        public ObservableCollection<DefectComment> DefectComments { get; set; }
        public Defect Defect { get; set; }
        public int DefectId { get; set; }
        ////////// Constructor //////////
        private CatalogSingleton()
        {
            DefectComments = new ObservableCollection<DefectComment>();
            Residents = new ObservableCollection<Resident>();
            Defects = new ObservableCollection<Defect>();
            DefectPictures = new ObservableCollection<DefectPicture>();    
        }   
    }
}

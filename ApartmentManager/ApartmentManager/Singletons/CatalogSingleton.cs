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
        public ApartmentChange SelectedChange { get; set; }
        ////////// For Defects //////////
        public ObservableCollection<ApartmentChange> ApartmentChanges { get; set; }
        public Defect SelectedDefect { get; set; }     
        ////////// Constructor //////////
        private CatalogSingleton()
        {
            ApartmentChanges = new ObservableCollection<ApartmentChange>();
            Residents = new ObservableCollection<Resident>();
            Defects = new ObservableCollection<Defect>();
            SelectedDefect = new Defect();
            SelectedChange = new ApartmentChange();
        }   
    }
}

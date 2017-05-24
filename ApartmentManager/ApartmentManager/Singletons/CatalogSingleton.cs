using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ApartmentManager.Annotations;
using ApartmentManager.Model;

namespace ApartmentManager.Singletons
{
    public class CatalogSingleton : INotifyPropertyChanged
    {
        private static CatalogSingleton instance = new CatalogSingleton();

        public static CatalogSingleton Instance => instance;


        public Apartment Apartment { get; set; }
        public ObservableCollection<Resident> Residents { get; set; }
        public ObservableCollection<Defect> defects { get; set; }
        public ObservableCollection<DefectPicture> DefectPictures { get; set; }
        public ObservableCollection<DefectPicture> DefectPictures2 { get; set; }
        public Defect Defect { get; set; }

        private CatalogSingleton()
        {
            
            Residents = new ObservableCollection<Resident>();
            defects = new ObservableCollection<Defect>();
            DefectPictures = new ObservableCollection<DefectPicture>();
            DefectPictures2 = new ObservableCollection<DefectPicture>();
        }
        public ObservableCollection<Defect> Defects
        {
            get => this.defects;
            set
            {
                this.defects = value;
                OnPropertyChanged(nameof(Defect));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

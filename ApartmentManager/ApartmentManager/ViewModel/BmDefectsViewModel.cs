using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ApartmentManager.Annotations;
using ApartmentManager.Common;
using ApartmentManager.Model;
using ApartmentManager.Singletons;
using ApartmentManager.Handler;
using System.Collections.Generic;

namespace ApartmentManager.ViewModel
{
    public class BmDefectsViewModel : INotifyPropertyChanged
    {
        public BmSingleton BmSingleton { get; } = BmSingleton.Instance;
        public BmDefectsHandler BmDefectsHandler { get; }
        
        public ICommand CreateDefectCommand { get; }
        public ICommand DeleteDefectCommand { get; }
        public ICommand UpdateDefectCommand { get; }
        public ICommand ClearDefectTemplateCommand { get; }
        public ICommand GetDefectsCommand { get; }
        public ICommand UploadDefectPictureCommand { get; }
        public ICommand UploadDefectPictureTempCommand { get; }
        public ICommand DeleteDefectPictureCommand { get; }
        public ICommand DeleteDefectPictureTempCommand { get; }
        public ICommand CreateDefectCommentCommand { get; }
        
        private static Defect _defectTemplate = new Defect();
        private static DefectPicture _selectedDefectPicture = new DefectPicture();
        private static List<DefectPicture> _deletedDefectPictures = new List<DefectPicture>();
        private static List<DefectPicture> _addedDefectPictures = new List<DefectPicture>();
        private static DefectComment _newDefectComment = new DefectComment();

        public BmDefectsViewModel()
        {
            BmDefectsHandler = new BmDefectsHandler(this);

            CreateDefectCommand = new RelayCommand(BmDefectsHandler.CreateDefect);
            DeleteDefectCommand = new RelayCommand(BmDefectsHandler.DeleteDefect);
            UpdateDefectCommand = new RelayCommand(BmDefectsHandler.UpdateDefect);
            ClearDefectTemplateCommand = new RelayCommand(BmDefectsHandler.ClearDefectTemplate);
            UploadDefectPictureCommand = new RelayCommand(BmDefectsHandler.UploadDefectPicture);
            DeleteDefectPictureCommand = new RelayCommand(BmDefectsHandler.DeleteDefectPicture);
            DeleteDefectPictureTempCommand = new RelayCommand(BmDefectsHandler.DeleteDefectPictureTemp);
            GetDefectsCommand = new RelayCommand(BmDefectsHandler.GetDefects);
            CreateDefectCommentCommand = new RelayCommand(BmDefectsHandler.CreateDefectComment);
        }

        public Defect DefectTemplate
        {
            get => _defectTemplate;
            set
            {
                _defectTemplate = value;
                OnPropertyChanged();
            }
        }

        public DefectPicture SelectedDefectPicture
        {
            get => _selectedDefectPicture;
            set
            {
                _selectedDefectPicture = value;
                OnPropertyChanged();
            }
        }

        public List<DefectPicture> DeletedDefectPictures
        {
            get => _deletedDefectPictures;
            set
            {
                _deletedDefectPictures = value;
            }
        }

        public List<DefectPicture> AddedDefectPictures
        {
            get => _addedDefectPictures;
            set
            {
                _addedDefectPictures = value;
            }
        }

        public DefectComment NewDefectComment
        {
            get => _newDefectComment;
            set
            {
                _newDefectComment = value;
                OnPropertyChanged();
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

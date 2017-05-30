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
    public class BmChangesViewModel : INotifyPropertyChanged
    {
        public BmSingleton BmSingleton { get; } = BmSingleton.Instance;
        public BmChangesHandler BmChangesHandler { get; }

        public ICommand CreateChangeCommand { get; }
        public ICommand DeleteChangeCommand { get; }
        public ICommand UpdateChangeCommand { get; }
        public ICommand ClearChangeTemplateCommand { get; }
        public ICommand GetChangesCommand { get; }
        public ICommand UploadChangeDocumentCommand { get; }
        public ICommand UploadChangeDocumentTempCommand { get; }
        public ICommand DeleteChangeDocumentCommand { get; }
        public ICommand DeleteChangeDocumentTempCommand { get; }
        public ICommand CreateChangeCommentCommand { get; }

        private static ApartmentChange _changeTemplate = new ApartmentChange();
        private static ChangeDocument _selectedChangeDocument = new ChangeDocument();
        private static List<ChangeDocument> _deletedChangeDocuments = new List<ChangeDocument>();
        private static List<ChangeDocument> _addedChangeDocuments = new List<ChangeDocument>();
        private static ChangeComment _newChangeComment = new ChangeComment();

        public BmChangesViewModel()
        {
            BmChangesHandler = new BmChangesHandler(this);

            CreateChangeCommand = new RelayCommand(BmChangesHandler.CreateChange);
            DeleteChangeCommand = new RelayCommand(BmChangesHandler.DeleteChange);
            UpdateChangeCommand = new RelayCommand(BmChangesHandler.UpdateChange);
            ClearChangeTemplateCommand = new RelayCommand(BmChangesHandler.ClearChangeTemplate);
            UploadChangeDocumentCommand = new RelayCommand(BmChangesHandler.UploadChangeDocument);
            DeleteChangeDocumentCommand = new RelayCommand(BmChangesHandler.DeleteChangeDocument);
            DeleteChangeDocumentTempCommand = new RelayCommand(BmChangesHandler.DeleteChangeDocumentTemp);
            GetChangesCommand = new RelayCommand(BmChangesHandler.GetChanges);
            CreateChangeCommentCommand = new RelayCommand(BmChangesHandler.CreateChangeComment);
        }

        public ApartmentChange ChangeTemplate
        {
            get => _changeTemplate;
            set
            {
                _changeTemplate = value;
                OnPropertyChanged();
            }
        }

        public ChangeDocument SelectedChangeDocument
        {
            get => _selectedChangeDocument;
            set
            {
                _selectedChangeDocument = value;
                OnPropertyChanged();
            }
        }

        public List<ChangeDocument> DeletedChangeDocuments
        {
            get => _deletedChangeDocuments;
            set
            {
                _deletedChangeDocuments = value;
            }
        }

        public List<ChangeDocument> AddedChangeDocuments
        {
            get => _addedChangeDocuments;
            set
            {
                _addedChangeDocuments = value;
            }
        }

        public ChangeComment NewChangeComment
        {
            get => _newChangeComment;
            set
            {
                _newChangeComment = value;
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

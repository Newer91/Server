using BandD.Serwis.Model.Dictionaries;
using BandD.Serwis.Tools.ClientTools;
using BandD.Serwis.ViewModel.Class;
using ClassViewModel.Dictionaries;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace BandD.Serwis.ViewModel.Dictionaries.Client
{
    public class ClientViewModel : BaseViewClass
    {
        private ClientModel model;

        private ObservableCollection<ActiveItem> activeComboBox;
        private ObservableCollection<ClientView> clients;
        private ClientView client;
        private ActiveItem activity;
        private string shortName;
        private int nip;
        private int regon;

        #region public propertis

        public ObservableCollection<ActiveItem> ActiveComboBox
        {
            get { return activeComboBox; }
            set { activeComboBox = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ClientView> Clients
        {
            get { return clients; }
            set { clients = value; OnPropertyChanged(); }
        }

        public ActiveItem Active
        {
            get { return activity; }
            set { activity = value; OnPropertyChanged(); }
        }

        public ClientView Client
        {
            get { return client; }
            set { client = value; OnPropertyChanged(); }
        }

        public ClientViewModel()
        {
            model = new ClientModel();
            ActiveComboBox = new ActiveItem().getActiveList();
            Active = ActiveComboBox[0];
        }

        public string ShortName
        {
            get { return shortName; }
            set { shortName = value; OnPropertyChanged(); }
        }

        public int Nip
        {
            get { return nip; }
            set { nip = value; OnPropertyChanged(); }
        }

        public int Regon
        {
            get { return regon; }
            set { regon = value; OnPropertyChanged(); }
        }

        public ICommand Search { get { return new RelayCommand(SearchExecute, null); } }
        public ICommand Remove { get { return new RelayCommand(RemoveExecute, null); } }

        #endregion

        private void RemoveExecute()
        {
            var question = MessageBox.Show("Czy na pewno chcesz usunąc wskazany element?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
                if (!model.RemoveElement(Client.ClientId))
                    ClientMessage.ServerErrorMessage();
            SearchExecute();
        }

        public void SearchExecute()
        {
            Clients = model.GetDataFromClient(ShortName,Nip,Regon,Active.Value);
        }
    }
}

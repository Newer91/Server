using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.Tools.Extension;
using BandD.Serwis.ViewModel.Class;
using ClassViewModel.Dictionaries;
using System;
using BandD.Serwis.Model.Dictionaries;
using BandD.Serwis.Tools.ClientTools;
using System.Windows;

namespace BandD.Serwis.ViewModel.Dictionaries.Client
{
    public class ClientDetailViewModel : BaseViewClass
    {
        private ClientModel model;
        private ClientView client { get; set; }
        private string cancelButtonName;

        public ClientView Client
        {
            get { return client; }
            set { client = value; OnPropertyChanged(); }
        }

        public ClientDetailViewModel(ViewType viewType)
        {
            ViewType = viewType;
            model = new ClientModel();
            SetViewMode(viewType);
        }

        private void SetViewMode(ViewType viewType)
        {
            if (viewType == ViewType.View)
            {
                IsEnable = false;
                IsReadOnly = true;
                CancelButtonName = "Zamknij";
            }
            else
            {
                IsEnable = true;
                IsReadOnly = false;
                CancelButtonName = "Anuluj";
            }

            if (viewType == ViewType.New)
                Client = new ClientView();

            Title = ClientTools.SetTitleToDetailView(viewType);
        }

        public bool SaveChange()
        {
            bool result = false;
            bool serverResult;
            var question = MessageBox.Show("Czy chcesz zapisać dane?", "Informacja", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
            {
                if ((ClientTools.ValidateProperty(Client.Name) || ClientTools.ValidateProperty(Client.ShortName)))
                {
                    if (ViewType == ViewType.Edit)
                        serverResult = result = model.SaveChange(Client);
                    else
                        serverResult = result = AddNewItem();

                    if (!serverResult)
                    {
                        ClientMessage.ServerErrorMessage();
                        result = false;
                    }
                }
                else
                {
                    MessageBox.Show("Pole nazwa lub nazwa krótka musi być uzupełnione.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    result = false;
                }
            }
            else
                return false;

            if (result)
                MessageBox.Show("Dane zapisano", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

            return false;
        }

        private bool AddNewItem()
        {
            Client.ClientId = Guid.NewGuid();
            return model.AddNewItem(Client);
        }
    }
}

using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Model.Dictionaries;
using BandD.Serwis.Tools.ClientTools;
using BandD.Serwis.Tools.Extension;
using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Class;
using System.Windows;
using System;

namespace BandD.Serwis.ViewModel.Dictionaries.Adress
{
    public class AddressDetailViewModel: BaseViewClass
    {
        private AddressModel model;
        
        private AddressesView address;

        #region Public properties

        public AddressesView Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged(); }
        }
        
        #endregion

        public AddressDetailViewModel(ViewType viewType)
        {
            ViewType = viewType;
            SetViewMode(viewType);
            model = new AddressModel();
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

            Title = ClientTools.SetTitleToDetailView(viewType);
        }

        public bool SaveChange()
        {
            bool result = false;
            bool serverResult;
            var question = MessageBox.Show("Czy chcesz zapisać dane?", "Informacja", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
            {
                if (ClientTools.ValidateProperty(address.City) && ClientTools.ValidateProperty(address.Street) && ClientTools.ValidateProperty(address.Number) && ClientTools.ValidateProperty(address.PostCode))
                {
                    if (ViewType == ViewType.Edit)
                        serverResult = result = model.SaveChange(address);
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
                    MessageBox.Show("Pole miasto, ulica,numer i kod pocztowy nie mogą być puste", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
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
            address.AddressId = Guid.NewGuid();
            return model.AddNewItem(address);
        }
    }
}

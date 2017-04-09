using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.ViewModel.Class;
using System.Windows.Input;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using BandD.Serwis.Tools.ClientTools;
using BandD.Serwis.Model.Dictionaries;

namespace BandD.Serwis.ViewModel.Dictionaries.Adress
{
    public class AddressViewModel : BaseViewClass
    {
        private AddressModel model;

        private ObservableCollection<AddressesView> addressList;

        private AddressesView address;
        private string city;
        private string street;
        private string number;

        public AddressViewModel()
        {
            model = new AddressModel();
        }

        public ObservableCollection<AddressesView> AddressList
        {
            get { return addressList; }
            set { addressList = value; OnPropertyChanged(); }
        }

        public AddressesView Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged(); }
        }

        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged(); }
        }

        public string Street
        {
            get { return street; }
            set { street = value; OnPropertyChanged(); }
        }

        public string Number
        {
            get { return number; }
            set { number = value; OnPropertyChanged(); }
        }


        public ICommand Search { get { return new RelayCommand(SearchExecute, null); } }
        public ICommand Remove { get { return new RelayCommand(RemoveExecute, null); } }

        public void SearchExecute()
        {
            AddressList = model.getDataFromAddresses(City, Street, Number);
        } 

        private void RemoveExecute()
        {
            var question = MessageBox.Show("Czy na pewno chcesz usunąc wskazany element?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
                if (!model.RemoveElement(Address.AddressId))
                    ClientMessage.ServerErrorMessage();
            SearchExecute();
        }
    }
}

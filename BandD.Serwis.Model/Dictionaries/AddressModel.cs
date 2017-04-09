using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Model.DictionarySerivce;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BandD.Serwis.Model.Dictionaries
{
    public class AddressModel
    {
        private DictionariesServiceClient service = new DictionariesServiceClient();

        public ObservableCollection<AddressesView> getDataFromAddresses(string city, string street, string number)
        {            
            string City = city == null ? string.Empty : city;
            string Street = street == null ? string.Empty : street;
            string Number = number == null ? string.Empty : number;

            var items = service.GetDataFromAddress(City,Street,Number).ToList();
            var result = new ObservableCollection<AddressesView>();
            foreach (var item in items)
            {
                result.Add(item);
            }

            return result;
        }

        public bool SaveChange(AddressesView stats)
        {
            return service.UpdateElementAddress(stats);
        }

        public bool AddNewItem(AddressesView address)
        {
            return service.AddElementToAddress(address);
        }

        public bool RemoveElement(Guid id)
        {
            return service.RemoveElementFromAddress(id);
        }
    }
}

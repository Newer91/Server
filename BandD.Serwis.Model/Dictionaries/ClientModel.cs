using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassViewModel.Dictionaries;
using BandD.Serwis.Model.DictionarySerivce;

namespace BandD.Serwis.Model.Dictionaries
{
    public class ClientModel
    {
        private DictionariesServiceClient service = new DictionariesServiceClient();

        public ObservableCollection<ClientView> GetDataFromClient(string shortName, int nip, int regon, bool? value)
        {
            throw new NotImplementedException();
        }

        public bool RemoveElement(Guid clientId)
        {
            throw new NotImplementedException();
        }


    }
}

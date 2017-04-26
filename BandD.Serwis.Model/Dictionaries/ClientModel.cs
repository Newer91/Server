using System;
using System.Collections.ObjectModel;
using ClassViewModel.Dictionaries;

namespace BandD.Serwis.Model.Dictionaries
{
    public class ClientModel: BaseModel
    {       

        public ObservableCollection<ClientView> GetDataFromClient(string shortName, int nip, int regon, bool? value)
        {
            throw new NotImplementedException();
        }

        public bool RemoveElement(Guid clientId)
        {
            throw new NotImplementedException();
            //return service.RemoveElementFromClients(clientId);
        }

        public bool AddNewItem(ClientView client)
        {
            throw new NotImplementedException();
            //return service.AddElementToClients(client);
        }

        public bool SaveChange(ClientView client)
        {
            throw new NotImplementedException();
            //return service.UpdateElementClients(client);
        }
    }
}

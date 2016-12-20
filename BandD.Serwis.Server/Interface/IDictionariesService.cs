using BandD.Serwis.Domain;
using System.Collections.Generic;
using System.ServiceModel;

namespace BandD.Serwis.Server.Interface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDictionariesService" in both code and config file together.
    [ServiceContract]
    public interface IDictionariesService
    {
        [OperationContract]
        List<SlOrderStat> getDataFromSlOrderStat(string name, bool activity);
    }
}

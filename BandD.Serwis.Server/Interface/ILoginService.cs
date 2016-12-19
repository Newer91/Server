using System.ServiceModel;

namespace BandD.Serwis.Server.Interface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoginService" in both code and config file together.
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        bool Autorauthorization(string password, string userName);
    }
}

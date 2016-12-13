using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using BandD.Serwis.Class;

namespace BandD.Serwis.Server.Interface
{
    [ServiceContract]
    public interface ILogin
    {
        [OperationContract]
        List<Login> login(); 
    }
}

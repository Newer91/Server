using BandD.Serwis.Model.LoginService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using BandD.Serwis.Tools.ServerTools;

namespace BandD.Serwis.Model
{
    public class LoginModel
    {
        private LoginServiceClient service = new LoginServiceClient();
        
        public bool Autorauthorization(SecureString password, string userName)
        {
            return service.Autorauthorization(SecureTools.convertToUNSecureString(password), userName);
        }
    }
}

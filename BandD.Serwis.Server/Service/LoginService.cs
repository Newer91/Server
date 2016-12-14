using BandD.Serwis.Server.Interface;
using System.Security;

namespace BandD.Serwis.Server.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in both code and config file together.
    public class LoginService : ILoginService
    {
        public bool Autorauthorization(SecureString password)
        {
            return true;
        }
    }
}

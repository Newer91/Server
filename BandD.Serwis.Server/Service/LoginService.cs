using BandD.Serwis.Server.EntityContexClass;
using BandD.Serwis.Server.Interface;
using System.Security;
using System.Linq;
using BandD.Serwis.Tools.ServerTools;

namespace BandD.Serwis.Server.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in both code and config file together.
    public class LoginService : ILoginService
    {
        public bool Autorauthorization(string password, string userName)
        {
            bool result = false;
            using (var context = new ServisContex())
            {
                var login = context.Logins
                    .Where(l => l.UserName == userName)
                    .FirstOrDefault();
                
                if (login.Password == password)
                    return true;
            }

            return result;
        }
    }
}

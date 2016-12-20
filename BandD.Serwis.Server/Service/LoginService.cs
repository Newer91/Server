using BandD.Serwis.Server.EntityContexClass;
using BandD.Serwis.Server.Interface;
using System.Linq;
using System;
using BandD.Serwis.Tools.ServerTools;

namespace BandD.Serwis.Server.Service
{
    public class LoginService : ILoginService
    {
        private string conectionString = Extension.GetConnectionString(Environment.MachineName);

        public bool Autorauthorization(string password, string userName)
        {
            using (var ctx = new ServisContex(conectionString))
            {
                bool result = false;
                var login = ctx.Users
                    .Where(l => l.UserName == userName)
                    .FirstOrDefault();

                if (login.Password == password)
                    return true;
                return result;
            }
        }
    }
}

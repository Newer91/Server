using BandD.Serwis.Server.EntityContexClass;
using BandD.Serwis.Server.Interface;
using System.Linq;
using System;
using BandD.Serwis.Tools.ServerTools;
using System.ServiceModel;

namespace BandD.Serwis.Server.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class LoginService : ILoginService
    {
        private readonly string connectionString;
        private ServisContex ctx;

        public LoginService()
        {
            connectionString = Extension.GetConnectionString(Environment.MachineName);
        }

        public LoginService(ServisContex ctx)
        {
            this.ctx = ctx;
            connectionString = Extension.GetConnectionString(Environment.MachineName);
        }

        public bool Autorauthorization(string password, string userName)
        {
            bool result = false;
            var login = ctx.Logins
                .Where(l => l.UserName == userName)
                .FirstOrDefault();

            if (login.Password == password)
                return true;
            return result;
        }
    }
}

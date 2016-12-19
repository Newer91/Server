using BandD.Serwis.Server.EntityContexClass;
using BandD.Serwis.Server.Interface;
using System.Linq;
using System;
using BandD.Serwis.Tools.ServerTools;
using System.ServiceModel;

namespace BandD.Serwis.Server.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class LoginService : ILoginService
    {
        private ServisContex ctx;

        public LoginService(ServisContex ctx)
        {
            this.ctx = ctx;
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

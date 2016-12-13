using BandD.Serwis.Class;
using BandD.Serwis.Server.EntityContexClass;
using BandD.Serwis.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandD.Serwis.Server.Service
{
    public class LoginService : ILogin
    {
        private SerwisContex ctx;

        public LoginService()
        {
            ctx = new SerwisContex();
        }

        public List<Login> login()
        {
            List<Login> list = ctx.Logins.ToList();
            return list;
        }
    }
}

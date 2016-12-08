using BandD.Serwis.Class;
using BandD.Serwis.Server.EntityContexClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandD.Serwis.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SerwisContex())
            {
                var login = new Login() { LoginId = Guid.NewGuid(), Active = true, UserName = "blisowski", Role = 'A', Password = "dedra" };
                ctx.Logins.Add(login);
                ctx.SaveChanges();
            }
        }
    }
}

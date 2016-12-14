using BandD.Serwis.Class;
using BandD.Serwis.Server.EntityContexClass;
using BandD.Serwis.Server.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BandD.Serwis.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new ServisContex())
            {
                var login = new Login() { LoginId = Guid.NewGuid(), Active = true, UserName = "blisowski", Role = 'A', Password = "dedra" };
                ctx.Logins.Add(login);
                ctx.SaveChanges();
            }

            ServiceHost hostLogin = null;
            try
            {
                hostLogin = new ServiceHost(typeof(LoginService));
                hostLogin.Open();

                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to terminate Host");
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (hostLogin.State == CommunicationState.Faulted)
                    hostLogin.Abort();
                else
                    hostLogin.Close();
            }
            Console.WriteLine("Server stopped");
            Console.ReadLine();
        }
    }
}

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
        private static string computerName = System.Environment.MachineName;
        static void Main(string[] args)
        {
            string connectionString = string.Empty;
            switch (computerName)
            {
                case "BANDD":
                    connectionString = "SerwisConnectionStringBL";
                    break;
                default:
                    connectionString = "SerwisConnectionStringAS";
                    break;
            }
            
            using (var ctx = new ServisContex(connectionString))
            {
                var login = new Login() { LoginId = Guid.NewGuid(), Active = true, UserName = "blisowski", Role = 'A', Password = "dedra" };
                var login2 = new Login() { LoginId = Guid.NewGuid(), Active = true, UserName = "asieradzan", Role = 'A', Password = "12345" };
                ctx.Logins.Add(login);
                ctx.Logins.Add(login2);
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
            catch (Exception ex)
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

using BandD.Serwis.Server.EntityContexClass;
using BandD.Serwis.Server.Service;
using BandD.Serwis.Tools.ServerTools;
using System;
using System.ServiceModel;

namespace BandD.Serwis.Server
{
    class Program
    {
        private static string computerName = Environment.MachineName;
        static void Main(string[] args)
        {
            using (var ctx = new ServisContex(Extension.GetConnectionString(computerName)))
            {
                InitClass defoultItems = new InitClass(ctx);
                ServiceHost hostLogin = null;
                try
                {
                    var instance = new LoginService(ctx);
                    hostLogin = new ServiceHost(instance);
                    hostLogin.Open();

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
}

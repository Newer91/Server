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
                ServiceHost hostDictionary = null;
                try
                {
                    var LoginInstance = new LoginService(ctx);
                    hostLogin = new ServiceHost(LoginInstance);
                    hostLogin.Open();

                    var DictionariesInstance = new DictionariesService(ctx);
                    hostDictionary = new ServiceHost(DictionariesInstance);
                    hostDictionary.Open();

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

                    if (hostDictionary.State == CommunicationState.Faulted)
                        hostDictionary.Abort();
                    else
                        hostDictionary.Close();
                }
                Console.WriteLine("Server stopped");
                Console.ReadLine();
            }
        }
    }
}

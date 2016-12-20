using BandD.Serwis.Server.EntityContexClass;
using BandD.Serwis.Server.Service;
using BandD.Serwis.Tools.ServerTools;
using System;
using System.ServiceModel;

namespace BandD.Serwis.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostLogin = null;
            ServiceHost hostDictionary = null;
            try
            {
                InitClass defoultItems = new InitClass();
                hostLogin = new ServiceHost(typeof(LoginService));
                hostLogin.Open();

                hostDictionary = new ServiceHost(typeof(DictionariesService));
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

using BandD.Serwis.Server.Service;
using System;
using System.ServiceModel;

namespace BandD.Serwis.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostDictionary = null;
            try
            {
                new InitClass();

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

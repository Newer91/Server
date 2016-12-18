using BandD.Serwis.Class;
using BandD.Serwis.Server.EntityContexClass;
using BandD.Serwis.Server.FTP;
using BandD.Serwis.Server.Service;
using BandD.Serwis.Tools.ServerTools;
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
        private static string computerName = Environment.MachineName;
        private static FTPClass ftp = new FTPClass(computerName);

        static void Main(string[] args)
        {
            ///TODO!
            //if (computerName == "BANDD" || computerName == "DESKTOP-H4L3EG5")
            //    ftp.ftpUploadDev(computerName);
            //else
            //    ftp.ftpUpload(computerName);

            using (var ctx = new ServisContex(Extension.GetConnectionString(computerName)))
            {
                var login = new Login() { LoginId = Guid.NewGuid(), Active = true, UserName = "blisowski", Role = "Admin", Password = SecureTools.CalculateMD5Hash("dedra") };
                var login2 = new Login() { LoginId = Guid.NewGuid(), Active = true, UserName = "asieradzan", Role = "Admin", Password = SecureTools.CalculateMD5Hash("12345") };
                ctx.Logins.Add(login);
                ctx.Logins.Add(login2);
                ctx.SaveChanges();

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

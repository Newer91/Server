using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandD.Serwis.Tools
{
    public static class StaticResource
    {
        public static string ftpUserName = "servis.bartoszlisowski1-admin";
        public static string ftpPassword = "StDP8WK1qa";

        /// <summary>
        /// Adresy do poszczególnych katalogów FTP
        /// </summary>
        public static string ftpAddresConfig = @"ftp://213.108.56.205/config/";
        public static string ftpAddresConfigDev = @"ftp://213.108.56.205/config/devs";
        public static string ftpAddresLicence = @"ftp://213.108.56.205/licence/";

    }
}

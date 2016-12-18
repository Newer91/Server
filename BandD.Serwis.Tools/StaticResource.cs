using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandD.Serwis.Tools
{
    public static class StaticResource
    {
        public readonly static string ftpUserName = "servis.bartoszlisowski1-admin";
        public readonly static string ftpPassword = "StDP8WK1qa";

        /// <summary>
        /// Adresy do poszczególnych katalogów FTP
        /// </summary>
        public readonly static string ftpAddresConfig = @"ftp://213.108.56.205/config/";
        public readonly static string ftpAddresConfigDev = @"ftp://213.108.56.205/config/devs";
        public readonly static string ftpAddresLicence = @"ftp://213.108.56.205/licence/";

    }
}

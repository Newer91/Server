using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandD.Serwis.Tools.ServerTools
{
    public static class Extension
    {
        public static string GetConnectionString(string computerName)
        {
            string result = string.Empty;

            switch (computerName)
            {
                case "BANDD":
                    result = "SerwisConnectionStringBL";
                    break;
                case "DESKTOP-H4L3EG5":
                    result = "SerwisConnectionStringAS";
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}

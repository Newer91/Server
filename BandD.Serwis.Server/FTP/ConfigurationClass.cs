using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandD.Serwis.Server.FTP
{
    public class ConfigurationClass
    {
        private string fileName = "configuration.txt";
        private string computerName;
        private List<string> configList = new List<string>();

        public ConfigurationClass(string computerName)
        {
            this.computerName = computerName;
            createConfigurationList();
        }

        public void CreateConfigFile()
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (FileStream fs = new FileStream(fileName, FileMode.CreateNew))
            using (StreamWriter writer = new StreamWriter(fs))
            {
                foreach (var element in configList)
                    writer.Write(element);
            }
        }

        private void createConfigurationList()
        {
            configList.Add("ComputerName=" + computerName + ";");
        }
    }
}

using System.Collections.Generic;
using System.IO;

namespace BandD.Serwis.Server.FTP
{
    public class ConfigurationClass
    {
        private string computerName;
        private List<string> configList = new List<string>();

        public ConfigurationClass(string computerName)
        {
            this.computerName = computerName;
            createConfigurationList();
        }

        public void CreateConfigFile()
        {
            string fileName = computerName + "Configuration.txt";

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

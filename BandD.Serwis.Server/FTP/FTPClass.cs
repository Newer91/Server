using BandD.Serwis.Tools;
using System.IO;
using System.Net;

namespace BandD.Serwis.Server.FTP
{
    public class FTPClass
    {
        WebClient webClientDowload;
        NetworkCredential networkCredential;
        ConfigurationClass configClass;
        string computerName;

        public FTPClass(string computerName)
        {
            this.computerName = computerName;
            networkCredential = new NetworkCredential(StaticResource.ftpUserName, StaticResource.ftpPassword);
            createWebClient();
            configClass = new ConfigurationClass(computerName);
        }

        private void createWebClient()
        {
            webClientDowload = new WebClient();
            webClientDowload.Credentials = networkCredential;
        }

        public void ftpUploadDev(string computerName)
        {
            configClass.CreateConfigFile();
            Upload(ftpAcces.Dev);           
        }

        public void ftpUpload(string computerName)
        {
            configClass.CreateConfigFile();
            Upload(ftpAcces.Normal);
        }

        private void Upload(ftpAcces acces)
        {
            FtpWebRequest webClientUpload;
            if (acces == ftpAcces.Dev)
                webClientUpload = (FtpWebRequest)WebRequest.Create(StaticResource.ftpAddresConfigDev + "/" + (computerName + "Configuration.txt"));
            else
                webClientUpload = (FtpWebRequest)WebRequest.Create(StaticResource.ftpAddresConfig + "/" + (computerName + "Configuration.txt"));

            webClientUpload.Method = WebRequestMethods.Ftp.UploadFile;
            webClientUpload.Credentials = networkCredential;

            webClientUpload.KeepAlive = true;
            webClientUpload.UseBinary = true;

            FileInfo fileInfo = new FileInfo(computerName + "Configuration.txt");
            webClientUpload.ContentLength = fileInfo.Length;

            byte[] buffer = new byte[4097];
            int bytes = 0;
            int total_bytes = (int)fileInfo.Length;


            FileStream filseStream = fileInfo.OpenRead();
            Stream rs = webClientUpload.GetRequestStream();
            while (total_bytes > 0)
            {
                bytes = filseStream.Read(buffer, 0, buffer.Length);
                rs.Write(buffer, 0, bytes);
                total_bytes = total_bytes - bytes;
            }

            filseStream.Close();
            rs.Close();
        }
    }

    public enum ftpAcces
    {
        Dev,
        Normal
    }
}

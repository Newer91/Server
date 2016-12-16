using BandD.Serwis.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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

        internal void ftpUploadDev()
        {
            configClass.CreateConfigFile();
            FtpWebRequest webClientUpload;
            webClientUpload = (FtpWebRequest)WebRequest.Create(StaticResource.ftpAddresConfigDev + "/" + "config.txt");
        }

        public void ftpUpload()
        {
            FtpWebRequest webClientUpload;
            ///TODO:::::
            webClientUpload = (FtpWebRequest)WebRequest.Create(StaticResource.ftpAddresConfig + "/" + "config.txt");
            webClientUpload.Method = WebRequestMethods.Ftp.UploadFile;
            webClientUpload.Credentials = networkCredential;

            webClientUpload.KeepAlive = true;
            webClientUpload.UseBinary = true;

            FileInfo fileInfo = new FileInfo("test.txt");
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
}

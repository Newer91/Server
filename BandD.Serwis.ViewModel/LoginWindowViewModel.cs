using BandD.Serwis.Class;
using BandD.Serwis.Model;
using BandD.Serwis.ViewModel.Class;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace BandD.Serwis.ViewModel
{
    public class LoginWindowViewModel : BaseViewClass
    {

        private LoginModel model = new LoginModel();
        private Login login;
        private string ipServer;
        private SecureString securePassword;
        private string name = "blisowski";

        public Login Login
        {
            get { return login; }
            set { login = value; OnPropertyChanged(); }
        }

        public string IpServer
        {
            get { return ipServer; }
            set { ipServer = value; OnPropertyChanged(); }
        }

        public SecureString SecurePassword
        {
            get { return securePassword; }
            set { securePassword = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public bool Authorization()
        {
            return model.Autorauthorization(securePassword,name);
        }

    }
}

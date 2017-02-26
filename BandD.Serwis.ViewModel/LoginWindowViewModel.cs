using BandD.Serwis.ViewModel.Class;
using BandD.Serwis.ClassViewModel.Dictionaries;
using System.Security;
using BandD.Serwis.Model.Dictionaries;

namespace BandD.Serwis.ViewModel
{
    public class LoginWindowViewModel : BaseViewClass
    {
        private UserModel model = new UserModel();
        private UserView login;
        private string ipServer;
        private SecureString securePassword;
        private string name = "blisowski";

        public UserView Login
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

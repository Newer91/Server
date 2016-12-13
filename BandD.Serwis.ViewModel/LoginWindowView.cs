using BandD.Serwis.Class;
using BandD.Serwis.ViewModel.Class;
using System.Windows;
using System.Windows.Input;

namespace BandD.Serwis.ViewModel
{
    public class LoginWindowView : BaseViewClass
    {
        private Login login;
        private string ipServer;
        private string password;
        private string name;

        public Login Login
        {
            get { return login; }
            set { login = value;OnPropertyChanged(); }
        }

        public string IpServer
        {
            get { return ipServer; }
            set { ipServer = value;OnPropertyChanged(); }
        }

        public string Password
        {
            get { return password; }
            set { password = value;OnPropertyChanged(); }
        }

        public string Name
        {
            get { return name; }
            set { name = value;OnPropertyChanged(); }
        }


        public ICommand LoginIn { get { return new RelayCommand(logiIn, null); } }
    //    public ICommand Close { get { return new RelayCommand(close, null); } }

        private void logiIn()
        {
            //var win = new Window();
        }


        //przycisk zaloguj
        //przycis zamknij

        //pobierz dane do listy
    }
}

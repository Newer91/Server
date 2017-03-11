using BandD.Serwis.ViewModel.Class;
using BandD.Serwis.ClassViewModel.Dictionaries;
using System.Security;
using BandD.Serwis.Model.Dictionaries;
using System.Windows;

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
            if (securePassword.Length < 4)
            {
                MessageBox.Show("Hasło nie może być krótsze niż 5 znaków", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            var result = model.Autorauthorization(securePassword, name);

            if (!result)            
                MessageBox.Show("Brak użytkownia o podanych danych.", "Błąd", MessageBoxButton.OKCancel, MessageBoxImage.Error);       
            return result;
        }

    }
}

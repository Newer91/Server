using BandD.Serwis.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace BandD.Serwis.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        LoginWindowViewModel loginViewModel = new LoginWindowViewModel();
        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = loginViewModel;
        }

        private void passwordBoxkHaslo_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).SecurePassword = ((PasswordBox)sender).SecurePassword;
            }
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (loginViewModel.Authorization())
            {
                MainWindow mw = new MainWindow();
                this.Close();
                mw.ShowDialog();
            }
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

using BandD.Serwis.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BandD.Serwis.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        LoginWindowViewModel vm = new LoginWindowViewModel();
        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
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
            if (vm.Authorization())
            {
                MainWindow mw = new MainWindow();
                this.Close();
                mw.ShowDialog();
            }
            else
            {
                MessageBox.Show("Brak użytkownia o podanych danych.", "Błąd", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

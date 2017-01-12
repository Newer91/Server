using BandD.Serwis.ViewModel.Dictionaries.Users;
using System.Windows;

namespace BandD.Serwis.Client.Dictionaries.User
{
    public partial class Users : Window
    {
        UserStatusViewModel userViewModel = new UserStatusViewModel();
        public Users()
        {
            InitializeComponent();
            this.DataContext = userViewModel;
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

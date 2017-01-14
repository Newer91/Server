using BandD.Serwis.Tools.ServerTools.Extension;
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

        private void buttonView_Click(object sender, RoutedEventArgs e)
        {
            UsersDetail detail = new UsersDetail(ViewType.View, userViewModel.User);
            detail.ShowDialog();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            UsersDetail detail = new UsersDetail(ViewType.New, null);
            detail.ShowDialog();
            userViewModel.SearchExecute();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            UsersDetail detail = new UsersDetail(ViewType.Edit, userViewModel.User);
            detail.ShowDialog();
            userViewModel.SearchExecute();
        }
    }
}

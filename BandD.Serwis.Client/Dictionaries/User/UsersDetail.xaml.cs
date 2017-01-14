using System.Windows;
using BandD.Serwis.Tools.ServerTools.Extension;
using ClassViewModel.Dictionaries;
using BandD.Serwis.ViewModel.Dictionaries.User;
using System.Windows.Controls;

namespace BandD.Serwis.Client.Dictionaries.User
{
    public partial class UsersDetail : Window
    {
        UserDetailViewModel viewModel;

        public UsersDetail(ViewType view, UserView user)
        {
            InitializeComponent();
            viewModel = new UserDetailViewModel(view);
            if (view == ViewType.New)
                user = new UserView();
            viewModel.User = user;
            DataContext = viewModel;
        }

        private void passwordBoxkHaslo_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).SecurePassword = ((PasswordBox)sender).SecurePassword;
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.SaveChange())
                Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

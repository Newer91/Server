using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Dictionaries.Role;
using System.Windows;

namespace BandD.Serwis.Client.Dictionaries.Role
{
    public partial class Role : Window
    {
        RoleViewModel roleViewModel = new RoleViewModel();

        public Role()
        {
            InitializeComponent();
            this.DataContext = roleViewModel;
        }

        private void buttonView_Click(object sender, RoutedEventArgs e)
        {
            RoleDetail detail = new RoleDetail(ViewType.View, roleViewModel.Role);
            detail.ShowDialog();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            RoleDetail detail = new RoleDetail(ViewType.New,null);
            detail.ShowDialog();
            roleViewModel.SearchExecute();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            RoleDetail detail = new RoleDetail(ViewType.Edit, roleViewModel.Role);
            detail.ShowDialog();
            roleViewModel.SearchExecute();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

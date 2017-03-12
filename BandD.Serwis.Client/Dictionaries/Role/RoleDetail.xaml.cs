using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Dictionaries.Role;
using System.Windows;

namespace BandD.Serwis.Client.Dictionaries.Role
{
    public partial class RoleDetail : Window
    {
        RoleDetailViewModel viewModel;

        public RoleDetail(ViewType view, SlRoleView role)
        {
            InitializeComponent();
            viewModel = new RoleDetailViewModel(view);
            if (view == ViewType.New)
                role = new SlRoleView();
            viewModel.Role = role;
            DataContext = viewModel;
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.SaveChange())
                Close();
        }
    }
}

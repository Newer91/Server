using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Dictionaries.Client;
using System.Windows;

namespace BandD.Serwis.Client.Dictionaries.Client
{
    /// <summary>
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        ClientViewModel viewModel = new ClientViewModel();

        public Client()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
        

        private void buttonView_Click(object sender, RoutedEventArgs e)
        {
            ClientDetail detail = new ClientDetail(ViewType.View, viewModel.Client);
            detail.ShowDialog();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            ClientDetail detail = new ClientDetail(ViewType.Edit, viewModel.Client);
            detail.ShowDialog();
            viewModel.SearchExecute();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            ClientDetail detail = new ClientDetail(ViewType.New, null);
            detail.ShowDialog();
            viewModel.SearchExecute();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

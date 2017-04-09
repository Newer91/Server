using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Dictionaries.Client;
using ClassViewModel.Dictionaries;
using System.Windows;

namespace BandD.Serwis.Client.Dictionaries.Client
{
    /// <summary>
    /// Interaction logic for ClientDetail.xaml
    /// </summary>
    public partial class ClientDetail : Window
    {
        ClientDetailViewModel viewModel;
        public ClientDetail(ViewType view, ClientView client)
        {
            InitializeComponent();
            viewModel = new ClientDetailViewModel(view);
            if (view == ViewType.New)
                client = new ClientView();
            viewModel.Client = client;
            DataContext = viewModel;
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
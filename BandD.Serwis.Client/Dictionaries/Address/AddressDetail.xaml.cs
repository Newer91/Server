using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Dictionaries.Adress;
using System.Windows;

namespace BandD.Serwis.Client.Dictionaries.Address
{
    public partial class AddressDetail : Window
    {
        AddressDetailViewModel viewModel;

        public AddressDetail(ViewType viewType, AddressesView address)
        {
            InitializeComponent();
            viewModel = new AddressDetailViewModel(viewType);
            if (viewType == ViewType.New)
                address = new AddressesView();
            viewModel.Address = address;
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

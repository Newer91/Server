using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Dictionaries.CarrierStatus;
using System.Windows;

namespace BandD.Serwis.Client.Dictionaries.Carriers
{
    public partial class CarriersDetails : Window
    {
        CarrierStatusDetailViewModel viewModel;

        public CarriersDetails(ViewType viewType, SlCarriersStatView carrier)
        {
            InitializeComponent();
            viewModel = new CarrierStatusDetailViewModel(viewType);
            if (viewType == ViewType.New)
                carrier = new SlCarriersStatView();
            viewModel.Carrier = carrier;
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

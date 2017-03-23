using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Dictionaries.CarrierStatus;
using System.Windows;

namespace BandD.Serwis.Client.Dictionaries.Carriers
{
    /// <summary>
    /// Interaction logic for Carriers.xaml
    /// </summary>
    public partial class Carriers : Window
    {
        CarrierStatusViewModel carrierViewModel = new CarrierStatusViewModel();

        public Carriers()
        {
            InitializeComponent();
            this.DataContext = carrierViewModel;
        }

        private void buttonView_Click(object sender, RoutedEventArgs e)
        {
            CarriersDetails detail = new CarriersDetails(ViewType.View, carrierViewModel.SlCarrierStats);
            detail.ShowDialog();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            CarriersDetails detail = new CarriersDetails(ViewType.New, null);
            detail.ShowDialog();
            carrierViewModel.SearchExecute();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            CarriersDetails detail = new CarriersDetails(ViewType.Edit, carrierViewModel.SlCarrierStats);
            detail.ShowDialog();
        }
    }
}

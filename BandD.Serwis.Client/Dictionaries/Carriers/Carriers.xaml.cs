using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Dictionaries.CarrierStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
        //private void buttonView_Click(object sender, RoutedEventArgs e)
        //{
        //    CarrierStatsDetail detail = new CarrierStatsDetail(ViewType.View, orderViewModel.SlCarrierStats);
        //    detail.ShowDialog();
        //}

        //private void buttonAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    CarrierStatsDetail detail = new CarrierStatsDetail(ViewType.New, null);
        //    detail.ShowDialog();
        //    carrierViewModel.SearchExecute();
        //}
    }
}

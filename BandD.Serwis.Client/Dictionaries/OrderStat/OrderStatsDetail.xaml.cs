using BandD.Serwis.Domain;
using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Dictionaries.OrderStatus;
using System.Windows;

namespace BandD.Serwis.Client.Dictionaries.OrderStat
{
    public partial class OrderStatsDetail : Window
    {
        OrderStatusDetailViewModel viewModel;

        public OrderStatsDetail(ViewType viewType, SlOrderStat stats)
        {
            InitializeComponent();
            viewModel = new OrderStatusDetailViewModel(viewType);
            if (viewType == ViewType.New)
                stats = new SlOrderStat();
            viewModel.Stats = stats;
            this.DataContext = viewModel;
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.SaveChange())
                this.Close();
        }
    }
}

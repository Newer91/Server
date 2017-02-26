using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Dictionaries.OrderStatus;
using BandD.Serwis.ClassViewModel.Dictionaries;
using System.Windows;

namespace BandD.Serwis.Client.Dictionaries.OrderStat
{
    public partial class OrderStatsDetail : Window
    {
        OrderStatusDetailViewModel viewModel;

        public OrderStatsDetail(ViewType viewType, SlOrderStatView stats)
        {
            InitializeComponent();
            viewModel = new OrderStatusDetailViewModel(viewType);
            if (viewType == ViewType.New)
                stats = new SlOrderStatView();
            viewModel.Stats = stats;
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

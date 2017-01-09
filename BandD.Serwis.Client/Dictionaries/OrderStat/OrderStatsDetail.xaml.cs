using BandD.Serwis.Client.Extension;
using BandD.Serwis.Domain;
using BandD.Serwis.ViewModel.Dictionaries.OrderStatus;
using System.Windows;

namespace BandD.Serwis.Client.Dictionaries.OrderStat
{
    public partial class OrderStatsDetail : Window
    {
        OrderStatusDetailViewModel viewModel = new OrderStatusDetailViewModel();
        ViewType viewType;

        public OrderStatsDetail(ViewType viewType, SlOrderStat stats)
        {
            InitializeComponent();
            viewModel.Stats = stats;
            this.DataContext = viewModel;
            this.viewType = viewType;
        }
    }
}

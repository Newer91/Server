using BandD.Serwis.Client.Dictionaries.OrderStat;
using BandD.Serwis.Client.Extension;
using BandD.Serwis.ViewModel.Dictionaries;
using System.Windows;

namespace BandD.Serwis.Client.Dictionaries
{
    public partial class OrderStatus : Window
    {
        OrderStatusViewModel orderViemModel = new OrderStatusViewModel();
        public OrderStatus()
        {
            InitializeComponent();
            this.DataContext = orderViemModel;
        }

        private void buttonView_Click(object sender, RoutedEventArgs e)
        {
            OrderStatsDetail detail = new OrderStatsDetail(ViewType.View, orderViemModel.SlOrderStats);
            detail.ShowDialog();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            OrderStatsDetail detail = new OrderStatsDetail(ViewType.View, orderViemModel.SlOrderStats);
            detail.ShowDialog();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            OrderStatsDetail detail = new OrderStatsDetail(ViewType.View, orderViemModel.SlOrderStats);
            detail.ShowDialog();
        }
    }
}

using BandD.Serwis.Client.Dictionaries.OrderStat;
using BandD.Serwis.Tools.ServerTools.Extension;
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
            orderViemModel.SearchExecute();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            OrderStatsDetail detail = new OrderStatsDetail(ViewType.New, null);
            detail.ShowDialog();
            orderViemModel.SearchExecute();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            OrderStatsDetail detail = new OrderStatsDetail(ViewType.Edit, orderViemModel.SlOrderStats);
            detail.ShowDialog();
            orderViemModel.SearchExecute();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

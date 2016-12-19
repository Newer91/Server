using BandD.Serwis.ViewModel.Dictionaries;
using System.Windows;

namespace BandD.Serwis.Client.Dictionaries
{
    /// <summary>
    /// Interaction logic for OrderStatus.xaml
    /// </summary>
    public partial class OrderStatus : Window
    {
        OrderStatusViewModel orderViemModel = new OrderStatusViewModel();
        public OrderStatus()
        {
            InitializeComponent();
            this.DataContext = orderViemModel;
        }
    }
}

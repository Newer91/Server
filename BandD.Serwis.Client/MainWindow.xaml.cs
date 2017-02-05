using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BandD.Serwis.ViewModel;
using BandD.Serwis.Client.Dictionaries;
using BandD.Serwis.Client.Dictionaries.OrderStat;
using BandD.Serwis.Client.Dictionaries.User;
using BandD.Serwis.Client.Dictionaries.Carriers;

namespace BandD.Serwis.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mainWindows = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
        private void buttonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            mainWindows.mail = txtMail.Text;
        }

        private void OrderStatus_Click(object sender, RoutedEventArgs e)
        {
            OrderStatus window = new OrderStatus();
            window.ShowDialog();
        }
        private void CarrierStatus_Click(object sender, RoutedEventArgs e)
        {
            Carriers window = new Carriers();
            window.ShowDialog();
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            Users window = new Users();
            window.ShowDialog();
        }
    }
}
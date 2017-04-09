using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BandD.Serwis.Client.Dictionaries;
using BandD.Serwis.Client.Dictionaries.User;
using BandD.Serwis.Client.Dictionaries.Carriers;
using BandD.Serwis.Client.Dictionaries.Role;
using BandD.Serwis.Client.Dictionaries.Address;

namespace BandD.Serwis.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void UserRole_Click(object sender, RoutedEventArgs e)
        {
            Role window = new Role();
            window.ShowDialog();
        }

        private void Address_Click(object sender, RoutedEventArgs e)
        {
            Address window = new Address();
            window.ShowDialog();
        }
    }
}
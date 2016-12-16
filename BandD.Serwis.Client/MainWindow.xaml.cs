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
using BandD.Serwis.ViewModel;

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
        //cos
    }
}
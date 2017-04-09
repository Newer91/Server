using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Dictionaries.Adress;
using System.Windows;

namespace BandD.Serwis.Client.Dictionaries.Address
{

    public partial class Address : Window
    {
        AddressViewModel addresViewModel = new AddressViewModel();

        public Address()
        {
            InitializeComponent();
            this.DataContext = addresViewModel;
        }

        private void buttonView_Click(object sender, RoutedEventArgs e)
        {
            AddressDetail detail = new AddressDetail(ViewType.View, addresViewModel.Address);
            detail.ShowDialog();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddressDetail detail = new AddressDetail(ViewType.New, null);
            detail.ShowDialog();
            addresViewModel.SearchExecute();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            AddressDetail detail = new AddressDetail(ViewType.Edit, addresViewModel.Address);
            detail.ShowDialog();
            addresViewModel.SearchExecute();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

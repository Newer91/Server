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
            Save();
        }

        private void Save()
        {
            bool result = false;
            var question = MessageBox.Show("Czy chcesz zapisać dane?", "Informacja", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
                if (viewModel.ViewType == ViewType.Edit)
                    result = viewModel.SaveChange();
                else if (viewModel.ViewType == ViewType.New)
                    result = viewModel.AddNewItem();
            if (result)
            {
                MessageBox.Show("Dane zapisano", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
                MessageBox.Show("Pole opis i nazwa nie mogą być puste", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

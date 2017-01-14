using BandD.Serwis.ViewModel.Class;
using System.Windows.Input;
using BandD.Serwis.Model.Dictionaries;
using System.Windows;
using ClassViewModel.Dictionaries;
using System.Collections.ObjectModel;
using System.Linq;

namespace BandD.Serwis.ViewModel.Dictionaries
{
    public class OrderStatusViewModel : BaseViewClass
    {
        private OrderStatusModel model;

        private string name;
        private ActiveItem activity;
        private ObservableCollection<SlOrderStatView> orderStatusList;
        private ObservableCollection<ActiveItem> activeComboBox;
        private SlOrderStatView slOrderStat;

        public OrderStatusViewModel()
        {
            model = new OrderStatusModel();
            ActiveComboBox = new ActiveItem().getActiveList();
            Active = ActiveComboBox[0];
        }

        public ObservableCollection<SlOrderStatView> OrderStatusList
        {
            get { return orderStatusList; }
            set { orderStatusList = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public ActiveItem Active
        {
            get { return activity; }
            set { activity = value; OnPropertyChanged(); }
        }

        public SlOrderStatView SlOrderStats
        {
            get { return slOrderStat; }
            set { slOrderStat = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ActiveItem> ActiveComboBox
        {
            get { return activeComboBox; }
            set { activeComboBox = value;OnPropertyChanged(); }
        }

        public ICommand Search { get { return new RelayCommand(SearchExecute, null); } }
        public ICommand Remove { get { return new RelayCommand(RemoveExecute, null); } }

        private void RemoveExecute()
        {
            var question = MessageBox.Show("Czy na pewno chcesz usunąc wskazany element?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
                model.RemoveElement(slOrderStat.OrderStatusId);
            SearchExecute();
        }

        public void SearchExecute()
        {
            OrderStatusList = model.getDataFromSlOrderStat(name, activity.Value);
        }
    }
}

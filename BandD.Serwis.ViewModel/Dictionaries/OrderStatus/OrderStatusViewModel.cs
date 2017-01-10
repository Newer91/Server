using BandD.Serwis.ViewModel.Class;
using System.Collections.Generic;
using System.Windows.Input;
using System;
using BandD.Serwis.Model.Dictionaries;
using BandD.Serwis.Domain;
using System.Windows;

namespace BandD.Serwis.ViewModel.Dictionaries
{
    public class OrderStatusViewModel : BaseClass
    {
        private OrderStatusModel model;

        private string name;
        private bool? activity;
        private List<SlOrderStat> orderStatusList;
        private SlOrderStat slOrderStat;

        public OrderStatusViewModel()
        {
            model = new OrderStatusModel();
        }

        public List<SlOrderStat> OrderStatusList
        {
            get { return orderStatusList; }
            set { orderStatusList = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public bool? Active
        {
            get { return activity; }
            set { activity = value; OnPropertyChanged(); }
        }

        public SlOrderStat SlOrderStats
        {
            get { return slOrderStat; }
            set { slOrderStat = value; OnPropertyChanged(); }
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
            OrderStatusList = model.getDataFromSlOrderStat(name, activity);
        }
    }
}

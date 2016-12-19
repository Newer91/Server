using BandD.Serwis.Class;
using BandD.Serwis.ViewModel.Class;
using System.Collections.Generic;
using System.Windows.Input;
using System;
using BandD.Serwis.Model.Dictionaries;

namespace BandD.Serwis.ViewModel.Dictionaries
{
    public class OrderStatusViewModel : BaseClass
    {
        public List<SlOrderStat> OrderStatusList { get; set; }
        private DictionariesModel model = new DictionariesModel();

        private string name;
        private bool activity;

        public OrderStatusViewModel()
        {
            model = new DictionariesModel();
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public ICommand Search { get { return new RelayCommand(SearchExecute, null); } }

        private void SearchExecute()
        {
            OrderStatusList = model.getDataFromSlOrderStat(name, activity);
        }
    }
}

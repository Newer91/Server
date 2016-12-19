using BandD.Serwis.Class;
using BandD.Serwis.ViewModel.Class;
using System.Collections.Generic;
using System.Windows.Input;
using System;

namespace BandD.Serwis.ViewModel.Dictionaries
{
    public class OrderStatusViewModel : BaseClass
    {
        public List<SlOrderStat> OrderStatusList { get; set; }

        private string name;
        private bool activity;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public bool Activity
        {
            get { return activity; }
            set { activity = value;OnPropertyChanged(); }
        }

        public ICommand Search { get { return new RelayCommand(SearchExecute, null); } }

        private void SearchExecute()
        {
            throw new NotImplementedException();
        }
    }
}

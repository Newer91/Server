using BandD.Serwis.Model.Dictionaries;
using BandD.Serwis.ViewModel.Class;
using BandD.Serwis.ClassViewModel.Dictionaries;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace BandD.Serwis.ViewModel.Dictionaries.CarrierStatus
{
    public class CarrierStatusViewModel : BaseViewClass
    {
        private CarrierStatusModel model;

        private string carrierName;
        private ActiveItem activity;
        private ObservableCollection<SlCarriersStatView> carrierStatusList;
        private ObservableCollection<ActiveItem> activeComboBox;
        private SlCarriersStatView slCarrierStat;

        public CarrierStatusViewModel()
        {
            model = new CarrierStatusModel();
            activeComboBox = new ActiveItem().getActiveList();
            Active = activeComboBox[0];
        }
       
            public ObservableCollection<SlCarriersStatView> CarrierStatusList
        {
            get { return carrierStatusList; }
            set { carrierStatusList = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get { return carrierName; }
            set { carrierName = value; OnPropertyChanged(); }
        }

        public ActiveItem Active
        {
            get { return activity; }
            set { activity = value; OnPropertyChanged(); }
        }

        public SlCarriersStatView SlCarrierStats
        {
            get { return slCarrierStat; }
            set { slCarrierStat = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ActiveItem> ActiveComboBox
        {
            get { return activeComboBox; }
            set { activeComboBox = value; OnPropertyChanged(); }
        }

        public ICommand Search { get { return new RelayCommand(SearchExecute, null); } }
        public ICommand Remove { get { return new RelayCommand(RemoveExecute, null); } }

        private void RemoveExecute()
        {
            var question = MessageBox.Show("Czy na pewno chcesz usunąc wskazany element?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
                model.RemoveElement(slCarrierStat.CarrierStatusId);
            SearchExecute();
        }

        public void SearchExecute()
        {
            CarrierStatusList = model.getDataFromSlCarrierStat(carrierName, activity.Value);
        }
    }

}

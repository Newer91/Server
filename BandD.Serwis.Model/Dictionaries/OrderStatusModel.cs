using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Model.DictionarySerivce;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BandD.Serwis.Model.Dictionaries
{
    public class OrderStatusModel
    {

        private DictionariesServiceClient service = new DictionariesServiceClient();

        public ObservableCollection<SlOrderStatView> getDataFromSlOrderStat(string name, bool? activity)
        {
            string names = name == null ? string.Empty : name;
            var items = service.GetDataFromSlOrderStat(names, activity).ToList();
            var result = new ObservableCollection<SlOrderStatView>();
            foreach (var item in items)
            {
                result.Add(item);
            }

            return result;
        }

        public bool SaveChange(SlOrderStatView stats)
        {
            return service.UpdateElementSlOrderStat(stats);
        }

        public bool AddNewItem(SlOrderStatView stats)
        {
            return service.AddElementToSlOrderStat(stats);
        }

        public bool RemoveElement(Guid id)
        {
            return service.RemoveElementFromSlOrderStat(id);
        }
    }
}
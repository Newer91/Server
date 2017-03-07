using BandD.Serwis.Model.DictionariesService;
using BandD.Serwis.Tools.Extension;
using System.Linq;
using System;
using System.Collections.ObjectModel;
using BandD.Serwis.ClassViewModel.Dictionaries;

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
            if (ClientTools.ValidateProperty(stats.Name) && ClientTools.ValidateProperty(stats.Description))
            {
                service.UpdateElementSlOrderStat(stats);
                return true;
            }
            else
                return false;          
        }

        public bool AddNewItem(SlOrderStatView stats)
        {
            if (ClientTools.ValidateProperty(stats.Name) && ClientTools.ValidateProperty(stats.Description))
            {
                service.AddElementToSlOrderStat(stats);
                return true;
            }
            else
                return false;
        }

        public void RemoveElement(Guid id)
        {
            service.RemoveElementFromSlOrderStat(id);
        }
    }
}
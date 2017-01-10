using BandD.Serwis.Domain;
using BandD.Serwis.Model.DictionariesService;
using BandD.Serwis.Tools.Extension;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BandD.Serwis.Model.Dictionaries
{
    public class OrderStatusModel
    {
        private DictionariesServiceClient service = new DictionariesServiceClient();

        public List<SlOrderStat> getDataFromSlOrderStat(string name, bool? activity)
        {
            string names = name == null ? string.Empty : name;
            return service.getDataFromSlOrderStat(names, activity).ToList();
        }

        public bool SaveChange(SlOrderStat stats)
        {
            if (ClientTools.ValidateProperty(stats.Name) && ClientTools.ValidateProperty(stats.Description))
            {
                service.updateElementSlOrderStat(stats);
                return true;
            }
            else
                return false;          
        }

        public bool AddNewItem(SlOrderStat stats)
        {
            if (ClientTools.ValidateProperty(stats.Name) && ClientTools.ValidateProperty(stats.Description))
            {
                service.addElementToSlOrderStat(stats);
                return true;
            }
            else
                return false;
        }

        public void RemoveElement(Guid id)
        {
            service.removeElementFromSlOrderStat(id);
        }
    }
}

//if (name != null && name != string.Empty)
//    list = list.Where(n => n.Name == name).ToList();

//if (activity != null)
//    list = list.Where(a => Convert.ToByte(a.Active) == Convert.ToByte(activity)).ToList();
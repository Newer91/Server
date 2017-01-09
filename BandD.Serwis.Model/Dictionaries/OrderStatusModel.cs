using BandD.Serwis.Domain;
using BandD.Serwis.Model.DictionariesService;
using System.Collections.Generic;
using System.Linq;

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
    }
}

//if (name != null && name != string.Empty)
//    list = list.Where(n => n.Name == name).ToList();

//if (activity != null)
//    list = list.Where(a => Convert.ToByte(a.Active) == Convert.ToByte(activity)).ToList();
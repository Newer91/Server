using BandD.Serwis.Domain;
using BandD.Serwis.Model.DictionariesService;
using System.Collections.Generic;
using System.Linq;

namespace BandD.Serwis.Model.Dictionaries
{
    public class OrderStatusModel
    {
        private DictionariesServiceClient service = new DictionariesServiceClient();

        public List<SlOrderStat> getDataFromSlOrderStat(string name, bool activity)
        {
            return service.getDataFromSlOrderStat(name, activity).ToList();
        }
    }
}

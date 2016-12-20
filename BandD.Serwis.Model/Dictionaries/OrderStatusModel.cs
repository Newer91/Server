using BandD.Serwis.Domain;
using BandD.Serwis.Model.DictionariesService;

using System.Collections.Generic;
using System.Linq;

namespace BandD.Serwis.Model.Dictionaries
{
    public class DictionariesModel
    {
        private DictionariesServiceClient service = new DictionariesServiceClient();

        public List<SlOrderStat> getDataFromSlOrderStat(string name, bool activity)
        {
            return service.getDataFromSlOrderStat(name, activity).ToList();
        }

        public List<UserStatus> getDataFromUserStatus(string name, bool status)
        {
            return service.getDataFromUserStatus(name, status).ToList();
        }
    }
}

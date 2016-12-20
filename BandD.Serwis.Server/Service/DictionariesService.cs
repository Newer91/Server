using BandD.Serwis.Server.EntityContexClass;
using BandD.Serwis.Server.Interface;
using System;
using System.Collections.Generic;
using BandD.Serwis.Tools.ServerTools;
using BandD.Serwis.Domain;

namespace BandD.Serwis.Server.Service
{
    public class DictionariesService : IDictionariesService
    {
        private string conectionString = Extension.GetConnectionString(Environment.MachineName);

        public List<SlOrderStat> getDataFromSlOrderStat(string name, bool activity)
        {
            using (var ctx = new ServisContex(conectionString))
            {
                List<SlOrderStat> result = new List<SlOrderStat>();
                var sl1 = new SlOrderStat() { Active = true, Name = "jakis", OrderStatusId = Guid.NewGuid(), Description = "cos" };

                result.Add(sl1);
                return result;
            }
        }
    }
}

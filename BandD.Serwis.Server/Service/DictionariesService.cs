using BandD.Serwis.Server.EntityContexClass;
using BandD.Serwis.Server.Interface;
using System.ServiceModel;
using BandD.Serwis.Class;
using System;
using System.Collections.Generic;

namespace BandD.Serwis.Server.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class DictionariesService : IDictionariesService
    {
        private ServisContex ctx;

        public DictionariesService(ServisContex ctx)
        {
            this.ctx = ctx;
        }

        public List<SlOrderStat> getDataFromSlOrderStat(string name, bool activity)
        {
            throw new NotImplementedException();
        }
    }
}

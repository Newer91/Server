using BandD.Serwis.Server.EntityContexClass;
using BandD.Serwis.Server.Interface;
using System;
using System.Collections.Generic;
using BandD.Serwis.Tools.ServerTools;
using BandD.Serwis.Domain;
using System.Linq;

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

        public bool Autorauthorization(string password, string userName)
        {
            using (var ctx = new ServisContex(conectionString))
            {
                bool result = false;
                var login = ctx.Users
                    .Where(l => l.UserName == userName)
                    .FirstOrDefault();

                if (login.Password == password)
                    return true;
                return result;
            }
        }
    }
}

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

        #region User

        public bool Autorauthorization(string password, string userName)
        {
            bool result = false;
            using (var ctx = new ServisContex(conectionString))
            {
                var login = ctx.Users
                    .Where(l => l.UserName == userName)
                    .FirstOrDefault();

                if (login.Password == password)
                    return true;
            }
            return result;
        }

        public List<User> getDataFromUser(string name, bool status)
        {
            List<User> result = new List<User>();
            var user = new User() { UserId = Guid.NewGuid(), Active = true, UserName = "blisowski", Role = "Admin", Password = SecureTools.CalculateMD5Hash("dedra") };
            var user2 = new User() { UserId = Guid.NewGuid(), Active = true, UserName = "asieradzan", Role = "Admin", Password = SecureTools.CalculateMD5Hash("12345") };
            var user3 = new User() { UserId = Guid.NewGuid(), Active = true, UserName = "Admin", Role = "Admin", Password = SecureTools.CalculateMD5Hash("admin") };

            result.Add(user);
            result.Add(user2);
            result.Add(user3);
            return result;
        }

        #endregion

        #region OrderStatus

        public List<SlOrderStat> getDataFromSlOrderStat(string name, bool activity)
        {
            List<SlOrderStat> result = new List<SlOrderStat>();
            using (var ctx = new ServisContex(conectionString))
            {
                var list = ctx.SlOrdersStats.ToList();

                if (name != null && name != string.Empty)
                    list = list.Where(n => n.Name == name).ToList();

                if (activity)
                    list = list.Where(a => Convert.ToByte(a.Active) == Convert.ToByte(activity)).ToList();

                result = list;                
            }

            return result;
        }

        #endregion
    }
}
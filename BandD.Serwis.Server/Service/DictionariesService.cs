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
            using (var ctx = new ServisContex(conectionString))
            {
                List<SlOrderStat> result = new List<SlOrderStat>();
                var sl1 = new SlOrderStat() { Active = true, Name = "jakis", OrderStatusId = Guid.NewGuid(), Description = "cos" };

                result.Add(sl1);
                return result;
            }
        }

        #endregion
    }
}
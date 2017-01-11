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
        private string conectionString = ServerExtension.GetConnectionString(Environment.MachineName);

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

        public List<User> getDataFromUser()
        {
            List<User> result = new List<User>();
            var user = new User() { UserId = Guid.NewGuid(), Active = true, UserName = "blisowski", Role = "Admin", Password = SecureTools.CalculateMD5Hash("dedra") };
            var user2 = new User() { UserId = Guid.NewGuid(), Active = true, UserName = "asieradzan", Role = "Admin", Password = SecureTools.CalculateMD5Hash("12345") };
            var user3 = new User() { UserId = Guid.NewGuid(), Active = true, UserName = "Admin", Role = "Admin", Password = SecureTools.CalculateMD5Hash("admin") };

            using (var ctx = new ServisContex(conectionString))
            {
                var userList = ctx.Users;
                foreach (var item in userList)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        #endregion

        #region OrderStatus

        public List<SlOrderStat> getDataFromSlOrderStat(string name, bool? activity)
        {
            using (var ctx = new ServisContex(conectionString))
            {
                var list = ctx.SlOrdersStats;

                if (name != string.Empty)
                    list.Where(l => l.Name != name);

                if (activity != null)
                    list.Where(l => l.Active != activity);

                return list.ToList();
            }
        }

        public void removeElementFromSlOrderStat(Guid id)
        {
            using (var ctx = new ServisContex(conectionString))
            {
                var item = ctx.SlOrdersStats.Find(id);
                ctx.SlOrdersStats.Remove(item);
                ctx.SaveChanges();
            }
        }

        public void addElementToSlOrderStat(SlOrderStat item)
        {
            using (var ctx = new ServisContex(conectionString))
            {
                ctx.SlOrdersStats.Add(item);
                ctx.SaveChanges();
            }
        }

        public void updateElementSlOrderStat(SlOrderStat item)
        {
            using (var ctx = new ServisContex(conectionString))
            {
                var element = ctx.SlOrdersStats.Find(item.OrderStatusId);
                element.Name = item.Name;
                element.Description = item.Description;
                element.Active = item.Active;
                ctx.SaveChanges();
            }
        }

        #endregion
    }
}
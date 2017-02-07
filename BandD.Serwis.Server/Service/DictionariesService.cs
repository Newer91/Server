using BandD.Serwis.Server.EntityContexClass;
using BandD.Serwis.Server.Interface;
using System;
using System.Collections.Generic;
using BandD.Serwis.Tools.ServerTools;
using BandD.Serwis.Domain;
using System.Linq;
using System.Data.Entity;
using BandD.Serwis.Domain.Dictionaries;

namespace BandD.Serwis.Server.Service
{
    public class DictionariesService : IDictionariesService
    {      

        #region User

        public bool Autorauthorization(string password, string userName)
        {
            bool result = false;
            using (var ctx = new ServisContex())
            {
                var login = ctx.Users
                    .Where(l => l.UserName == userName)
                    .FirstOrDefault();

                if (login.Password == password)
                    return true;
            }
            return result;
        }

        public List<User> getDataFromUser(string name, bool? status, string role)
        {
            using (var ctx = new ServisContex())
            {
                IQueryable<User> userList = ctx.Users.Include(r => r.SlRole).AsNoTracking();

                if (name != string.Empty)
                    userList = userList.Where(l => l.UserName == name);

                if (status != null)
                    userList = userList.Where(l => l.Active == status);

                //if (role != string.Empty)
                //    userList = userList.Where(l => l.Role == role);

                var tmp = userList.ToList();
                return tmp;
            }
        }

        public void removeElementFromUsers(Guid id)
        {
            throw new NotImplementedException();
        }

        public void addElementToUsers(User element)
        {
            throw new NotImplementedException();
        }

        public void updateElementUsers(User element)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region OrderStatus

        public List<SlOrderStat> getDataFromSlOrderStat(string name, bool? activity)
        {
            using (var ctx = new ServisContex())
            {
                IQueryable<SlOrderStat> list = ctx.SlOrdersStats;

                if (name != string.Empty)
                    list = list.Where(l => l.Name == name);

                if (activity != null)
                    list = list.Where(l => l.Active == activity);

                return list.ToList();
            }
        }

        public void removeElementFromSlOrderStat(Guid id)
        {
            using (var ctx = new ServisContex())
            {
                var item = ctx.SlOrdersStats.Find(id);
                ctx.SlOrdersStats.Remove(item);
                ctx.SaveChanges();
            }
        }

        public void addElementToSlOrderStat(SlOrderStat item)
        {
            using (var ctx = new ServisContex())
            {
                ctx.SlOrdersStats.Add(item);
                ctx.SaveChanges();
            }
        }

        public void updateElementSlOrderStat(SlOrderStat item)
        {
            using (var ctx = new ServisContex())
            {
                var element = ctx.SlOrdersStats.Find(item.OrderStatusId);
                element.Name = item.Name;
                element.Description = item.Description;
                element.Active = item.Active;
                ctx.SaveChanges();
            }
        }

        #endregion

        #region CarrierStatus
        public List<SlCarrierStat> getDataFromSlCarrierStat(string carrierName, bool? carrierStatus)
        {
            using (var ctx = new ServisContex())
            {
                IQueryable<SlCarrierStat> list = ctx.SlCarrierStats;

                if (carrierName != string.Empty)
                    list = list.Where(l => l.CarrierName == carrierName);

                if (carrierStatus != null)
                    list = list.Where(l => l.CarrierStatus == carrierStatus);

                return list.ToList();
            }
        }

        public void removeElementFromSlCarrierStat(Guid id)
        {
            using (var ctx = new ServisContex())
            {
                var item = ctx.SlCarrierStats.Find(id);
                ctx.SlCarrierStats.Remove(item);
                ctx.SaveChanges();
            }
        }

        public void addElementToSlCarrierStat(SlCarrierStat item)
        {
            using (var ctx = new ServisContex())
            {
                ctx.SlCarrierStats.Add(item);
                ctx.SaveChanges();
            }
        }

        public void updateElementSlCarrierStat(SlCarrierStat item)
        {
            using (var ctx = new ServisContex())
            {
                var element = ctx.SlCarrierStats.Find(item.CarrierStatusId);
                element.CarrierName = item.CarrierName;
                element.CarrierLink = item.CarrierLink;
                element.CarrierStatus = item.CarrierStatus;
                ctx.SaveChanges();
            }
        }

        #endregion

    }
}
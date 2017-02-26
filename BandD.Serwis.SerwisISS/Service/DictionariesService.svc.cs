using BandD.Serwis.Domain;
using BandD.Serwis.SerwisISS.EntityContexClass;
using BandD.Serwis.ClassViewModel.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using BandD.Serwis.Domain.Dictionaries;
using BandD.Serwis.SerwisISS.Interface;
using SerwisISS.Helpers;

namespace BandD.Serwis.SerwisISS.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DictionariesService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DictionariesService.svc or DictionariesService.svc.cs at the Solution Explorer and start debugging.
    public class DictionariesService : IDictionariesService
    {
        #region User

        public bool Autorauthorization(string password, string userName)
        {
            //new InitClass();
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

        public List<UserView> getDataFromUser(string name, bool? status, string role)
        {
            using (var ctx = new ServisContex())
            {
                List<UserView> result = new List<UserView>();
                IQueryable<User> userList = ctx.Users.Include(r => r.SlRole).AsNoTracking();

                if (name != string.Empty)
                    userList = userList.Where(l => l.UserName == name);

                if (status != null)
                    userList = userList.Where(l => l.Active == status);

                //if (role != string.Empty)
                //    userList = userList.Where(l => l.Role == role);

                var tmp = userList.ToList();
                foreach (var item in tmp)
                {
                    result.Add(DictionaryCoverterToView.UserToView(item));
                }

                return result;
            }
        }

        public void removeElementFromUsers(Guid id)
        {
            throw new NotImplementedException();
        }

        public void addElementToUsers(UserView element)
        {
            throw new NotImplementedException();
        }

        public void updateElementUsers(UserView element)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region OrderStatus

        public List<SlOrderStatView> getDataFromSlOrderStat(string name, bool? activity)
        {
            using (var ctx = new ServisContex())
            {
                List<SlOrderStatView> result = new List<SlOrderStatView>();
                IQueryable<SlOrderStat> list = ctx.SlOrdersStats;

                if (name != string.Empty)
                    list = list.Where(l => l.Name == name);

                if (activity != null)
                    list = list.Where(l => l.Active == activity);

                var tmp = list.ToList();
                foreach (var item in tmp)
                {
                    result.Add(DictionaryCoverterToView.SlOrderStatToView(item));
                }

                return result;
            }
        }

        public void removeElementFromSlOrderStat(Guid id)
        {
            using (var ctx = new ServisContex())
            {
                var item = ctx.SlOrdersStats.Find(id);
                item.Active = false;
                ctx.SaveChanges();
            }
        }

        public void addElementToSlOrderStat(SlOrderStatView item)
        {
            using (var ctx = new ServisContex())
            {
                ctx.SlOrdersStats.Add(DictionaryCoverterToDomain.SlOrderStatToDomain(item));
                ctx.SaveChanges();
            }
        }

        public void updateElementSlOrderStat(SlOrderStatView item)
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
        public List<SlCarriersStatView> getDataFromSlCarrierStat(string carrierName, bool? carrierStatus)
        {
            using (var ctx = new ServisContex())
            {
                List<SlCarriersStatView> result = new List<SlCarriersStatView>();
                IQueryable<SlCarrierStat> list = ctx.SlCarrierStats;

                if (carrierName != string.Empty)
                    list = list.Where(l => l.Name == carrierName);

                if (carrierStatus != null)
                    list = list.Where(l => l.Active == carrierStatus);

                var tmp = list.ToList();

                foreach (var item in tmp)
                {
                    result.Add(DictionaryCoverterToView.SlCarriersToView(item));
                }

                return result;
            }
        }

        public void removeElementFromSlCarrierStat(Guid id)
        {
            using (var ctx = new ServisContex())
            {
                var item = ctx.SlCarrierStats.Find(id);
                item.Active = false;
                ctx.SaveChanges();
            }
        }

        public void addElementToSlCarrierStat(SlCarriersStatView item)
        {
            //using (var ctx = new ServisContex())
            //{
            //    ctx.SlCarrierStats.Add(DictionaryCoverterToDomain.SlCarrierStatToDomain(item));
            //    ctx.SaveChanges();
            //}
        }

        public void updateElementSlCarrierStat(SlCarriersStatView item)
        {
            using (var ctx = new ServisContex())
            {
                var element = ctx.SlCarrierStats.Find(item.CarrierStatusId);
                element.Name = item.CarrierName;
                element.Link = item.CarrierLink;
                element.Active = item.CarrierStatus;
                ctx.SaveChanges();
            }
        }

        #endregion
    }
}

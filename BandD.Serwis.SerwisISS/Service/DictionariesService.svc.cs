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
using System.Collections.ObjectModel;
using BandD.Serwis.Tools.Logger;

namespace BandD.Serwis.SerwisISS.Service
{
    public class DictionariesService : IDictionariesService
    {
        #region User

        public bool Autorauthorization(string password, string userName)
        {
            bool result = false;
            using (var ctx = new ServisContex())
            {
                try
                {
                    var login = ctx.Users
                    .Where(l => l.UserName == userName)
                    .FirstOrDefault();

                    if (login.Password == password)
                        return true;
                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                }
            }
            return result;
        }

        public List<UserView> GetDataFromUser(string name, bool? status, Guid? role)
        {
            using (var ctx = new ServisContex())
            {
                List<UserView> result = new List<UserView>();
                try
                {
                    IQueryable<User> userList = ctx.Users.Include(r => r.SlRole).AsNoTracking();

                    if (name != string.Empty)
                        userList = userList.Where(l => l.UserName == name);

                    if (status != null)
                        userList = userList.Where(l => l.Active == status);

                    if (role != null)
                        userList = userList.Where(l => l.SlRole.RoleId == role);

                    var tmp = userList.ToList();
                    foreach (var item in tmp)
                    {
                        result.Add(DictionaryCoverterToView.UserToView(item));
                    }
                }

                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                }

                return result;
            }
        }

        public bool RemoveElementFromUsers(Guid id)
        {
            bool result = true;
            using (var ctx = new ServisContex())
            {
                try
                {
                    var item = ctx.Users.Find(id);
                    item.Active = false;
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                    result = false;
                }
            }
            return result;
        }

        public bool AddElementToUsers(UserView item)
        {
            bool result = true;
            using (var ctx = new ServisContex())
            {
                try
                {
                    var role = ctx.SlRoles.First(x => x.RoleId == item.Rola.RoleId);
                    ctx.Users.Add(DictionaryCoverterToDomain.UserToDomain(item, role));
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                    result = false;
                }
            }
            return result;
        }

        public bool UpdateElementUsers(UserView item)
        {
            bool result = true;
            using (var ctx = new ServisContex())
            {
                try
                {
                    var element = ctx.Users.Find(item.UserId);
                    element.UserName = item.UserName;
                    element.Active = item.Active;
                    element.Password = item.Password;
                    element.SlRole.Name = item.Rola.Name;
                    element.SlRole.RoleId = item.Rola.RoleId.Value;
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                    result = false;
                }
            }
            return result;
        }

        #endregion

        #region OrderStatus

        public List<SlOrderStatView> GetDataFromSlOrderStat(string name, bool? activity)
        {
            using (var ctx = new ServisContex())
            {
                List<SlOrderStatView> result = new List<SlOrderStatView>();
                try
                {
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
                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                }

                return result;
            }
        }

        public bool RemoveElementFromSlOrderStat(Guid id)
        {
            bool result = true;
            using (var ctx = new ServisContex())
            {
                try
                {
                    var item = ctx.SlOrdersStats.Find(id);
                    item.Active = false;
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                    result = false;
                }
            }
            return result;
        }

        public bool AddElementToSlOrderStat(SlOrderStatView item)
        {
            bool result = true;
            using (var ctx = new ServisContex())
            {
                try
                {
                    ctx.SlOrdersStats.Add(DictionaryCoverterToDomain.SlOrderStatToDomain(item));
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                    result = false;
                }
            }
            return result;
        }

        public bool UpdateElementSlOrderStat(SlOrderStatView item)
        {
            bool result = true;
            using (var ctx = new ServisContex())
            {
                try
                {
                    var element = ctx.SlOrdersStats.Find(item.OrderStatusId);
                    element.Name = item.Name;
                    element.Description = item.Description;
                    element.Active = item.Active;
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                    result = false;
                }
            }
            return result;
        }

        #endregion

        #region CarrierStatus

        public List<SlCarriersStatView> GetDataFromSlCarrierStat(string carrierName, bool? carrierStatus)
        {
            using (var ctx = new ServisContex())
            {
                List<SlCarriersStatView> result = new List<SlCarriersStatView>();
                try
                {
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
                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                }

                return result;
            }
        }

        public bool RemoveElementFromSlCarrierStat(Guid id)
        {
            bool result = true;
            using (var ctx = new ServisContex())
            {
                try
                {
                    var item = ctx.SlCarrierStats.Find(id);
                    item.Active = false;
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                    result = false;
                }
            }
            return result;
        }

        public bool AddElementToSlCarrierStat(SlCarriersStatView item)
        {
            bool result = true;
            using (var ctx = new ServisContex())
            {
                try
                {
                    ctx.SlCarrierStats.Add(DictionaryCoverterToDomain.SlCarrierStatToDomain(item));
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                    result = false;
                }
            }
            return result;
        }

        public bool UpdateElementSlCarrierStat(SlCarriersStatView item)
        {
            bool result = true;
            using (var ctx = new ServisContex())
            {
                try
                {
                    var element = ctx.SlCarrierStats.Find(item.CarrierStatusId);
                    element.Name = item.Name;
                    element.Link = item.Link;
                    element.Active = item.Active;
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                    result = false;
                }
            }
            return result;
        }

        #endregion

        #region Roles

        public ObservableCollection<SlRoleView> GetAllRoles(bool isAll)
        {
            ObservableCollection<SlRoleView> result = new ObservableCollection<SlRoleView>();

            using (var ctx = new ServisContex())
            {
                try
                {
                    IQueryable<SlRole> role = ctx.SlRoles;
                    if (!isAll)
                        role = ctx.SlRoles.Where(a => a.Active == true);

                    foreach (var item in role.ToList())
                    {
                        result.Add(DictionaryCoverterToView.SlRolaToView(item));
                    }
                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                }
            }

            return result;
        }

        public ObservableCollection<SlRoleView> GetDataFromRole(string name, bool? status)
        {
            ObservableCollection<SlRoleView> result = new ObservableCollection<SlRoleView>();
            using (var ctx = new ServisContex())
            {
                try
                {
                    IQueryable<SlRole> role = ctx.SlRoles;
                    if (name != string.Empty)
                        role = role.Where(l => l.Name == name);

                    if (status != null)
                        role = role.Where(l => l.Active == status);

                    foreach (var item in role.ToList())
                    {
                        result.Add(DictionaryCoverterToView.SlRolaToView(item));
                    }

                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                }
            }

            return result;
        }

        public bool RemoveElementFromRole(Guid id)
        {
            bool result = true;
            using (var ctx = new ServisContex())
            {
                try
                {
                    var item = ctx.SlRoles.Find(id);
                    item.Active = false;
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                    result = false;
                }
            }
            return result;
        }

        public bool UpdateElementSlRole(SlRoleView role)
        {
            bool result = true;
            using (var ctx = new ServisContex())
            {
                try
                {
                    var element = ctx.SlRoles.Find(role.RoleId);
                    element.Name = role.Name;
                    element.Active = role.Active;
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                    result = false;
                }
            }
            return result;
        }

        public bool AddElementToSlRole(SlRoleView role)
        {
            bool result = true;
            using (var ctx = new ServisContex())
            {
                try
                {
                    ctx.SlRoles.Add(DictionaryCoverterToDomain.SlRoleToDomain(role));
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    LoggerExeption.LogExeption(e, LoggerExeption.CalleMethodsName());
                    result = false;
                }
            }
            return result;
        }

        #endregion
    }
}

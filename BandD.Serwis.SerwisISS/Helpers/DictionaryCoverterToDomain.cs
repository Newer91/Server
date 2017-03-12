using System;
using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Domain;
using BandD.Serwis.Domain.Dictionaries;

namespace SerwisISS.Helpers
{
    public static class DictionaryCoverterToDomain
    {
        public static SlOrderStat SlOrderStatToDomain(SlOrderStatView stats)
        {
            var result = new SlOrderStat();

            if (stats != null)
            {
                result.OrderStatusId = stats.OrderStatusId;
                result.Name = stats.Name;
                result.Active = stats.Active;
                result.Description = stats.Description;
            }

            return result;
        }

        public static SlCarrierStat SlCarrierStatToDomain(SlCarriersStatView stats)
        {
            var result = new SlCarrierStat();

            if (stats != null)
            {
                result.CarrierStatusId = stats.CarrierStatusId;
                result.Name = stats.CarrierName;
                result.Link = stats.CarrierLink;
                result.Active = stats.CarrierStatus;

            }
            return result;
        }

        public static User UserToDomain(UserView user, SlRole role)
        {
            var result = new User();

            if (user != null)
            {
                result.UserId = user.UserId;
                result.UserName = user.UserName;
                result.Password = user.Password;
                result.Active = user.Active;
                result.SlRole = role;
            }

            return result;
        }

        public static SlRole SlRoleToDomain(SlRoleView role)
        {
            var result = new SlRole();

            if(role!=null)
            {
                result.Active = role.Active;
                result.Name = role.Name;
                result.RoleId = role.RoleId.Value;
            }
            return result;
        }
    }
}
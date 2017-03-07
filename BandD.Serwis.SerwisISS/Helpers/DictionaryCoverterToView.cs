using System;
using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Domain;
using BandD.Serwis.Domain.Dictionaries;

namespace SerwisISS.Helpers
{
    public static class DictionaryCoverterToView
    {
        public static SlOrderStatView SlOrderStatToView(SlOrderStat user)
        {
            var result = new SlOrderStatView();

            if (user != null)
            {
                result.OrderStatusId = user.OrderStatusId;
                result.Name = user.Name;
                result.Active = user.Active;
                result.Description = user.Description;
            }

            return result;
        }
        public static SlCarriersStatView SlCarriersToView(SlCarrierStat user)
        {
            var result = new SlCarriersStatView();
            if (user != null)
            {
                result.CarrierStatusId = user.CarrierStatusId;
                result.CarrierName = user.Name;
                result.CarrierStatus = user.Active;
                result.CarrierLink = user.Link;
            }
            return result;
        }

        public static UserView UserToView(User user)
        {
            var result = new UserView();

            if (user != null)
            {
                result.UserId = user.UserId;
                result.UserName = user.UserName;
                result.Password = user.Password;
                result.Active = user.Active;
                result.Rola = SlRolaToView(user.SlRole);
            }

            return result;
        }

        public static SlRoleView SlRolaToView(SlRole slRole)
        {
            var result = new SlRoleView();
            if (slRole != null)
            {
                result.RoleId = slRole.RoleId;
                result.Name = slRole.Name;
                result.Active = slRole.Active;
            }
            return result;

        }
    }
}
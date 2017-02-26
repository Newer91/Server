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
                result.Name = stats.Name;
                result.Link = stats.Link;
                result.Status = stats.Status;

            }
            return result;
        }
        public static User UserToDomain(UserView user)
        {
            var result = new User();

            if (user != null)
            {
                result.UserId = user.UserId;
                result.UserName = user.UserName;
                result.Password = user.Password;
                result.Active = user.Active;
                //result.Role = user.Role;
            }

            return result;
        }
    }
}
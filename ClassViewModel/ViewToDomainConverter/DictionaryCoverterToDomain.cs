using BandD.Serwis.Domain;
using ClassViewModel.Dictionaries;

namespace ClassViewModel.ViewToDomainConverter
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

        public static User UserToDomain(UserView user)
        {
            var result = new User();

            if (user != null)
            {
                result.UserId = user.UserId;
                result.UserName = user.UserName;
                result.Password = user.Password;
                result.Active = user.Active;
                result.Role = user.Role;
            }

            return result;
        }
    }
}

using BandD.Serwis.Domain;
using ClassViewModel.Dictionaries;

namespace ClassViewModel.DomainToViewConverter
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

        public static UserView UserToView(User user)
        {
            var result = new UserView();

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

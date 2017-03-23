using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Model.DictionarySerivce;
using BandD.Serwis.Tools.ServerTools;
using System;
using System.Collections.ObjectModel;
using System.Security;

namespace BandD.Serwis.Model.Dictionaries
{
    public class UserModel
    {
        private DictionariesServiceClient service = new DictionariesServiceClient();

        #region Login

        public bool Autorauthorization(SecureString password, string userName)
        {
            string pass = SecureTools.CalculateMD5Hash(SecureTools.convertToUNSecureString(password));
            return service.Autorauthorization(pass, userName);
        }

        #endregion

        public ObservableCollection<UserView> GetDataFromUser(string name, bool? status, Guid? role)
        {
            string names = name == null ? string.Empty : name;

            var items = service.GetDataFromUser(names, status, role);
            var result = new ObservableCollection<UserView>();
            foreach (var item in items)
            {
                result.Add(item);
            }

            return result;
        }

        public bool AddNewItem(UserView user, SecureString password)
        {
            user.Password = SecureTools.CalculateMD5Hash(SecureTools.convertToUNSecureString(password));
            return service.AddElementToUsers(user);
        }

        public bool SaveChange(UserView user)
        {
            return service.UpdateElementUsers(user);
        }

        public bool RemoveElement(Guid userId)
        {
            return service.RemoveElementFromUsers(userId);
        }
    }
}
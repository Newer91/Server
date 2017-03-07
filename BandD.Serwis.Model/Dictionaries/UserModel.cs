using System.Security;
using BandD.Serwis.Tools.ServerTools;
using BandD.Serwis.Model.DictionariesService;
using System.Collections.ObjectModel;
using BandD.Serwis.ClassViewModel.Dictionaries;
using System;
using BandD.Serwis.Tools.Logger;

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

        public string AddNewItem(UserView user, SecureString password)
        {
            string result = validatePassword(password);
            if (result == string.Empty)
                service.AddElementToUsers(user);

            return result;
        }

        private string validatePassword(SecureString password)
        {
            throw new NotImplementedException();
        }

        public bool SaveChange(UserView user)
        {
            if (true)// zrobic walidacje    
            {
                service.UpdateElementUsers(user);
                return true;
            }
            else
#pragma warning disable CS0162 // Unreachable code detected
                return false;
#pragma warning restore CS0162 // Unreachable code detected
        }

        public void RemoveElement(Guid userId)
        {
            service.RemoveElementFromUsers(userId);
        }
    }
}
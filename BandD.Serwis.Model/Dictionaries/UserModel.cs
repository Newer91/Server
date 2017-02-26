﻿using System.Security;
using BandD.Serwis.Tools.ServerTools;
using BandD.Serwis.Model.DictionariesService;
using System.Collections.ObjectModel;
using BandD.Serwis.ClassViewModel.Dictionaries;
using System;

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

        public ObservableCollection<UserView> getDataFromUser(string name, bool? status, string role)
        {
            string names = name == null ? string.Empty : name;
            string roles = role == null ? string.Empty : role;
 
            var items = service.getDataFromUser(names, status, roles);
            var result = new ObservableCollection<UserView>();
            foreach (var item in items)
            {
                result.Add(item);
            }

            return result;
        }

        public bool AddNewItem(UserView user)
        {
            if (true)// zrobic walidacje    
            {
                service.addElementToUsers(user);
                return true;
            }
            else
#pragma warning disable CS0162 // Unreachable code detected
                return false;
#pragma warning restore CS0162 // Unreachable code detected
        }

        public bool SaveChange(UserView user)
        {
            if (true)// zrobic walidacje    
            {
                service.updateElementUsers(user);
                return true;
            }
            else
#pragma warning disable CS0162 // Unreachable code detected
                return false;
#pragma warning restore CS0162 // Unreachable code detected
        }

        public void RemoveElement(Guid userId)
        {
            service.removeElementFromUsers(userId);
        }
    }
}
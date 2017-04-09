using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Model.DictionarySerivce;
using System;
using System.Collections.ObjectModel;

namespace BandD.Serwis.Model.Dictionaries
{
    public class RolesModel
    {
        private DictionariesServiceClient service = new DictionariesServiceClient();

        public ObservableCollection<SlRoleView> GetAllActiveRole()
        {
            return getRole(true);
        }

        public ObservableCollection<SlRoleView> GetAllRole()
        {
            return getRole(true);            
        }

        private ObservableCollection<SlRoleView> getRole(bool all)
        {
            ObservableCollection<SlRoleView> result = new ObservableCollection<SlRoleView>();
            var items = service.GetAllRoles(all);
            foreach (var item in items)
            {
                result.Add(item);
            }

            return result;
        }

        public ObservableCollection<SlRoleView> GetDataFromRole(string name, bool? status)
        {
            string names = name == null ? string.Empty : name;

            var items = service.GetDataFromRole(names, status);
            var result = new ObservableCollection<SlRoleView>();
            foreach (var item in items)
            {
                result.Add(item);
            }

            return result;
        }

        public bool RemoveElement(Guid roleId)
        {
            return service.RemoveElementFromRole(roleId);
        }

        public bool SaveChange(SlRoleView role)
        {
            return service.UpdateElementSlRole(role);
        }

        public bool AddNewItem(SlRoleView role)
        {
            return service.AddElementToSlRole(role);
        }
    }
}

using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Model.DictionariesService;
using System.Collections.ObjectModel;
using System;

namespace BandD.Serwis.Model.Dictionaries
{
    public class RolesModel
    {
        private DictionariesServiceClient service = new DictionariesServiceClient();

        public ObservableCollection<SlRoleView> GetAllActiveRole()
        {
            ObservableCollection<SlRoleView> result = new ObservableCollection<SlRoleView>();
            var items = service.GetAllRoles(false);
            foreach (var item in items)
            {
                result.Add(item);
            }

            return result;
        }

        public ObservableCollection<SlRoleView> GetAllRole()
        {
            ObservableCollection<SlRoleView> result = new ObservableCollection<SlRoleView>();
            var items = service.GetAllRoles(true);
            foreach (var item in items)
            {
                result.Add(item);
            }

            return result;
        }
    }
}

using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Model.DictionariesService;
using System.Collections.ObjectModel;

namespace BandD.Serwis.Model.Dictionaries
{
    public class RolesModel
    {
        private DictionariesServiceClient service = new DictionariesServiceClient();

        public ObservableCollection<SlRoleView> GetAllActiveRole()
        {
            ObservableCollection<SlRoleView> result = new ObservableCollection<SlRoleView>();
            var items = service.GetAllActiveRoles();
            foreach (var item in items)
            {
                result.Add(item);
            }

            return result;
        }
    }
}

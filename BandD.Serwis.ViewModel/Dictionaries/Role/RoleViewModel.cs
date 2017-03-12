using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Model.Dictionaries;
using BandD.Serwis.Tools.ClientTools;
using BandD.Serwis.ViewModel.Class;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace BandD.Serwis.ViewModel.Dictionaries.Role
{
    public class RoleViewModel: BaseViewClass
    {
        private RolesModel model;
        private ActiveItem activity;
        private ObservableCollection<ActiveItem> activeComboBox;
        private ObservableCollection<SlRoleView> roles;
        private SlRoleView role;
        private string name;

        public SlRoleView Role
        {
            get { return role; }
            set { role = value; OnPropertyChanged(); }
        }

        public ObservableCollection<SlRoleView> Roles
        {
            get { return roles; }
            set { roles = value; OnPropertyChanged(); }
        }

        public ActiveItem Active
        {
            get { return activity; }
            set { activity = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ActiveItem> ActiveComboBox
        {
            get { return activeComboBox; }
            set { activeComboBox = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public RoleViewModel()
        {
            model = new RolesModel();
            ActiveComboBox = new ActiveItem().getActiveList();
            Active = ActiveComboBox[0];
        }

        public ICommand Search { get { return new RelayCommand(SearchExecute, null); } }
        public ICommand Remove { get { return new RelayCommand(RemoveExecute, null); } }

        private void RemoveExecute()
        {
            var question = MessageBox.Show("Czy na pewno chcesz usunąc wskazany element?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
                if (!model.RemoveElement(Role.RoleId.Value))
                    ClientMessage.ServerErrorMessage();
            SearchExecute();
        }

        public void SearchExecute()
        {
            Roles = model.GetDataFromRole(name, activity.Value);
        }

    }
}

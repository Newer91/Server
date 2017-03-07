using BandD.Serwis.ViewModel.Class;
using System.Windows.Input;
using System.Windows;
using BandD.Serwis.ClassViewModel.Dictionaries;
using System.Collections.ObjectModel;
using BandD.Serwis.Model.Dictionaries;

namespace BandD.Serwis.ViewModel.Dictionaries.Users
{
    public class UserStatusViewModel : BaseViewClass
    {
        private UserModel model;
        private ActiveItem activity;
        private ObservableCollection<UserView> userList;
        private ObservableCollection<ActiveItem> activeComboBox;
        private ObservableCollection<SlRoleView> roles;
        private UserView user;
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

        public UserStatusViewModel()
        {
            model = new UserModel();
            ActiveComboBox = new ActiveItem().getActiveList();
            Active = ActiveComboBox[0];
            Roles = new RolesModel().GetAllActiveRole();
            Roles.Insert(0, new SlRoleView() { RoleId = null, Name = "Wszystkie" });
            Role = Roles[0];
        }

        public ObservableCollection<UserView> UserList
        {
            get { return userList; }
            set { userList = value; OnPropertyChanged(); }
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

        public UserView User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(); }
        }

        public ICommand Search { get { return new RelayCommand(SearchExecute, null); } }
        public ICommand Remove { get { return new RelayCommand(RemoveExecute, null); } }

        private void RemoveExecute()
        {
            var question = MessageBox.Show("Czy na pewno chcesz usunąc wskazany element?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
                model.RemoveElement(User.UserId);
            SearchExecute();
        }

        public void SearchExecute()
        {
            UserList = model.GetDataFromUser(name, activity.Value, Role.RoleId);
        }
    }
}

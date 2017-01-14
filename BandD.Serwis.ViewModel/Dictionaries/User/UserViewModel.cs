using BandD.Serwis.Model;
using BandD.Serwis.ViewModel.Class;
using System.Windows.Input;
using System.Windows;
using ClassViewModel.Dictionaries;
using System.Collections.ObjectModel;

namespace BandD.Serwis.ViewModel.Dictionaries.Users
{
    public class UserStatusViewModel : BaseViewClass
    {        
        private UserModel model;
        private ObservableCollection<UserView> userList;
        private UserView user;
        private string name;
        private string role;
        private bool activity;

        public UserStatusViewModel()
        {
            model = new UserModel();
        }

        public ObservableCollection<UserView> UserList
        {
            get { return userList; }
            set { userList = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public string Role
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public bool Active
        {
            get { return activity; }
            set { activity = value; OnPropertyChanged(); }
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
            UserList = model.getDataFromUser(name, activity,role);
        }
    }
}

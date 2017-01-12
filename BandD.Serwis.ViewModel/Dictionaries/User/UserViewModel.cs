using System.Collections.Generic;
using BandD.Serwis.Model;
using BandD.Serwis.Domain;
using BandD.Serwis.ViewModel.Class;

namespace BandD.Serwis.ViewModel.Dictionaries.Users
{
    public class UserStatusViewModel : BaseViewClass
    {
        private UserModel model;
        private List<User> userList;
        private User userStat;
        private string name;
        private bool activity;

        public UserStatusViewModel()
        {
            model = new UserModel();
        }

        public List<User> UserList
        {
            get { return userList; }
            set { userList = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public bool Active
        {
            get { return activity; }
            set { activity = value; OnPropertyChanged(); }
        }

        public User UserStat
        {
            get { return userStat; }
            set { userStat = value; OnPropertyChanged(); }
        }
    }
}

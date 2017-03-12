using System;
using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Class;
using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Tools.Extension;
using System.Windows;
using System.Security;
using BandD.Serwis.Model.Dictionaries;
using System.Collections.ObjectModel;
using BandD.Serwis.Tools.ClientTools;

namespace BandD.Serwis.ViewModel.Dictionaries.User
{
    public class UserDetailViewModel : BaseViewClass
    {
        private UserModel model;
        private ViewType viewType;
        private UserView user;
        private SlRoleView role;
        private string title;
        private bool isReadOnly;
        private bool isEnable;
        private string cancelButtonName;
        private SecureString securePassword;
        private ObservableCollection<SlRoleView> aveilableRoles;


        #region Public propertis

        public ViewType ViewType
        {
            get { return viewType; }
            set { viewType = value; OnPropertyChanged(); }
        }

        public bool IsReadOnly
        {
            get { return isReadOnly; }
            set { isReadOnly = value; OnPropertyChanged(); }
        }

        public bool IsEnable
        {
            get { return isEnable; }
            set { isEnable = value; OnPropertyChanged(); }
        }

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        public UserView User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(); }
        }

        public SlRoleView Role
        {
            get { return role; }
            set { role = value; OnPropertyChanged(); }
        }

        public string CancelButtonName
        {
            get { return cancelButtonName; }
            set { cancelButtonName = value; OnPropertyChanged(); }
        }

        public SecureString SecurePassword
        {
            get { return securePassword; }
            set { securePassword = value; OnPropertyChanged(); }
        }

        public ObservableCollection<SlRoleView> AveilableRoles
        {
            get { return aveilableRoles; }
            set { aveilableRoles = value; OnPropertyChanged(); }
        }

        #endregion

        public UserDetailViewModel(ViewType viewType)
        {
            ViewType = viewType;
            SetViewMode(viewType);
            model = new UserModel();
            CreateRoleList(viewType);
        }

        private void CreateRoleList(ViewType viewType)
        {
            if (viewType == ViewType.New || viewType == ViewType.Edit)
                AveilableRoles = new RolesModel().GetAllActiveRole();
            if (viewType == ViewType.View)
                AveilableRoles = new RolesModel().GetAllRole();
        }

        private void SetViewMode(ViewType viewType)
        {
            if (viewType == ViewType.View)
            {
                IsEnable = false;
                IsReadOnly = true;
                CancelButtonName = "Zamknij";
            }
            else
            {
                IsEnable = true;
                IsReadOnly = false;
                CancelButtonName = "Anuluj";
            }

            if (viewType == ViewType.New)
                user = new UserView();

            Title = ClientTools.SetTitleToDetailView(viewType);
        }

        public bool SaveChange()
        {
            bool result = false;

            var question = MessageBox.Show("Czy chcesz zapisać dane?", "Informacja", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
            {
                if (validateUser())
                {
                    if (ViewType == ViewType.Edit)
                    {
                        if (!model.SaveChange(User))
                        {
                            ClientMessage.ServerErrorMessage();
                            result = false;
                        }
                    }
                    else if (ViewType == ViewType.New)
                    {
                        result = AddNewItem();
                    }
                    result = true;
                }
            }
            else
                return false;

            if (result)
                MessageBox.Show("Dane zapisano", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

            return result;
        }

        public bool AddNewItem()
        {
            user.UserId = Guid.NewGuid();            
            user.Rola = Role;

            if (!model.AddNewItem(user, securePassword))
            {
                ClientMessage.ServerErrorMessage();
                return false;
            }
            return true;
        }

        private bool validateUser()
        {
            bool result = true;
            if (!validatePassword() || !validateOtherElements())
                result = false;

            return result;
        }

        private bool validateOtherElements()
        {
            bool result = true;

            if (!ClientTools.ValidateProperty(User.UserName))
            {
                MessageBox.Show("Nazwa użytkownika nie może być pusta.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                result = false;
            }
            if (Role == null || Role.RoleId == null)
            {
                MessageBox.Show("Należy wybrać role użytkownika.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                result = false;
            }

            return result;
        }

        private bool validatePassword()
        {
            bool result = true;
            if (securePassword.Length < 4)
            {
                MessageBox.Show("Hasło nie może być krótsze niż 5 znaków", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                result = false;
            }
            return result;
        }
    }
}

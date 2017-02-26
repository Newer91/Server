using System;
using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Class;
using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Tools.Extension;
using System.Windows;
using System.Security;
using BandD.Serwis.Model.Dictionaries;

namespace BandD.Serwis.ViewModel.Dictionaries.User
{
    public class UserDetailViewModel: BaseViewClass
    {
        private UserModel model;
        private ViewType viewType;
        private UserView user;
        private string title;
        private bool isReadOnly;
        private bool isEnable;
        private string cancelButtonName;
        private SecureString securePassword;

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

        #endregion

        public UserDetailViewModel(ViewType viewType)
        {
            ViewType = viewType;
            SetViewMode(viewType);
            model = new UserModel();
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
            throw new NotImplementedException();//brak oblsugi hasel
#pragma warning disable CS0162 // Unreachable code detected
            bool result = false;
#pragma warning restore CS0162 // Unreachable code detected
            var question = MessageBox.Show("Czy chcesz zapisać dane?", "Informacja", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
                if (ViewType == ViewType.Edit)
                    result = model.SaveChange(User);
                else if (ViewType == ViewType.New)
                    result = AddNewItem();
            if (result)
            {
                MessageBox.Show("Dane zapisano", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                //MessageBox.Show("Pole opis i nazwa nie mogą być puste", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                throw new NotImplementedException();
            return false;
        }

        public bool AddNewItem()
        {
            throw new NotImplementedException();//BNrak oblsugi hasel
            user.UserId = Guid.NewGuid();
            return model.AddNewItem(user);
        }
    }
}

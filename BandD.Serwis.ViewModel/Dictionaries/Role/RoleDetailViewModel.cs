using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Model.Dictionaries;
using BandD.Serwis.Tools.ClientTools;
using BandD.Serwis.Tools.Extension;
using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Class;
using System;
using System.Windows;

namespace BandD.Serwis.ViewModel.Dictionaries.Role
{
    public class RoleDetailViewModel: BaseViewClass
    {
        private RolesModel model;
        private SlRoleView role;
        private ViewType viewType;
        private string title;
        private bool isReadOnly;
        private bool isEnable;
        private string cancelButtonName;

        public SlRoleView Role
        {
            get { return role; }
            set { role = value; OnPropertyChanged(); }
        }

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

        public string CancelButtonName
        {
            get { return cancelButtonName; }
            set { cancelButtonName = value; OnPropertyChanged(); }
        }

        public RoleDetailViewModel(ViewType viewType)
        {
            ViewType = viewType;
            model = new RolesModel();
            SetViewMode(viewType);
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
                role = new SlRoleView();

            Title = ClientTools.SetTitleToDetailView(viewType);
        }

        public bool SaveChange()
        {
            bool result = true;
            bool serverResult;
            var question = MessageBox.Show("Czy chcesz zapisać dane?", "Informacja", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
            {
                if (ClientTools.ValidateProperty(role.Name))
                {
                    if (ViewType == ViewType.Edit)
                        serverResult = model.SaveChange(Role);
                    else
                        serverResult = AddNewItem();

                    if (!serverResult)
                    {
                        ClientMessage.ServerErrorMessage();
                        result = false;
                    }
                }
                else
                {
                    MessageBox.Show("Pole nazwa nie może być puste", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    result = false;
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
            role.RoleId = Guid.NewGuid();
            return model.AddNewItem(role);
        }
    }
}

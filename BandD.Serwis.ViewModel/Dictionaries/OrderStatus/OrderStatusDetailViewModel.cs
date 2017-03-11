using System;
using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.Model.Dictionaries;
using System.Windows;
using BandD.Serwis.ViewModel.Class;
using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Tools.Extension;
using BandD.Serwis.Tools.ClientTools;

namespace BandD.Serwis.ViewModel.Dictionaries.OrderStatus
{
    public class OrderStatusDetailViewModel : BaseViewClass
    {
        private OrderStatusModel model;
        private ViewType viewType;
        private SlOrderStatView stats;
        private string title;
        private bool isReadOnly;
        private bool isEnable;
        private string cancelButtonName;

        #region Public properties

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

        public SlOrderStatView Stats
        {
            get { return stats; }
            set { stats = value; OnPropertyChanged(); }
        }

        public string CancelButtonName
        {
            get { return cancelButtonName; }
            set { cancelButtonName = value; OnPropertyChanged(); }
        }

        #endregion

        public OrderStatusDetailViewModel(ViewType viewType)
        {
            ViewType = viewType;
            SetViewMode(viewType);
            model = new OrderStatusModel();
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
                stats = new SlOrderStatView();

            Title = ClientTools.SetTitleToDetailView(viewType);
        }

        public bool SaveChange()
        {
            bool result = true;
            bool serverResult;
            var question = MessageBox.Show("Czy chcesz zapisać dane?", "Informacja", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
            {
                if (ClientTools.ValidateProperty(stats.Name) && ClientTools.ValidateProperty(stats.Description))
                {
                    if (ViewType == ViewType.Edit)
                        serverResult = model.SaveChange(stats);
                    else
                        serverResult = AddNewItem();

                    if (!serverResult)
                    {
                        ClientMessage.ServerErrorMessage();
                        result = false;
                    }
                }
                else
                    MessageBox.Show("Pole opis i nazwa nie mogą być puste", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (result)            
                MessageBox.Show("Dane zapisano", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            
            return result;
        }

        public bool AddNewItem()
        {
            stats.OrderStatusId = Guid.NewGuid();
            return model.AddNewItem(stats);
        }
    }
}

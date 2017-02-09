﻿using BandD.Serwis.Model.Dictionaries;
using BandD.Serwis.Tools.Extension;
using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Class;
using ClassViewModel.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BandD.Serwis.ViewModel.Dictionaries.CarrierStatus
{

    public class CarrierStatusDetailViewModel : BaseViewClass
    {
        private CarrierStatusModel model;
        private ViewType viewType;
        private SlCarriersStatView stats;
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

        public SlCarriersStatView Stats
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

        public CarrierStatusDetailViewModel(ViewType viewType)
        {
            ViewType = viewType;
            SetViewMode(viewType);
            model = new CarrierStatusModel();
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
                stats = new SlCarriersStatView();

            Title = ClientTools.SetTitleToDetailView(viewType);
        }
        public bool SaveChange()
        {
            bool result = false;
            var question = MessageBox.Show("Czy chcesz zapisać dane?", "Informacja", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
                if (ViewType == ViewType.Edit)
                    result = model.SaveChange(stats);
                else if (ViewType == ViewType.New)
                    result = AddNewItem();
            if (result)
            {
                MessageBox.Show("Dane zapisano", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("Pole opis i nazwa nie mogą być puste", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
            
        }
        public bool AddNewItem()
        {
            stats.CarrierStatusId = Guid.NewGuid();
            return model.AddNewItem(stats);
        }
    }
}

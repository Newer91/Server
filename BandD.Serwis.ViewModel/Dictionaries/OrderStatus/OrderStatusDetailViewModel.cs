﻿using System;
using BandD.Serwis.Domain;
using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.Model.Dictionaries;

namespace BandD.Serwis.ViewModel.Dictionaries.OrderStatus
{
    public class OrderStatusDetailViewModel : BaseClass
    {
        private OrderStatusModel model;
        private ViewType viewType;
        private SlOrderStat stats;
        private string title;
        private bool isReadOnly;
        private bool isEnable;
        private string cancelButtonName;

        #region Public propertis

        public ViewType ViewType
        {
            get { return viewType; }
            set { viewType = value;OnPropertyChanged(); }
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

        public SlOrderStat Stats
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
                stats = new SlOrderStat();
        }

        public bool SaveChange()
        {
            return model.SaveChange(stats);
        }

        public bool AddNewItem()
        {
            stats.OrderStatusId = Guid.NewGuid();
            return model.AddNewItem(stats);
        }
    }
}

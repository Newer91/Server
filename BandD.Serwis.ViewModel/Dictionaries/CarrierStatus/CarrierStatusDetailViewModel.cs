﻿using BandD.Serwis.Model.Dictionaries;
using BandD.Serwis.Tools.Extension;
using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.ViewModel.Class;
using BandD.Serwis.ClassViewModel.Dictionaries;
using System;
using System.Windows;
using BandD.Serwis.Tools.ClientTools;

namespace BandD.Serwis.ViewModel.Dictionaries.CarrierStatus
{

    public class CarrierStatusDetailViewModel : BaseViewClass
    {
        private CarrierStatusModel model;
        private ViewType viewType;
        private SlCarriersStatView carrier;
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

        public SlCarriersStatView Carrier
        {
            get { return carrier; }
            set { carrier = value; OnPropertyChanged(); }
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
                carrier = new SlCarriersStatView();

            Title = ClientTools.SetTitleToDetailView(viewType);
        }
        public bool SaveChange()
        {
            bool result = false;
            bool serverResult;
            var question = MessageBox.Show("Czy chcesz zapisać dane?", "Informacja", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
            {
                if (ClientTools.ValidateProperty(carrier.Name) && ClientTools.ValidateProperty(carrier.Link))
                {
                    if (ViewType == ViewType.Edit)
                        serverResult = result = model.SaveChange(carrier);
                    else
                        serverResult = result = AddNewItem();

                    if (!serverResult)
                    {
                        ClientMessage.ServerErrorMessage();
                        result = false;
                    }
                }
                else
                {
                    MessageBox.Show("Pole opis i nazwa nie mogą być puste", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    result = false;
                }
            }
            else
                return false;

            if (result)            
                MessageBox.Show("Dane zapisano", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);           

            return false;

        }
        public bool AddNewItem()
        {
            carrier.CarrierStatusId = Guid.NewGuid();
            return model.AddNewItem(carrier);
        }
    }
}


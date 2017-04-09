using BandD.Serwis.ClassViewModel.Dictionaries;
using BandD.Serwis.Tools.ServerTools.Extension;
using BandD.Serwis.Tools.Extension;
using BandD.Serwis.ViewModel.Class;
using ClassViewModel.Dictionaries;
using System;

namespace BandD.Serwis.ViewModel.Dictionaries.Client
{
    public class ClientDetailViewModel : BaseViewClass
    {
        private ClientView client { get; set; }
        private ViewType viewType;
        private string title;
        private bool isReadOnly;
        private bool isEnable;
        private string cancelButtonName;

        public ClientView Client
        {
            get { return client; }
            set { client = value; OnPropertyChanged(); }
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

        public ClientDetailViewModel(ViewType viewType)
        {
            ViewType = viewType;
            //model = new RolesModel();
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
                Client = new ClientView();

            Title = ClientTools.SetTitleToDetailView(viewType);
        }

        public bool SaveChange()
        {
            throw new NotImplementedException();
        }
    }
}

using BandD.Serwis.Model.DictionariesService;
using BandD.Serwis.Tools.Extension;
using System.Collections.Generic;
using System.Linq;
using System;
using BandD.Serwis.Domain;
using ClassViewModel.Dictionaries;
using System.Collections.ObjectModel;
using ClassViewModel.DomainToViewConverter;
using ClassViewModel.ViewToDomainConverter;

namespace BandD.Serwis.Model.Dictionaries
{
    public class OrderStatusModel
    {
        private DictionariesServiceClient service = new DictionariesServiceClient();

        public ObservableCollection<SlOrderStatView> getDataFromSlOrderStat(string name, bool? activity)
        {
            string names = name == null ? string.Empty : name;
            var items = service.getDataFromSlOrderStat(names, activity).ToList();
            var result = new ObservableCollection<SlOrderStatView>();
            foreach (var item in items)
            {
                result.Add(DictionaryCoverterToView.SlOrderStatToView(item));
            }

            return result;
        }

        public bool SaveChange(SlOrderStatView stats)
        {
            if (ClientTools.ValidateProperty(stats.Name) && ClientTools.ValidateProperty(stats.Description))
            {
                service.updateElementSlOrderStat(DictionaryCoverterToDomain.SlOrderStatToDomain(stats));
                return true;
            }
            else
                return false;          
        }

        public bool AddNewItem(SlOrderStatView stats)
        {
            if (ClientTools.ValidateProperty(stats.Name) && ClientTools.ValidateProperty(stats.Description))
            {
                service.addElementToSlOrderStat(DictionaryCoverterToDomain.SlOrderStatToDomain(stats));
                return true;
            }
            else
                return false;
        }

        public void RemoveElement(Guid id)
        {
            service.removeElementFromSlOrderStat(id);
        }
    }
}
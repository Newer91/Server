﻿using BandD.Serwis.Model.DictionariesService;
using BandD.Serwis.Tools.Extension;
using BandD.Serwis.ClassViewModel.Dictionaries;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BandD.Serwis.Model.Dictionaries
{
    public class CarrierStatusModel
    {
        private DictionariesServiceClient service = new DictionariesServiceClient();

        public ObservableCollection<SlCarriersStatView> getDataFromSlCarrierStat(string name, bool? carrierStatus)
        {
            string names = name == null ? string.Empty : name;
            var items = service.getDataFromSlCarrierStat(names, carrierStatus).ToList();
            var result = new ObservableCollection<SlCarriersStatView>();
            foreach (var item in items)
            {
                result.Add(item);
            }
            return result;
        }
        public bool SaveChange(SlCarriersStatView stats)
        {
            if (ClientTools.ValidateProperty(stats.Name) && ClientTools.ValidateProperty(stats.Link))
             {
                service.updateElementSlCarrierStat(stats);
                return true;

            }
            else
                return false;

        }
        public bool AddNewItem(SlCarriersStatView stats)
        {
            if (ClientTools.ValidateProperty(stats.Name) && ClientTools.ValidateProperty(stats.Link))
            {
                service.addElementToSlCarrierStat(stats);
                return true;
            }
            else
                return false;
        }
        public void RemoveElement(Guid id)
        {
            service.removeElementFromSlCarrierStat(id);
        }
    }
}

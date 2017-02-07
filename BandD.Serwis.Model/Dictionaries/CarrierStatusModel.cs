using BandD.Serwis.Model.DictionariesService;
using BandD.Serwis.Tools.Extension;
using ClassViewModel.Dictionaries;
using ClassViewModel.DomainToViewConverter;
using ClassViewModel.ViewToDomainConverter;
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
                result.Add(DictionaryCoverterToView.SlCarriersToView(item));
            }
            return result;
        }
        public bool SaveChange(SlCarriersStatView stats)
        {
            if (ClientTools.ValidateProperty(stats.CarrierName) && ClientTools.ValidateProperty(stats.CarrierLink))
             {
                service.updateElementSlCarrierStat(DictionaryCoverterToDomain.SlCarrierStatToDomain(stats));
                return true;

            }
            else
                return false;

        }
        public bool AddNewItem(SlCarriersStatView stats)
        {
            if (ClientTools.ValidateProperty(stats.CarrierName) && ClientTools.ValidateProperty(stats.CarrierLink))
            {
                service.addElementToSlCarrierStat(DictionaryCoverterToDomain.SlCarrierStatToDomain(stats));
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

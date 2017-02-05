using BandD.Serwis.Domain;
using System;

namespace ClassViewModel.Dictionaries
{
    public class SlCarriersStatView
    {
        public Guid CarrierStatusId { get; set; }

        public string CarrierName { get; set; }
        public bool CarrierStatus { get; set; }

        public string CarrierLink { get; set; }
    }
}

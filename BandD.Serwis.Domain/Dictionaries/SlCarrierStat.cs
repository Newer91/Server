using System;

namespace BandD.Serwis.Domain.Dictionaries
{
    public class SlCarrierStat
    {
        public SlCarrierStat() { }
        public Guid CarrierStatusId { get; set; }
        public string CarrierName { get; set; }
        public bool CarrierStatus { get; set; }
        public string CarrierLink { get; set; }

    }
}

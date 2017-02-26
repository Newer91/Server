using System;

namespace BandD.Serwis.Domain.Dictionaries
{
    public class SlCarrierStat
    {
        public SlCarrierStat() { }
        public Guid CarrierStatusId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Link { get; set; }
        public bool Active { get; set; }
    }
}

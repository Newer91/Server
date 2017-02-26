using System;

namespace BandD.Serwis.ClassViewModel.Dictionaries
{
    [Serializable]
    public class SlCarriersStatView
    {
        public Guid CarrierStatusId { get; set; }

        public string CarrierName { get; set; }
        public bool CarrierStatus { get; set; }

        public string CarrierLink { get; set; }
    }
}

using System;

namespace BandD.Serwis.ClassViewModel.Dictionaries
{
    [Serializable]
    public class SlCarriersStatView
    {
        public Guid CarrierStatusId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Link { get; set; }
    }
}

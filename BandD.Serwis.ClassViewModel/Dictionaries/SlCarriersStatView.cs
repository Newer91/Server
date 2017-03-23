using System;
using System.Runtime.Serialization;

namespace BandD.Serwis.ClassViewModel.Dictionaries
{
    [Serializable]
    public class SlCarriersStatView
    {
        [DataMember]
        public Guid CarrierStatusId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public string Link { get; set; }
    }
}

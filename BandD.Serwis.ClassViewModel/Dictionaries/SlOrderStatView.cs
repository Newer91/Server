using System;
using System.Runtime.Serialization;

namespace BandD.Serwis.ClassViewModel.Dictionaries
{
    [Serializable]
    public class SlOrderStatView
    {
        [DataMember]
        public Guid OrderStatusId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}

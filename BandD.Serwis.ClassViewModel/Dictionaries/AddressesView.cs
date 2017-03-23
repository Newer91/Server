using System;
using System.Runtime.Serialization;

namespace BandD.Serwis.ClassViewModel.Dictionaries
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class AddressesView
    {
        [DataMember]
        public Guid AddressId { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string Number { get; set; }
        [DataMember]
        public int PostCode { get; set; }
        [DataMember]
        public bool IsCompanyAddres { get; set; }
        [DataMember]
        public bool IsDeliveryAddres { get; set; }
        [DataMember]
        public string ClientName { get; set; } 
    }
}

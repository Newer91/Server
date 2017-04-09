using BandD.Serwis.ClassViewModel.Dictionaries;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ClassViewModel.Dictionaries
{
    public class ClientView
    {
        [DataMember]
        public Guid ClientId { get; set; }
        [DataMember]
        public string ShortName { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int NIP { get; set; }
        [DataMember]
        public int Regon { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public List<AddressesView> Address { get; set; }
    }
}

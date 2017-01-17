using BandD.Serwis.Domain.Dictionaries;
using System;
using System.Runtime.Serialization;

namespace BandD.Serwis.Domain
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class User
    {
        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public virtual SlRole SlRole { get; set; }
    }
}

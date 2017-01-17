using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BandD.Serwis.Domain.Dictionaries
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class SlRole
    {
        [DataMember]
        public Guid RoleId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual IList<User> Users { get; set; }
    }
}

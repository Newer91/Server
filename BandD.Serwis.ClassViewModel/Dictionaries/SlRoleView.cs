using System;
using System.Runtime.Serialization;

namespace BandD.Serwis.ClassViewModel.Dictionaries
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class SlRoleView
    {
        [DataMember]
        public Guid? RoleId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Active { get; set; }
    }
}

using System;
using System.Runtime.Serialization;

namespace BandD.Serwis.ClassViewModel.Dictionaries
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class UserView
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
        public SlRoleView Rola { get; set; }
    }
}

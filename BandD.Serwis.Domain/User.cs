using BandD.Serwis.Domain.Dictionaries;
using System;
using System.Runtime.Serialization;

namespace BandD.Serwis.Domain
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public virtual SlRole SlRole { get; set; }
    }
}

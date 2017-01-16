using BandD.Serwis.Domain.Dictionaries;
using System;

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

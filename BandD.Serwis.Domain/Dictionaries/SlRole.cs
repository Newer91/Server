using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BandD.Serwis.Domain.Dictionaries
{
    public class SlRole
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public virtual IList<User> Users { get; set; }
    }
}

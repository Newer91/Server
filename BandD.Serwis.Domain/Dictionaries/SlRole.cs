using System;
using System.Collections.Generic;

namespace BandD.Serwis.Domain.Dictionaries
{
    public class SlRole
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual IList<User> Users { get; set; }
    }
}

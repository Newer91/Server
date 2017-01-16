using System;

namespace BandD.Serwis.Domain.Dictionaries
{
    public class SlRole
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BandD.Serwis.Domain
{
    [Serializable]
    public class Client
    {
        public Client()
        {
            this.Address = new HashSet<Address>();
        }

        public Guid ClientId { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public int NIP { get; set; }
        public int Regon { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}

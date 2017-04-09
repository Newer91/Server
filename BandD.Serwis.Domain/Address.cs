using System;
using System.Collections.Generic;

namespace BandD.Serwis.Domain
{
    [Serializable]
    public class Address
    {
        public Address()
        {
            this.Client = new HashSet<Client>();
        }

        public Guid AddressId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public int PostCode { get; set; }
        public bool IsCompanyAddres { get; set; }
        public bool IsDeliveryAddres { get; set; }

        public virtual ICollection<Client> Client { get; set; }
    }
}

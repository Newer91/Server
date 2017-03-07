using BandD.Serwis.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SerwisISS.EntityClassConfiguration
{
    public class AddressEntityConfiguration: EntityTypeConfiguration<Address>
    {
        public AddressEntityConfiguration()
        {
            this.HasKey<Guid>(k => k.AddressId);
        }
    }
}
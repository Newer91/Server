using BandD.Serwis.Domain;
using System;
using System.Data.Entity.ModelConfiguration;

namespace SerwisISS.EntityClassConfiguration
{
    public class ClientEntityConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientEntityConfiguration()
        {
            this.HasKey<Guid>(k => k.ClientId);

            this.HasMany<Address>(a => a.Address)
                .WithMany(c => c.Client)
                .Map(ca =>
                {
                    ca.MapLeftKey("ClientRefId");
                    ca.MapRightKey("AddressRefId");
                    ca.ToTable("ClientsAddress");
                });
        }
    }
}
using BandD.Serwis.Domain;
using System;
using System.Data.Entity.ModelConfiguration;

namespace BandD.Serwis.Server.EntityClassConfiguration
{
    public class LoginEntityConfiguration : EntityTypeConfiguration<User>
    {
        public LoginEntityConfiguration()
        {
            this.HasKey<Guid>(k => k.UserId);
        }
    }
}

using BandD.Serwis.Domain;
using System;
using System.Data.Entity.ModelConfiguration;

namespace BandD.Serwis.Server.EntityClassConfiguration
{
    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            this.HasKey<Guid>(k => k.UserId);
        }
    }
}

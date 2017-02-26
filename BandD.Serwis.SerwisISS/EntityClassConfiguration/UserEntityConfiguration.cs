using BandD.Serwis.Domain;
using System;
using System.Data.Entity.ModelConfiguration;

namespace SerwisISS.EntityClassConfiguration
{
    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            this.HasKey<Guid>(k => k.UserId);
        }
    }
}
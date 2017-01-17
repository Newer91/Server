using BandD.Serwis.Domain;
using System.Data.Entity;
using System;
using System.Data.Entity.ModelConfiguration;
using BandD.Serwis.Domain.Dictionaries;

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

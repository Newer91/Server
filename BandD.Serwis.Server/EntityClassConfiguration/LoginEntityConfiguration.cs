using BandD.Serwis.Class;
using System;
using System.Data.Entity.ModelConfiguration;

namespace BandD.Serwis.Server.EntityClassConfiguration
{
    public class LoginEntityConfiguration : EntityTypeConfiguration<Login>
    {
        public LoginEntityConfiguration()
        {
            this.HasKey<Guid>(k => k.LoginId);
        }
    }
}

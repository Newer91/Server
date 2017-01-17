using BandD.Serwis.Domain.Dictionaries;
using System;
using System.Data.Entity.ModelConfiguration;

namespace BandD.Serwis.Server.EntityClassConfiguration
{
    public class SlRoleEntityConfiguration : EntityTypeConfiguration<SlRole>
    {
        public SlRoleEntityConfiguration()
        {
            this.HasKey<Guid>(k => k.RoleId);

            this.HasMany(u => u.Users).
                WithRequired(r => r.SlRole).
                WillCascadeOnDelete(false);
        }
    }
}

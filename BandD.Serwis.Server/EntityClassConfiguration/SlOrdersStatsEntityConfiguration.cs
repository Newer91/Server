using BandD.Serwis.Class;
using System;
using System.Data.Entity.ModelConfiguration;

namespace BandD.Serwis.Server.EntityClassConfiguration
{
    public class SlOrdersStatsEntityConfiguration : EntityTypeConfiguration<SlOrderStat>
    {
        public SlOrdersStatsEntityConfiguration()
        {
            this.HasKey<Guid>(k => k.OrderStatusId);
        }
    }
}

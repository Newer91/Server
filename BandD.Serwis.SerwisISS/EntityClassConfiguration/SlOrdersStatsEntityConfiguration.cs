using BandD.Serwis.Domain;
using System;
using System.Data.Entity.ModelConfiguration;

namespace SerwisISS.EntityClassConfiguration
{
    public class SlOrdersStatsEntityConfiguration : EntityTypeConfiguration<SlOrderStat>
    {
        public SlOrdersStatsEntityConfiguration()
        {
            this.HasKey<Guid>(k => k.OrderStatusId);
        }
    }
}
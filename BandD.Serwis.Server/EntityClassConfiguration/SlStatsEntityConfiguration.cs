using BandD.Serwis.Class;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandD.Serwis.Server.EntityClassConfiguration
{
    public class SlStatsEntityConfiguration : EntityTypeConfiguration<SlStat>
    {
        public SlStatsEntityConfiguration()
        {
            this.HasKey<Guid>(k => k.StatsId);
        }
    }
}

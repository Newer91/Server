using BandD.Serwis.Domain.Dictionaries;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandD.Serwis.Server.EntityClassConfiguration
{
    public class SlCarrierStatEntityConfiuration :EntityTypeConfiguration<SlCarrierStat>
    {
        public SlCarrierStatEntityConfiuration()
        {
            this.HasKey<Guid>(k => k.CarrierStatusId);
        }
    }
}

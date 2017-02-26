using BandD.Serwis.Domain.Dictionaries;
using System;
using System.Data.Entity.ModelConfiguration;

namespace SerwisISS.EntityClassConfiguration
{
    public class SlCarrierStatEntityConfiuration : EntityTypeConfiguration<SlCarrierStat>
    {
        public SlCarrierStatEntityConfiuration()
        {
            this.HasKey<Guid>(k => k.CarrierStatusId);
        }
    }
}
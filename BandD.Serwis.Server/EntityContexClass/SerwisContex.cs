using BandD.Serwis.Class;
using BandD.Serwis.Server.EntityClassConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandD.Serwis.Server.EntityContexClass
{
    public class SerwisContex : DbContext  
    {
        public SerwisContex():
            base("SerwisConnectionString")
        {
            Database.SetInitializer<SerwisContex>(new DropCreateDatabaseAlways<SerwisContex>());
        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<SlStats> SlStat { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LoginEntityConfiguration());
            modelBuilder.Configurations.Add(new SlStatsEntityConfiguration());
        }
    }
}

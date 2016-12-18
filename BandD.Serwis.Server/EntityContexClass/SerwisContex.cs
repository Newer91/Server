using BandD.Serwis.Class;
using BandD.Serwis.Server.EntityClassConfiguration;
using System.Data.Entity;

namespace BandD.Serwis.Server.EntityContexClass
{
    public class ServisContex : DbContext
    {
        public ServisContex(string connectionStringName)
            : base(connectionStringName)
        {
            Database.SetInitializer<ServisContex>(new DropCreateDatabaseAlways<ServisContex>());
        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<SlStat> SlStats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LoginEntityConfiguration());
            modelBuilder.Configurations.Add(new SlStatsEntityConfiguration());
        }
    }
}

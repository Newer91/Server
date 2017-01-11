using BandD.Serwis.Domain;
using BandD.Serwis.Server.EntityClassConfiguration;
using System.Data.Entity;

namespace BandD.Serwis.Server.EntityContexClass
{
    public class ServisContex : DbContext
    {
        public ServisContex(string connectionStringName)
            : base(connectionStringName)
        {
            //Database.SetInitializer<ServisContex>(new DropCreateDatabaseAlways<ServisContex>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SlOrderStat> SlOrdersStats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new SlOrdersStatsEntityConfiguration());
        }
    }
}

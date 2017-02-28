using BandD.Serwis.Domain;
using BandD.Serwis.Domain.Dictionaries;
using SerwisISS.EntityClassConfiguration;
using System.Data.Entity;

namespace BandD.Serwis.SerwisISS.EntityContexClass
{
    public class ServisContex : DbContext
    {
        public ServisContex() : base("BanddServer")
        {
            //Database.SetInitializer<ServisContex>(new DropCreateDatabaseAlways<ServisContex>());
            //base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SlOrderStat> SlOrdersStats { get; set; }

        public DbSet<SlCarrierStat> SlCarrierStats { get; set; }
        public DbSet<SlRole> SlRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new SlOrdersStatsEntityConfiguration());
            modelBuilder.Configurations.Add(new SlRoleEntityConfiguration());
            modelBuilder.Configurations.Add(new SlCarrierStatEntityConfiuration());
        }
    }
}
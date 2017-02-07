using BandD.Serwis.Domain;
using BandD.Serwis.Domain.Dictionaries;
using BandD.Serwis.Server.EntityClassConfiguration;
using System.Data.Entity;

namespace BandD.Serwis.Server.EntityContexClass
{
    public class ServisContex : DbContext
    {
        //public ServisContex(string connectionStringName)
        //    : base(connectionStringName)
        //{
        //    //Database.SetInitializer<ServisContex>(new DropCreateDatabaseAlways<ServisContex>());
        //    ////base.Configuration.ProxyCreationEnabled = false;
        //}

        public ServisContex() : base("BanddServer")
        {
           base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SlOrderStat> SlOrdersStats { get; set; }
        public DbSet<SlRole> SlRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new SlOrdersStatsEntityConfiguration());
            modelBuilder.Configurations.Add(new SlRoleEntityConfiguration());
        }
    }
}

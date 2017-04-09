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
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SlOrderStat> SlOrdersStats { get; set; }
        public DbSet<SlCarrierStat> SlCarrierStats { get; set; }
        public DbSet<SlRole> SlRoles { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new SlOrdersStatsEntityConfiguration());
            modelBuilder.Configurations.Add(new SlRoleEntityConfiguration());
            modelBuilder.Configurations.Add(new SlCarrierStatEntityConfiuration());
            modelBuilder.Configurations.Add(new AddressEntityConfiguration());
            modelBuilder.Configurations.Add(new ClientEntityConfiguration());
        }
    }
}
using BandD.Serwis.Class;
using BandD.Serwis.Server.EntityContexClass;
using BandD.Serwis.Tools.ServerTools;
using System;

namespace BandD.Serwis.Server
{
    public class InitClass
    {
        private ServisContex ctx;

        public InitClass(ServisContex ctx)
        {
            this.ctx = ctx;
            InitLoginTable();
            InitOrderDictionaryTable();
        }

        private void InitOrderDictionaryTable()
        {
            var stat = new SlOrderStat() { StatsId = Guid.NewGuid(), Name = "W trakcie realizacji", Active = true, Description = "Zlecenie w trakcie realizacji" };
            var stat2 = new SlOrderStat() { StatsId = Guid.NewGuid(), Name = "Anulowane" ,Active =true,Description="Zlecenie anulowane przez klienta"};
            ctx.SlOrdersStats.Add(stat);
            ctx.SlOrdersStats.Add(stat2);
            ctx.SaveChanges();
        }

        private void InitLoginTable()
        {
            var login = new Login() { LoginId = Guid.NewGuid(), Active = true, UserName = "blisowski", Role = "Admin", Password = SecureTools.CalculateMD5Hash("dedra") };
            var login2 = new Login() { LoginId = Guid.NewGuid(), Active = true, UserName = "asieradzan", Role = "Admin", Password = SecureTools.CalculateMD5Hash("12345") };
            ctx.Logins.Add(login);
            ctx.Logins.Add(login2);
            ctx.SaveChanges();
        }
    }
}

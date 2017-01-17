using BandD.Serwis.Domain;
using BandD.Serwis.Domain.Dictionaries;
using BandD.Serwis.Server.EntityContexClass;
using BandD.Serwis.Tools.ServerTools;
using System;
using System.Linq;

namespace BandD.Serwis.Server
{
    public class InitClass
    {
        private string conectionString = ServerExtension.GetConnectionString(Environment.MachineName);

        public InitClass()
        {
            if(!ChechDefoultRecord())
            {
                InitLoginTable();
                InitOrderDictionaryTable();                
            }
        }

        private bool ChechDefoultRecord()
        {
            bool result = false;
            using (var ctx = new ServisContex(conectionString))
            {
                var adminInBase = ctx.Users
                    .Where(l => l.UserName == "Admin")
                    .FirstOrDefault();
                if (adminInBase != null)
                    return true;
            }
            return result;
        }


        private void InitOrderDictionaryTable()
        {
            using (var ctx = new ServisContex(conectionString))
            {
                var stat = new SlOrderStat() { OrderStatusId = Guid.NewGuid(), Name = "W trakcie realizacji", Active = true, Description = "Zlecenie w trakcie realizacji" };
                var stat2 = new SlOrderStat() { OrderStatusId = Guid.NewGuid(), Name = "Anulowane", Active = true, Description = "Zlecenie anulowane przez klienta" };
                ctx.SlOrdersStats.Add(stat);
                ctx.SlOrdersStats.Add(stat2);
                ctx.SaveChanges();
            }
        }

        private void InitLoginTable()
        {
            using (var ctx = new ServisContex(conectionString))
            {
                var rola1 = new SlRole() { Name = "Admin", RoleId = Guid.NewGuid() };

                ctx.SlRoles.Add(rola1);

                var user = new User() { UserId = Guid.NewGuid(), Active = true, UserName = "blisowski", SlRole = rola1, Password = SecureTools.CalculateMD5Hash("dedra") };
                var user2 = new User() { UserId = Guid.NewGuid(), Active = true, UserName = "asieradzan",SlRole = rola1, Password = SecureTools.CalculateMD5Hash("12345") };
                var user3 = new User() { UserId = Guid.NewGuid(), Active = true, UserName = "Admin", SlRole = rola1, Password = SecureTools.CalculateMD5Hash("admin") };

                ctx.Users.Add(user);
                ctx.Users.Add(user2);
                ctx.Users.Add(user3);

                ctx.SaveChanges();
            }
        }
    }
}

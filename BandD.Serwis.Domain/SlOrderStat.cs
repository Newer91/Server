using System;

namespace BandD.Serwis.Domain
{
    public class SlOrderStat
    {
        public Guid OrderStatusId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
    }
    public class UserStatus
    {
        public Guid UserStatusId { get; set; }
        public string Name { get; set; }
        public string TypeOfUser { get; set; }
        public bool Status { get; set; }
    }
}


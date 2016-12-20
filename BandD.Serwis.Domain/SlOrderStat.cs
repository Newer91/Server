using System;

namespace BandD.Serwis.Class
{
    public class SlOrderStat
    {
        public Guid OrderStatusId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
    }
}

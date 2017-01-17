using System;

namespace BandD.Serwis.Domain
{
    [Serializable]
    public class SlOrderStat
    {
        public SlOrderStat() { }

        public Guid OrderStatusId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
    }
}
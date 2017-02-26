using System;

namespace BandD.Serwis.ClassViewModel.Dictionaries
{
    [Serializable]
    public class SlOrderStatView
    {
        public Guid OrderStatusId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
    }
}

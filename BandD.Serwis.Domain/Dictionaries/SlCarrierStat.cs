using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandD.Serwis.Domain.Dictionaries
{
    [Serializable]
    public class SlCarrierStat
    {
        public SlCarrierStat() {  }
            public Guid CarrierStatusId { get; set; }
            public string CarrierName { get; set; }
            public bool CarrierStatus { get; set; }
            public string CarrierLink { get; set; }
      
    }
}

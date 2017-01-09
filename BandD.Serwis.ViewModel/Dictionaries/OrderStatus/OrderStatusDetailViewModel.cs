using BandD.Serwis.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandD.Serwis.ViewModel.Dictionaries.OrderStatus
{
    public class OrderStatusDetailViewModel:BaseClass
    {
        private SlOrderStat stats;

        public SlOrderStat Stats
        {
            get { return stats; }
            set { stats = value;OnPropertyChanged(); }
        }
    }
}

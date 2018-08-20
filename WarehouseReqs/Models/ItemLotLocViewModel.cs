using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseReqs.Models
{
    public class ItemLotLocViewModel
    { 
        public string Item { get; set; }
        public string Lot { get; set; }
        public string Location { get; set; }
        public decimal? QtyOnHand { get; set; }
    }
}

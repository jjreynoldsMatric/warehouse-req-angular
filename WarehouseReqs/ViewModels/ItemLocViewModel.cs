using System;
using System.Collections.Generic;

namespace WarehouseReqs.ViewModels
{
    public class ItemLocViewModel
    {
        public string Item { get; set; }
        public short Rank { get; set; }
        public string Location { get; set; }
        public decimal? QtyOnHand { get; set; }
    }
}
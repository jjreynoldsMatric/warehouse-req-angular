using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseReqs.Models
{
    public partial class InsertItem
    {
        public decimal Quantity { get; set; }
        public string Job { get; set; }
        public string OperNum { get; set; }
        public string Item { get; set; }
        public string Loc { get; set; }
        public string UM { get; set; }
        public string Lot { get; set; }
        public string Reasoncode { get; set; }
        public string ProcessedBy { get; set; }
    }
}

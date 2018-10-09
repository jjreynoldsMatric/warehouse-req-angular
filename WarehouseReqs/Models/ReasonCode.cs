using System;
using System.Collections.Generic;

namespace WarehouseReqs.Models
{
    public partial class ReasonCode
    {
        public string Code { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Description { get; set; }
        public string WhseAction { get; set; }
    }
}

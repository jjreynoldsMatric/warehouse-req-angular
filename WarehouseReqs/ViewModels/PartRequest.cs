using System;
using System.Collections.Generic;

namespace WarehouseReqs.ViewModels
{
    public class PartRequest
    {
        public int ItemReqId { get; set; }
        public string ProcessedBy { get; set; }
        public decimal Quantity { get; set; }
        public string Location { get; set; }
        public string Lot { get; set; }
    }
}
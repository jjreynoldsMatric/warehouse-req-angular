using System;
using System.Collections.Generic;

namespace WarehouseReqs.Models
{
    public partial class RequisitionItem
    {
        public RequisitionItem()
        {
            RequisitionItemActions = new HashSet<RequisitionItemActions>();
        }

        public int Id { get; set; }
        public int RequisitionId { get; set; }
        public string Item { get; set; }
        public string ItemDescription { get; set; }
        public double? Quantity { get; set; }
        public string Lot { get; set; }
        public string ReasonCode { get; set; }
        public string Operation { get; set; }
        public double QuantityFilled { get; set; }
        public bool? Filled { get; set; }
        public ICollection<RequisitionItemActions> RequisitionItemActions { get; set; }
    }
}

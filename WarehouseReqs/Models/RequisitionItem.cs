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
        public bool? Filled { get; set; }
        public string Item { get; set; }
        public string ItemDescription { get; set; }
        public string Lot { get; set; }
        public string Operation { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityFilled { get; set; }
        public string ReasonCode { get; set; }
        public int RequisitionId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? Unitcost { get; set; }
        public byte? Backflush { get; set; }
        public byte? LotTracked { get; set; }
        public byte? SerialTracked { get; set; }
        public decimal? Totalcost { get; set; }
        public byte? CycleCounted { get; set; }

        public ICollection<RequisitionItemActions> RequisitionItemActions { get; set; }
    }
}

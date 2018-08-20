using System;
using System.Collections.Generic;

namespace WarehouseReqs.Models
{
    public partial class LotLoc
    {
        public string Whse { get; set; }
        public string Item { get; set; }
        public string Loc { get; set; }
        public string Lot { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? QtyOnHand { get; set; }
        public decimal? QtyRsvd { get; set; }
        public decimal? MatlCost { get; set; }
        public decimal? LbrCost { get; set; }
        public decimal? FovhdCost { get; set; }
        public decimal? VovhdCost { get; set; }
        public decimal? OutCost { get; set; }
        public byte NoteExistsFlag { get; set; }
        public DateTime RecordDate { get; set; }
        public Guid RowPointer { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public byte InWorkflow { get; set; }
        public decimal? LastCountQtyOnHand { get; set; }
        public decimal? LastCountQtyRsvd { get; set; }
        public decimal? QtyContained { get; set; }
        public decimal AssignedToBePickedQty { get; set; }
    }
}

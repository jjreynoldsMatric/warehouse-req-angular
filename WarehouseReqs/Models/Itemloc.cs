using System;
using System.Collections.Generic;

namespace WarehouseReqs.Models
{
    public partial class Itemloc
    {
        public string Whse { get; set; }
        public string Item { get; set; }
        public short Rank { get; set; }
        public string Loc { get; set; }
        public decimal? QtyOnHand { get; set; }
        public byte? MrbFlag { get; set; }
        public string LocType { get; set; }
        public string InvAcct { get; set; }
        public decimal? UnitCost { get; set; }
        public byte? PermFlag { get; set; }
        public decimal? QtyRsvd { get; set; }
        public decimal? MatlCost { get; set; }
        public decimal? LbrCost { get; set; }
        public decimal? FovhdCost { get; set; }
        public decimal? VovhdCost { get; set; }
        public decimal? OutCost { get; set; }
        public string LbrAcct { get; set; }
        public string FovhdAcct { get; set; }
        public string VovhdAcct { get; set; }
        public string OutAcct { get; set; }
        public string Wc { get; set; }
        public string InvAcctUnit1 { get; set; }
        public string InvAcctUnit2 { get; set; }
        public string InvAcctUnit3 { get; set; }
        public string InvAcctUnit4 { get; set; }
        public string LbrAcctUnit1 { get; set; }
        public string LbrAcctUnit2 { get; set; }
        public string LbrAcctUnit3 { get; set; }
        public string LbrAcctUnit4 { get; set; }
        public string FovhdAcctUnit1 { get; set; }
        public string FovhdAcctUnit2 { get; set; }
        public string FovhdAcctUnit3 { get; set; }
        public string FovhdAcctUnit4 { get; set; }
        public string VovhdAcctUnit1 { get; set; }
        public string VovhdAcctUnit2 { get; set; }
        public string VovhdAcctUnit3 { get; set; }
        public string VovhdAcctUnit4 { get; set; }
        public string OutAcctUnit1 { get; set; }
        public string OutAcctUnit2 { get; set; }
        public string OutAcctUnit3 { get; set; }
        public string OutAcctUnit4 { get; set; }
        public byte NoteExistsFlag { get; set; }
        public DateTime RecordDate { get; set; }
        public Guid RowPointer { get; set; }
        public short? NewRank { get; set; }
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

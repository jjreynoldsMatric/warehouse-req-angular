using System;
using System.Collections.Generic;

namespace WarehouseReqs.Models
{
    public partial class Cycle
    {
        public string Whse { get; set; }
        public string Item { get; set; }
        public string Loc { get; set; }
        public string Lot { get; set; }
        public decimal? CutOffQty { get; set; }
        public decimal? CountQty { get; set; }
        public string Stat { get; set; }
        public DateTime? CycleDate { get; set; }
        public string SerNum { get; set; }
        public byte NoteExistsFlag { get; set; }
        public DateTime RecordDate { get; set; }
        public Guid RowPointer { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public byte InWorkflow { get; set; }
        public string Message { get; set; }
        public string ImportDocId { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WarehouseReqs.Models
{
    public partial class Dcitem
    {
        public int TransNum { get; set; }
        public string Termid { get; set; }
        public DateTime? TransDate { get; set; }
        public string EmpNum { get; set; }
        public string TransType { get; set; }
        public string Item { get; set; }
        public string Whse { get; set; }
        public string Loc { get; set; }
        public string Lot { get; set; }
        public string Stat { get; set; }
        public byte? Override { get; set; }
        public decimal? CountQty { get; set; }
        public decimal? Cost { get; set; }
        public string ReasonCode { get; set; }
        public string Um { get; set; }
        public decimal? RepQty { get; set; }
        public byte NoteExistsFlag { get; set; }
        public DateTime RecordDate { get; set; }
        public Guid RowPointer { get; set; }
        public string ErrorMessage { get; set; }
        public byte CanOverride { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string RemoteSiteLotProcess { get; set; }
        public byte CreateLoc { get; set; }
        public byte InWorkflow { get; set; }
        public string DocumentNum { get; set; }
    }
}

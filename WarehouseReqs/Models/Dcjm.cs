using System;
using System.Collections.Generic;

namespace WarehouseReqs.Models
{
    public partial class Dcjm
    {
        public int TransNum { get; set; }
        public string Termid { get; set; }
        public DateTime? TransDate { get; set; }
        public string EmpNum { get; set; }
        public string TransType { get; set; }
        public string Job { get; set; }
        public short? Suffix { get; set; }
        public int? OperNum { get; set; }
        public string Item { get; set; }
        public string Whse { get; set; }
        public string Loc { get; set; }
        public string Lot { get; set; }
        public decimal? Qty { get; set; }
        public string Stat { get; set; }
        public byte? Override { get; set; }
        public decimal? Cost { get; set; }
        public string Acct { get; set; }
        public string Um { get; set; }
        public string AcctUnit1 { get; set; }
        public string AcctUnit2 { get; set; }
        public string AcctUnit3 { get; set; }
        public string AcctUnit4 { get; set; }
        public byte? CoProductMix { get; set; }
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
        public string JobLot { get; set; }
        public string JobSerNum { get; set; }
    }
}

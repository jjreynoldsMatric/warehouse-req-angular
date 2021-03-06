﻿using System;
using System.Collections.Generic;

namespace WarehouseReqs.Models
{
    public partial class Wc
    {
        public string Wc1 { get; set; }
        public string Description { get; set; }
        public byte? Outside { get; set; }
        public decimal SetupRate { get; set; }
        public decimal? Efficiency { get; set; }
        public string Dept { get; set; }
        public string Alternate { get; set; }
        public decimal? QueueHrsA { get; set; }
        public decimal? QueueQtyT { get; set; }
        public decimal? SetupRateA { get; set; }
        public decimal? SetupHrsT { get; set; }
        public string Calendar { get; set; }
        public string Charfld1 { get; set; }
        public string Charfld2 { get; set; }
        public string Charfld3 { get; set; }
        public decimal? Decifld1 { get; set; }
        public decimal? Decifld2 { get; set; }
        public decimal? Decifld3 { get; set; }
        public byte? Logifld { get; set; }
        public DateTime? Datefld { get; set; }
        public decimal? QueueTicks { get; set; }
        public string BflushType { get; set; }
        public decimal? RunHrsTMch { get; set; }
        public decimal? FovhdRateMch { get; set; }
        public decimal? VovhdRateMch { get; set; }
        public string FmcoAcct { get; set; }
        public string VmcoAcct { get; set; }
        public decimal? RunHrsTLbr { get; set; }
        public decimal RunRateLbr { get; set; }
        public decimal? RunRateALbr { get; set; }
        public string Overhead { get; set; }
        public byte CntrlPoint { get; set; }
        public string WipMatlAcct { get; set; }
        public string WipLbrAcct { get; set; }
        public string WipFovhdAcct { get; set; }
        public string WipVovhdAcct { get; set; }
        public string WipOutAcct { get; set; }
        public string MuvAcct { get; set; }
        public string LrvAcct { get; set; }
        public string LuvAcct { get; set; }
        public string FmouvAcct { get; set; }
        public string VmouvAcct { get; set; }
        public string FlouvAcct { get; set; }
        public string VlouvAcct { get; set; }
        public string FmcouvAcct { get; set; }
        public string VmcouvAcct { get; set; }
        public decimal? WipMatlTotal { get; set; }
        public decimal? WipLbrTotal { get; set; }
        public decimal? WipFovhdTotal { get; set; }
        public decimal? WipVovhdTotal { get; set; }
        public decimal? WipOutTotal { get; set; }
        public string FmcoAcctUnit1 { get; set; }
        public string FmcoAcctUnit2 { get; set; }
        public string FmcoAcctUnit3 { get; set; }
        public string FmcoAcctUnit4 { get; set; }
        public string VmcoAcctUnit1 { get; set; }
        public string VmcoAcctUnit2 { get; set; }
        public string VmcoAcctUnit3 { get; set; }
        public string VmcoAcctUnit4 { get; set; }
        public string WipMatlAcctUnit1 { get; set; }
        public string WipMatlAcctUnit2 { get; set; }
        public string WipMatlAcctUnit3 { get; set; }
        public string WipMatlAcctUnit4 { get; set; }
        public string WipLbrAcctUnit1 { get; set; }
        public string WipLbrAcctUnit2 { get; set; }
        public string WipLbrAcctUnit3 { get; set; }
        public string WipLbrAcctUnit4 { get; set; }
        public string WipFovhdAcctUnit1 { get; set; }
        public string WipFovhdAcctUnit2 { get; set; }
        public string WipFovhdAcctUnit3 { get; set; }
        public string WipFovhdAcctUnit4 { get; set; }
        public string WipVovhdAcctUnit1 { get; set; }
        public string WipVovhdAcctUnit2 { get; set; }
        public string WipVovhdAcctUnit3 { get; set; }
        public string WipVovhdAcctUnit4 { get; set; }
        public string WipOutAcctUnit1 { get; set; }
        public string WipOutAcctUnit2 { get; set; }
        public string WipOutAcctUnit3 { get; set; }
        public string WipOutAcctUnit4 { get; set; }
        public string MuvAcctUnit1 { get; set; }
        public string MuvAcctUnit2 { get; set; }
        public string MuvAcctUnit3 { get; set; }
        public string MuvAcctUnit4 { get; set; }
        public string LrvAcctUnit1 { get; set; }
        public string LrvAcctUnit2 { get; set; }
        public string LrvAcctUnit3 { get; set; }
        public string LrvAcctUnit4 { get; set; }
        public string LuvAcctUnit1 { get; set; }
        public string LuvAcctUnit2 { get; set; }
        public string LuvAcctUnit3 { get; set; }
        public string LuvAcctUnit4 { get; set; }
        public string FmouvAcctUnit1 { get; set; }
        public string FmouvAcctUnit2 { get; set; }
        public string FmouvAcctUnit3 { get; set; }
        public string FmouvAcctUnit4 { get; set; }
        public string VmouvAcctUnit1 { get; set; }
        public string VmouvAcctUnit2 { get; set; }
        public string VmouvAcctUnit3 { get; set; }
        public string VmouvAcctUnit4 { get; set; }
        public string FlouvAcctUnit1 { get; set; }
        public string FlouvAcctUnit2 { get; set; }
        public string FlouvAcctUnit3 { get; set; }
        public string FlouvAcctUnit4 { get; set; }
        public string VlouvAcctUnit1 { get; set; }
        public string VlouvAcctUnit2 { get; set; }
        public string VlouvAcctUnit3 { get; set; }
        public string VlouvAcctUnit4 { get; set; }
        public string FmcouvAcctUnit1 { get; set; }
        public string FmcouvAcctUnit2 { get; set; }
        public string FmcouvAcctUnit3 { get; set; }
        public string FmcouvAcctUnit4 { get; set; }
        public string VmcouvAcctUnit1 { get; set; }
        public string VmcouvAcctUnit2 { get; set; }
        public string VmcouvAcctUnit3 { get; set; }
        public string VmcouvAcctUnit4 { get; set; }
        public string CostCode { get; set; }
        public decimal? QueueHrs { get; set; }
        public byte NoteExistsFlag { get; set; }
        public DateTime RecordDate { get; set; }
        public Guid RowPointer { get; set; }
        public string DispatchListsEmail { get; set; }
        public string SchedDrv { get; set; }
        public decimal? FinishHrs { get; set; }
        public string Setuprgid { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public byte InWorkflow { get; set; }
    }
}

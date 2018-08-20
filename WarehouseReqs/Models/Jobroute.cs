using System;
using System.Collections.Generic;

namespace WarehouseReqs.Models
{
    public partial class Jobroute
    {
        public string Job { get; set; }
        public short Suffix { get; set; }
        public int OperNum { get; set; }
        public string Wc { get; set; }
        public decimal? SetupHrsT { get; set; }
        public decimal? SetupCostT { get; set; }
        public byte? Complete { get; set; }
        public decimal? SetupHrsV { get; set; }
        public decimal? WipAmt { get; set; }
        public decimal? QtyScrapped { get; set; }
        public decimal? QtyReceived { get; set; }
        public decimal? QtyMoved { get; set; }
        public decimal? QtyComplete { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ObsDate { get; set; }
        public string BflushType { get; set; }
        public string RunBasisLbr { get; set; }
        public string RunBasisMch { get; set; }
        public decimal? FixovhdTLbr { get; set; }
        public decimal? FixovhdTMch { get; set; }
        public decimal? VarovhdTLbr { get; set; }
        public decimal? VarovhdTMch { get; set; }
        public decimal? RunHrsTLbr { get; set; }
        public decimal? RunHrsTMch { get; set; }
        public decimal? RunHrsVLbr { get; set; }
        public decimal? RunHrsVMch { get; set; }
        public decimal? RunCostTLbr { get; set; }
        public byte? CntrlPoint { get; set; }
        public decimal SetupRate { get; set; }
        public decimal? Efficiency { get; set; }
        public decimal? FovhdRateMch { get; set; }
        public decimal? VovhdRateMch { get; set; }
        public decimal RunRateLbr { get; set; }
        public decimal? VarovhdRate { get; set; }
        public decimal? FixovhdRate { get; set; }
        public decimal? WipMatlAmt { get; set; }
        public decimal? WipLbrAmt { get; set; }
        public decimal? WipFovhdAmt { get; set; }
        public decimal? WipVovhdAmt { get; set; }
        public decimal? WipOutAmt { get; set; }
        public byte NoteExistsFlag { get; set; }
        public DateTime RecordDate { get; set; }
        public Guid RowPointer { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public byte InWorkflow { get; set; }
        public decimal Yield { get; set; }

        public Job JobNavigation { get; set; }
    }
}

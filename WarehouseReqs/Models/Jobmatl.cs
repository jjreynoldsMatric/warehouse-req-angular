using System;
using System.Collections.Generic;

namespace WarehouseReqs.Models
{
    public partial class Jobmatl
    {
        public string Job { get; set; }
        public short Suffix { get; set; }
        public int OperNum { get; set; }
        public short Sequence { get; set; }
        public string MatlType { get; set; }
        public string Item { get; set; }
        public decimal? MatlQty { get; set; }
        public string Units { get; set; }
        public decimal Cost { get; set; }
        public decimal? QtyIssued { get; set; }
        public decimal? ACost { get; set; }
        public string RefType { get; set; }
        public string RefNum { get; set; }
        public short? RefLineSuf { get; set; }
        public short? RefRelease { get; set; }
        public decimal? PoUnitCost { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ObsDate { get; set; }
        public decimal? ScrapFact { get; set; }
        public decimal? QtyVar { get; set; }
        public decimal? FixovhdT { get; set; }
        public decimal? VarovhdT { get; set; }
        public string Feature { get; set; }
        public decimal? Probable { get; set; }
        public string OptCode { get; set; }
        public decimal? IncPrice { get; set; }
        public string Description { get; set; }
        public DateTime? PickDate { get; set; }
        public short? BomSeq { get; set; }
        public decimal? MatlQtyConv { get; set; }
        public string Um { get; set; }
        public decimal? IncPriceConv { get; set; }
        public decimal? CostConv { get; set; }
        public byte? Backflush { get; set; }
        public string BflushLoc { get; set; }
        public decimal? Fmatlovhd { get; set; }
        public decimal? Vmatlovhd { get; set; }
        public decimal MatlCost { get; set; }
        public decimal LbrCost { get; set; }
        public decimal FovhdCost { get; set; }
        public decimal VovhdCost { get; set; }
        public decimal OutCost { get; set; }
        public decimal? AMatlCost { get; set; }
        public decimal? ALbrCost { get; set; }
        public decimal? AFovhdCost { get; set; }
        public decimal? AVovhdCost { get; set; }
        public decimal? AOutCost { get; set; }
        public decimal? MatlCostConv { get; set; }
        public decimal? LbrCostConv { get; set; }
        public decimal? FovhdCostConv { get; set; }
        public decimal? VovhdCostConv { get; set; }
        public decimal? OutCostConv { get; set; }
        public byte NoteExistsFlag { get; set; }
        public DateTime RecordDate { get; set; }
        public Guid RowPointer { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public byte InWorkflow { get; set; }
        public decimal? UfAmsPlan { get; set; }
        public short AltGroup { get; set; }
        public short AltGroupRank { get; set; }
        public byte? PlannedAlternate { get; set; }
        public short? NewSequence { get; set; }
        public string UfMaterialUsageVarianceReason { get; set; }
        public string ManufacturerId { get; set; }
        public string ManufacturerItem { get; set; }
    }
}

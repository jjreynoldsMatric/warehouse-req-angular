﻿using System;
using System.Collections.Generic;

namespace WarehouseReqs.Models
{
    public partial class Item
    {
        public string Item1 { get; set; }
        public string Description { get; set; }
        public decimal? QtyAllocjob { get; set; }
        public string Um { get; set; }
        public short LeadTime { get; set; }
        public decimal? LotSize { get; set; }
        public decimal? QtyUsedYtd { get; set; }
        public decimal? QtyMfgYtd { get; set; }
        public string AbcCode { get; set; }
        public string DrawingNbr { get; set; }
        public string ProductCode { get; set; }
        public string PmtCode { get; set; }
        public string CostMethod { get; set; }
        public decimal? LstLotSize { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? LstUCost { get; set; }
        public decimal? AvgUCost { get; set; }
        public string Job { get; set; }
        public short? Suffix { get; set; }
        public byte? Stocked { get; set; }
        public string MatlType { get; set; }
        public string FamilyCode { get; set; }
        public byte? LowLevel { get; set; }
        public DateTime? LastInv { get; set; }
        public short? DaysSupply { get; set; }
        public decimal? OrderMin { get; set; }
        public decimal? OrderMult { get; set; }
        public string PlanCode { get; set; }
        public byte? MpsFlag { get; set; }
        public byte? AcceptReq { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string Revision { get; set; }
        public byte? PhantomFlag { get; set; }
        public byte? PlanFlag { get; set; }
        public short PaperTime { get; set; }
        public short DockTime { get; set; }
        public decimal? AsmSetup { get; set; }
        public decimal? AsmRun { get; set; }
        public decimal? AsmMatl { get; set; }
        public decimal? AsmTool { get; set; }
        public decimal? AsmFixture { get; set; }
        public decimal? AsmOther { get; set; }
        public decimal? AsmFixed { get; set; }
        public decimal? AsmVar { get; set; }
        public decimal? AsmOutside { get; set; }
        public decimal? CompSetup { get; set; }
        public decimal? CompRun { get; set; }
        public decimal? CompMatl { get; set; }
        public decimal? CompTool { get; set; }
        public decimal? CompFixture { get; set; }
        public decimal? CompOther { get; set; }
        public decimal? CompFixed { get; set; }
        public decimal? CompVar { get; set; }
        public decimal? CompOutside { get; set; }
        public decimal? SubMatl { get; set; }
        public decimal? ShrinkFact { get; set; }
        public string AltItem { get; set; }
        public decimal? UnitWeight { get; set; }
        public string WeightUnits { get; set; }
        public string Charfld4 { get; set; }
        public decimal? CurUCost { get; set; }
        public string FeatType { get; set; }
        public decimal? VarLead { get; set; }
        public string FeatStr { get; set; }
        public short? NextConfig { get; set; }
        public string FeatTempl { get; set; }
        public byte? Backflush { get; set; }
        public string Charfld1 { get; set; }
        public string Charfld2 { get; set; }
        public string Charfld3 { get; set; }
        public decimal? Decifld1 { get; set; }
        public decimal? Decifld2 { get; set; }
        public decimal? Decifld3 { get; set; }
        public byte? Logifld { get; set; }
        public DateTime? Datefld { get; set; }
        public byte? TrackEcn { get; set; }
        public decimal? UWsPrice { get; set; }
        public string CommCode { get; set; }
        public string Origin { get; set; }
        public decimal? UnitMatCost { get; set; }
        public decimal? UnitDutyCost { get; set; }
        public decimal? UnitFreightCost { get; set; }
        public decimal? UnitBrokerageCost { get; set; }
        public decimal? CurMatCost { get; set; }
        public decimal? CurDutyCost { get; set; }
        public decimal? CurFreightCost { get; set; }
        public decimal? CurBrokerageCost { get; set; }
        public string TaxCode1 { get; set; }
        public string TaxCode2 { get; set; }
        public string BflushLoc { get; set; }
        public byte? Reservable { get; set; }
        public short? ShelfLife { get; set; }
        public string LotPrefix { get; set; }
        public string SerialPrefix { get; set; }
        public byte? SerialLength { get; set; }
        public string IssueBy { get; set; }
        public byte? SerialTracked { get; set; }
        public byte? LotTracked { get; set; }
        public string CostType { get; set; }
        public decimal? MatlCost { get; set; }
        public decimal? LbrCost { get; set; }
        public decimal? FovhdCost { get; set; }
        public decimal? VovhdCost { get; set; }
        public decimal? OutCost { get; set; }
        public decimal? CurMatlCost { get; set; }
        public decimal? CurLbrCost { get; set; }
        public decimal? CurFovhdCost { get; set; }
        public decimal? CurVovhdCost { get; set; }
        public decimal? CurOutCost { get; set; }
        public decimal? AvgMatlCost { get; set; }
        public decimal? AvgLbrCost { get; set; }
        public decimal? AvgFovhdCost { get; set; }
        public decimal? AvgVovhdCost { get; set; }
        public decimal? AvgOutCost { get; set; }
        public string ProdType { get; set; }
        public decimal? RatePerDay { get; set; }
        public short? MpsPlanFence { get; set; }
        public byte? PassReq { get; set; }
        public byte? LotGenExp { get; set; }
        public string SupplySite { get; set; }
        public string ProdMix { get; set; }
        public string Stat { get; set; }
        public string StatusChgUserCode { get; set; }
        public DateTime? ChgDate { get; set; }
        public string ReasonCode { get; set; }
        public string SupplyWhse { get; set; }
        public short? DuePeriod { get; set; }
        public decimal? OrderMax { get; set; }
        public byte? MrpPart { get; set; }
        public byte? InfinitePart { get; set; }
        public byte NoteExistsFlag { get; set; }
        public DateTime RecordDate { get; set; }
        public Guid RowPointer { get; set; }
        public decimal? SupplyToleranceHrs { get; set; }
        public short ExpLeadTime { get; set; }
        public decimal? VarExpLead { get; set; }
        public string Buyer { get; set; }
        public byte OrderConfigurable { get; set; }
        public byte JobConfigurable { get; set; }
        public string CfgModel { get; set; }
        public string CoPostConfig { get; set; }
        public string JobPostConfig { get; set; }
        public string AutoJob { get; set; }
        public string AutoPost { get; set; }
        public string Setupgroup { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public byte InWorkflow { get; set; }
        public byte? MfgSupplySwitchingActive { get; set; }
        public short? TimeFenceRule { get; set; }
        public double? TimeFenceValue { get; set; }
        public DateTime? EarliestPlannedPoReceipt { get; set; }
        public string UfPlc { get; set; }
        public string UfProductType { get; set; }
        public string UfShortDescription { get; set; }
        public string UfTeam { get; set; }
        public int? UfEau1 { get; set; }
        public int? UfEau2 { get; set; }
        public int? UfEau3 { get; set; }
        public int? UfEaucurrent { get; set; }
        public DateTime? UfLotSizeDate { get; set; }
        public string UfOrigPlanCode { get; set; }
        public string UfProjectCode { get; set; }
        public string UfStdComments { get; set; }
        public byte? UfStdFlag { get; set; }
        public string UfStdMethod { get; set; }
        public string UfStdPotext { get; set; }
        public string UfSegment { get; set; }
        public string UfMinMethod { get; set; }
        public decimal? UfAmsCost { get; set; }
        public int? Uf2Bin { get; set; }
        public int? UfFgbinSize { get; set; }
        public int? UfPullRate { get; set; }
        public int? UfRmbinSize { get; set; }
        public int? UfBinSs { get; set; }
        public string UfProjSetDate { get; set; }
        public string UfProjSetReason { get; set; }
        public string UfDrawNum { get; set; }
        public string UfEcm { get; set; }
        public string UfPreferredPackaging { get; set; }
        public int? UfRegulated { get; set; }
        public byte? UseReorderPoint { get; set; }
        public decimal? ReorderPoint { get; set; }
        public decimal? FixedOrderQty { get; set; }
        public decimal? UnitInsuranceCost { get; set; }
        public decimal? UnitLocFrtCost { get; set; }
        public decimal? CurInsuranceCost { get; set; }
        public decimal? CurLocFrtCost { get; set; }
        public byte TaxFreeMatl { get; set; }
        public short? TaxFreeDays { get; set; }
        public decimal SafetyStockPercent { get; set; }
        public string TariffClassification { get; set; }
        public DateTime? Lowdate { get; set; }
        public string RcptRqmt { get; set; }
        public byte ActiveForDataIntegration { get; set; }
        public byte? IncludeInNetChangePlanning { get; set; }
        public string UfShelfLifeType { get; set; }
        public DateTime? UfLeadtimeQuoteDate { get; set; }
        public short? UfMfgLeadtime { get; set; }
        public string UfCcgplmbomupd { get; set; }
        public string UfCcgplmitemUpd { get; set; }
        public byte? UfCcgplmkeepBomRevHist { get; set; }
        public byte Kit { get; set; }
        public byte PrintKitComponents { get; set; }
        public decimal? RcvdOverPoQtyTolerance { get; set; }
        public decimal? RcvdUnderPoQtyTolerance { get; set; }
        public short? SafetyStockRule { get; set; }
        public byte ShowInDropDownList { get; set; }
        public byte ControlledByExternalIcs { get; set; }
        public decimal? InventoryUclTolerance { get; set; }
        public decimal? InventoryLclTolerance { get; set; }
        public string SeparationAttribute { get; set; }
        public double? BatchReleaseAttribute1 { get; set; }
        public double? BatchReleaseAttribute2 { get; set; }
        public double? BatchReleaseAttribute3 { get; set; }
        public byte[] Picture { get; set; }
        public byte ActiveForCustomerPortal { get; set; }
        public byte Featured { get; set; }
        public byte TopSeller { get; set; }
        public string Overview { get; set; }
        public int? UfPcbpanel { get; set; }
        public int? UfTested { get; set; }
        public string UfCustRev { get; set; }
        public string UfLotSizeSource { get; set; }
        public Guid? UfSnlogId { get; set; }
        public DateTime? UfLastReceipt { get; set; }
        public DateTime? UfLastUsage { get; set; }
        public string UfMountingTech { get; set; }
        public string UfSourceRestriction { get; set; }
        public int? UfEau4 { get; set; }
        public string UfDimensions { get; set; }
        public int? UfEauTtm { get; set; }
        public string UfStdLtMethod { get; set; }
        public string UfBroker { get; set; }
        public byte PreassignLots { get; set; }
        public byte PreassignSerials { get; set; }
        public string AttrGroup { get; set; }
        public string DimensionGroup { get; set; }
        public string LotAttrGroup { get; set; }
        public byte TrackPieces { get; set; }
        public DateTime? BomLastImportDate { get; set; }
        public byte SaveCurrentRevUponBomImport { get; set; }
        public string NaftaPrefCrit { get; set; }
        public byte SubjectToNaftaRvc { get; set; }
        public byte Producer { get; set; }
        public string NaftaCountryOfOrigin { get; set; }
        public byte MustUseFutureRcptsBeforePln { get; set; }
        public byte SubjectToExciseTax { get; set; }
        public decimal? ExciseTaxPercent { get; set; }
        public int? UfFabricationOverride { get; set; }
        public byte? UfItar { get; set; }
        public string UfIpc { get; set; }
        public string UfRoHs { get; set; }

        public Job JobNavigation { get; set; }
    }
}

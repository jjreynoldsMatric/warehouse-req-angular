using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WarehouseReqs.Models
{
    public partial class MatAppContext : DbContext
    {
        public MatAppContext()
        {
        }

        public MatAppContext(DbContextOptions<MatAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dcitem> Dcitem { get; set; }
        public virtual DbSet<Dcjm> Dcjm { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Itemloc> Itemloc { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Jobmatl> Jobmatl { get; set; }
        public virtual DbSet<Jobroute> Jobroute { get; set; }
        public virtual DbSet<LotLoc> LotLoc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=SLDB1;Database=Mat_App;User Id=sa;Password=$yt3LinE;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dcitem>(entity =>
            {
                entity.HasKey(e => new { e.TransNum, e.TransType });

                entity.ToTable("dcitem");

                entity.HasIndex(e => e.EmpNum);

                entity.HasIndex(e => e.Item);

                entity.HasIndex(e => e.Loc);

                entity.HasIndex(e => e.Lot);

                entity.HasIndex(e => e.RowPointer)
                    .HasName("IX_dcitem_RowPointer")
                    .IsUnique();

                entity.HasIndex(e => e.Whse);

                entity.Property(e => e.TransNum)
                    .HasColumnName("trans_num")
                    .HasColumnType("DcTransNumType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.TransType)
                    .HasColumnName("trans_type")
                    .HasColumnType("DcTransTypeType")
                    .HasMaxLength(1);

                entity.Property(e => e.CanOverride)
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CountQty)
                    .HasColumnName("count_qty")
                    .HasColumnType("QtyUnitNoNegType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateLoc)
                    .HasColumnName("create_loc")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.DocumentNum)
                    .HasColumnName("document_num")
                    .HasColumnType("DocumentNumType")
                    .HasMaxLength(12);

                entity.Property(e => e.EmpNum)
                    .HasColumnName("emp_num")
                    .HasColumnType("EmpNumType")
                    .HasMaxLength(7);

                entity.Property(e => e.ErrorMessage)
                    .HasColumnType("InfobarType")
                    .HasMaxLength(2800);

                entity.Property(e => e.InWorkflow)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasColumnType("ItemType")
                    .HasMaxLength(30);

                entity.Property(e => e.Loc)
                    .HasColumnName("loc")
                    .HasColumnType("LocType")
                    .HasMaxLength(15);

                entity.Property(e => e.Lot)
                    .HasColumnName("lot")
                    .HasColumnType("LotType")
                    .HasMaxLength(15);

                entity.Property(e => e.NoteExistsFlag)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Override)
                    .HasColumnName("override")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ReasonCode)
                    .HasColumnName("reason_code")
                    .HasColumnType("ReasonCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.RecordDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RemoteSiteLotProcess)
                    .IsRequired()
                    .HasColumnName("remote_site_lot_process")
                    .HasColumnType("ListExistingCreateBothType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('B')");

                entity.Property(e => e.RepQty)
                    .HasColumnName("rep_qty")
                    .HasColumnType("QtyUnitNoNegType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RowPointer)
                    .HasColumnType("RowPointerType")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("DcStatusType")
                    .HasMaxLength(1);

                entity.Property(e => e.Termid)
                    .HasColumnName("termid")
                    .HasColumnType("DcTermIdType")
                    .HasMaxLength(4);

                entity.Property(e => e.TransDate)
                    .HasColumnName("trans_date")
                    .HasColumnType("DateTimeType");

                entity.Property(e => e.Um)
                    .HasColumnName("u_m")
                    .HasColumnType("UMType")
                    .HasMaxLength(3);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Whse)
                    .HasColumnName("whse")
                    .HasColumnType("WhseType")
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<Dcjm>(entity =>
            {
                entity.HasKey(e => e.TransNum)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("dcjm");

                entity.HasIndex(e => e.EmpNum);

                entity.HasIndex(e => e.Item);

                entity.HasIndex(e => e.Loc);

                entity.HasIndex(e => e.Lot);

                entity.HasIndex(e => e.RowPointer)
                    .HasName("IX_dcjm_RowPointer")
                    .IsUnique();

                entity.HasIndex(e => e.Whse);

                entity.Property(e => e.TransNum)
                    .HasColumnName("trans_num")
                    .HasColumnType("DcTransNumType");

                entity.Property(e => e.Acct)
                    .HasColumnName("acct")
                    .HasColumnType("AcctType")
                    .HasMaxLength(12);

                entity.Property(e => e.AcctUnit1)
                    .HasColumnName("acct_unit1")
                    .HasColumnType("UnitCode1Type")
                    .HasMaxLength(4);

                entity.Property(e => e.AcctUnit2)
                    .HasColumnName("acct_unit2")
                    .HasColumnType("UnitCode2Type")
                    .HasMaxLength(4);

                entity.Property(e => e.AcctUnit3)
                    .HasColumnName("acct_unit3")
                    .HasColumnType("UnitCode3Type")
                    .HasMaxLength(4);

                entity.Property(e => e.AcctUnit4)
                    .HasColumnName("acct_unit4")
                    .HasColumnType("UnitCode4Type")
                    .HasMaxLength(4);

                entity.Property(e => e.CanOverride)
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CoProductMix)
                    .HasColumnName("co_product_mix")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateLoc)
                    .HasColumnName("create_loc")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.DocumentNum)
                    .HasColumnName("document_num")
                    .HasColumnType("DocumentNumType")
                    .HasMaxLength(12);

                entity.Property(e => e.EmpNum)
                    .HasColumnName("emp_num")
                    .HasColumnType("EmpNumType")
                    .HasMaxLength(7);

                entity.Property(e => e.ErrorMessage)
                    .HasColumnType("InfobarType")
                    .HasMaxLength(2800);

                entity.Property(e => e.InWorkflow)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasColumnType("ItemType")
                    .HasMaxLength(30);

                entity.Property(e => e.Job)
                    .HasColumnName("job")
                    .HasColumnType("JobType")
                    .HasMaxLength(20);

                entity.Property(e => e.JobLot)
                    .HasColumnName("job_lot")
                    .HasColumnType("LotType")
                    .HasMaxLength(15);

                entity.Property(e => e.JobSerNum)
                    .HasColumnName("job_ser_num")
                    .HasColumnType("SerNumType")
                    .HasMaxLength(30);

                entity.Property(e => e.Loc)
                    .HasColumnName("loc")
                    .HasColumnType("LocType")
                    .HasMaxLength(15);

                entity.Property(e => e.Lot)
                    .HasColumnName("lot")
                    .HasColumnType("LotType")
                    .HasMaxLength(15);

                entity.Property(e => e.NoteExistsFlag)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OperNum)
                    .HasColumnName("oper_num")
                    .HasColumnType("OperNumType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Override)
                    .HasColumnName("override")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RemoteSiteLotProcess)
                    .IsRequired()
                    .HasColumnName("remote_site_lot_process")
                    .HasColumnType("ListExistingCreateBothType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('B')");

                entity.Property(e => e.RowPointer)
                    .HasColumnType("RowPointerType")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("DcStatusType")
                    .HasMaxLength(1);

                entity.Property(e => e.Suffix)
                    .HasColumnName("suffix")
                    .HasColumnType("SuffixType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Termid)
                    .HasColumnName("termid")
                    .HasColumnType("DcTermIdType")
                    .HasMaxLength(4);

                entity.Property(e => e.TransDate)
                    .HasColumnName("trans_date")
                    .HasColumnType("DateTimeType");

                entity.Property(e => e.TransType)
                    .HasColumnName("trans_type")
                    .HasColumnType("DcTransTypeType")
                    .HasMaxLength(1);

                entity.Property(e => e.Um)
                    .HasColumnName("u_m")
                    .HasColumnType("UMType")
                    .HasMaxLength(3);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Whse)
                    .HasColumnName("whse")
                    .HasColumnType("WhseType")
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpNum);

                entity.ToTable("employee");

                entity.HasIndex(e => e.ADate);

                entity.HasIndex(e => e.AppNum);

                entity.HasIndex(e => e.Charfld1);

                entity.HasIndex(e => e.Country);

                entity.HasIndex(e => e.Dept);

                entity.HasIndex(e => e.IndCode);

                entity.HasIndex(e => e.Name);

                entity.HasIndex(e => e.RowPointer)
                    .HasName("IX_employee_RowPointer")
                    .IsUnique();

                entity.HasIndex(e => e.Shift);

                entity.HasIndex(e => e.State);

                entity.HasIndex(e => new { e.Lname, e.Fname, e.Mi })
                    .HasName("IX_employee_lname");

                entity.Property(e => e.EmpNum)
                    .HasColumnName("emp_num")
                    .HasColumnType("EmpNumType")
                    .HasMaxLength(7)
                    .ValueGeneratedNever();

                entity.Property(e => e.ADate)
                    .HasColumnName("a_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.AddCwtAmt)
                    .HasColumnName("add_cwt_amt")
                    .HasColumnType("PrDeductionType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.AddCwtType)
                    .HasColumnName("add_cwt_type")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1);

                entity.Property(e => e.AddFwtAmt)
                    .HasColumnName("add_fwt_amt")
                    .HasColumnType("PrDeductionType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.AddFwtType)
                    .HasColumnName("add_fwt_type")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1);

                entity.Property(e => e.AddSwtAmt)
                    .HasColumnName("add_swt_amt")
                    .HasColumnType("PrDeductionType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.AddSwtType)
                    .HasColumnName("add_swt_type")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1);

                entity.Property(e => e.Addr1)
                    .HasColumnName("addr##1")
                    .HasColumnType("AddressType")
                    .HasMaxLength(50);

                entity.Property(e => e.Addr2)
                    .HasColumnName("addr##2")
                    .HasColumnType("AddressType")
                    .HasMaxLength(50);

                entity.Property(e => e.Addr3)
                    .HasColumnName("addr##3")
                    .HasColumnType("AddressType")
                    .HasMaxLength(50);

                entity.Property(e => e.Addr4)
                    .HasColumnName("addr##4")
                    .HasColumnType("AddressType")
                    .HasMaxLength(50);

                entity.Property(e => e.AppNum)
                    .HasColumnName("app_num")
                    .HasColumnType("AppNumType")
                    .HasMaxLength(7);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("Date4Type");

                entity.Property(e => e.Bname)
                    .HasColumnName("bname")
                    .HasColumnType("OtherNameType")
                    .HasMaxLength(15);

                entity.Property(e => e.BusinessPhone)
                    .HasColumnName("business_phone")
                    .HasColumnType("PhoneType")
                    .HasMaxLength(25);

                entity.Property(e => e.CaMonth)
                    .HasColumnName("ca_month")
                    .HasColumnType("MonthlyCarAllowanceType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Camileage)
                    .HasColumnName("camileage")
                    .HasColumnType("MileageRateType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CarAllow)
                    .HasColumnName("car_allow")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CarUse)
                    .HasColumnName("car_use")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Charfld1)
                    .HasColumnName("charfld1")
                    .HasColumnType("UserCharFldType")
                    .HasMaxLength(20);

                entity.Property(e => e.Charfld2)
                    .HasColumnName("charfld2")
                    .HasColumnType("UserCharFldType")
                    .HasMaxLength(20);

                entity.Property(e => e.Charfld3)
                    .HasColumnName("charfld3")
                    .HasColumnType("UserCharFldType")
                    .HasMaxLength(20);

                entity.Property(e => e.Citizen)
                    .HasColumnName("citizen")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("CityType")
                    .HasMaxLength(30);

                entity.Property(e => e.CityCode)
                    .HasColumnName("city_code")
                    .HasColumnType("PrTaxCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.CoPdIns)
                    .HasColumnName("co_pd_ins")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasColumnType("CountryType")
                    .HasMaxLength(30);

                entity.Property(e => e.County)
                    .HasColumnName("county")
                    .HasColumnType("CountyType")
                    .HasMaxLength(30);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CwtDol)
                    .HasColumnName("cwt_dol")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CwtNum)
                    .HasColumnName("cwt_num")
                    .HasColumnType("ExemptionsType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Datefld)
                    .HasColumnName("datefld")
                    .HasColumnType("UserDateFldType");

                entity.Property(e => e.DeAmt1)
                    .HasColumnName("de_amt##1")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DeAmt10)
                    .HasColumnName("de_amt##10")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DeAmt11)
                    .HasColumnName("de_amt##11")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DeAmt12)
                    .HasColumnName("de_amt##12")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DeAmt13)
                    .HasColumnName("de_amt##13")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DeAmt14)
                    .HasColumnName("de_amt##14")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DeAmt15)
                    .HasColumnName("de_amt##15")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DeAmt2)
                    .HasColumnName("de_amt##2")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DeAmt3)
                    .HasColumnName("de_amt##3")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DeAmt4)
                    .HasColumnName("de_amt##4")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DeAmt5)
                    .HasColumnName("de_amt##5")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DeAmt6)
                    .HasColumnName("de_amt##6")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DeAmt7)
                    .HasColumnName("de_amt##7")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DeAmt8)
                    .HasColumnName("de_amt##8")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DeAmt9)
                    .HasColumnName("de_amt##9")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DeBal1)
                    .HasColumnName("de_bal##1")
                    .HasColumnType("PrAmountType");

                entity.Property(e => e.DeBal10)
                    .HasColumnName("de_bal##10")
                    .HasColumnType("PrAmountType");

                entity.Property(e => e.DeBal11)
                    .HasColumnName("de_bal##11")
                    .HasColumnType("PrAmountType");

                entity.Property(e => e.DeBal12)
                    .HasColumnName("de_bal##12")
                    .HasColumnType("PrAmountType");

                entity.Property(e => e.DeBal13)
                    .HasColumnName("de_bal##13")
                    .HasColumnType("PrAmountType");

                entity.Property(e => e.DeBal14)
                    .HasColumnName("de_bal##14")
                    .HasColumnType("PrAmountType");

                entity.Property(e => e.DeBal15)
                    .HasColumnName("de_bal##15")
                    .HasColumnType("PrAmountType");

                entity.Property(e => e.DeBal2)
                    .HasColumnName("de_bal##2")
                    .HasColumnType("PrAmountType");

                entity.Property(e => e.DeBal3)
                    .HasColumnName("de_bal##3")
                    .HasColumnType("PrAmountType");

                entity.Property(e => e.DeBal4)
                    .HasColumnName("de_bal##4")
                    .HasColumnType("PrAmountType");

                entity.Property(e => e.DeBal5)
                    .HasColumnName("de_bal##5")
                    .HasColumnType("PrAmountType");

                entity.Property(e => e.DeBal6)
                    .HasColumnName("de_bal##6")
                    .HasColumnType("PrAmountType");

                entity.Property(e => e.DeBal7)
                    .HasColumnName("de_bal##7")
                    .HasColumnType("PrAmountType");

                entity.Property(e => e.DeBal8)
                    .HasColumnName("de_bal##8")
                    .HasColumnType("PrAmountType");

                entity.Property(e => e.DeBal9)
                    .HasColumnName("de_bal##9")
                    .HasColumnType("PrAmountType");

                entity.Property(e => e.DeCode1)
                    .HasColumnName("de_code##1")
                    .HasColumnType("DeCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.DeCode10)
                    .HasColumnName("de_code##10")
                    .HasColumnType("DeCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.DeCode11)
                    .HasColumnName("de_code##11")
                    .HasColumnType("DeCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.DeCode12)
                    .HasColumnName("de_code##12")
                    .HasColumnType("DeCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.DeCode13)
                    .HasColumnName("de_code##13")
                    .HasColumnType("DeCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.DeCode14)
                    .HasColumnName("de_code##14")
                    .HasColumnType("DeCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.DeCode15)
                    .HasColumnName("de_code##15")
                    .HasColumnType("DeCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.DeCode2)
                    .HasColumnName("de_code##2")
                    .HasColumnType("DeCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.DeCode3)
                    .HasColumnName("de_code##3")
                    .HasColumnType("DeCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.DeCode4)
                    .HasColumnName("de_code##4")
                    .HasColumnType("DeCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.DeCode5)
                    .HasColumnName("de_code##5")
                    .HasColumnType("DeCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.DeCode6)
                    .HasColumnName("de_code##6")
                    .HasColumnType("DeCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.DeCode7)
                    .HasColumnName("de_code##7")
                    .HasColumnType("DeCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.DeCode8)
                    .HasColumnName("de_code##8")
                    .HasColumnType("DeCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.DeCode9)
                    .HasColumnName("de_code##9")
                    .HasColumnType("DeCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.DeFreq1)
                    .HasColumnName("de_freq##1")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.DeFreq10)
                    .HasColumnName("de_freq##10")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.DeFreq11)
                    .HasColumnName("de_freq##11")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.DeFreq12)
                    .HasColumnName("de_freq##12")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.DeFreq13)
                    .HasColumnName("de_freq##13")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.DeFreq14)
                    .HasColumnName("de_freq##14")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.DeFreq15)
                    .HasColumnName("de_freq##15")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.DeFreq2)
                    .HasColumnName("de_freq##2")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.DeFreq3)
                    .HasColumnName("de_freq##3")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.DeFreq4)
                    .HasColumnName("de_freq##4")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.DeFreq5)
                    .HasColumnName("de_freq##5")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.DeFreq6)
                    .HasColumnName("de_freq##6")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.DeFreq7)
                    .HasColumnName("de_freq##7")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.DeFreq8)
                    .HasColumnName("de_freq##8")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.DeFreq9)
                    .HasColumnName("de_freq##9")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.DeType1)
                    .HasColumnName("de_type##1")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('$')");

                entity.Property(e => e.DeType10)
                    .HasColumnName("de_type##10")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('$')");

                entity.Property(e => e.DeType11)
                    .HasColumnName("de_type##11")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('$')");

                entity.Property(e => e.DeType12)
                    .HasColumnName("de_type##12")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('$')");

                entity.Property(e => e.DeType13)
                    .HasColumnName("de_type##13")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('$')");

                entity.Property(e => e.DeType14)
                    .HasColumnName("de_type##14")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('$')");

                entity.Property(e => e.DeType15)
                    .HasColumnName("de_type##15")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('$')");

                entity.Property(e => e.DeType2)
                    .HasColumnName("de_type##2")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('$')");

                entity.Property(e => e.DeType3)
                    .HasColumnName("de_type##3")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('$')");

                entity.Property(e => e.DeType4)
                    .HasColumnName("de_type##4")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('$')");

                entity.Property(e => e.DeType5)
                    .HasColumnName("de_type##5")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('$')");

                entity.Property(e => e.DeType6)
                    .HasColumnName("de_type##6")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('$')");

                entity.Property(e => e.DeType7)
                    .HasColumnName("de_type##7")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('$')");

                entity.Property(e => e.DeType8)
                    .HasColumnName("de_type##8")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('$')");

                entity.Property(e => e.DeType9)
                    .HasColumnName("de_type##9")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('$')");

                entity.Property(e => e.Decifld1)
                    .HasColumnName("decifld1")
                    .HasColumnType("UserDeciFldType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Decifld2)
                    .HasColumnName("decifld2")
                    .HasColumnType("UserDeciFldType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Decifld3)
                    .HasColumnName("decifld3")
                    .HasColumnType("UserDeciFldType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Dept)
                    .HasColumnName("dept")
                    .HasColumnType("DeptType")
                    .HasMaxLength(6);

                entity.Property(e => e.DirDep)
                    .HasColumnName("dir_dep")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DtRate)
                    .HasColumnName("dt_rate")
                    .HasColumnType("PayRateType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.EicCr)
                    .HasColumnName("eic_cr")
                    .HasColumnType("EICCreditsType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.EmailAddr)
                    .HasColumnName("email_addr")
                    .HasColumnType("EmailType")
                    .HasMaxLength(60);

                entity.Property(e => e.EmpType)
                    .HasColumnName("emp_type")
                    .HasColumnType("EmpTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('H')");

                entity.Property(e => e.EmprCon)
                    .HasColumnName("empr_con")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.EthnicId)
                    .HasColumnName("ethnic_id")
                    .HasColumnType("EthnicIdType")
                    .HasMaxLength(2);

                entity.Property(e => e.FicaExempt)
                    .HasColumnName("fica_exempt")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Fname)
                    .HasColumnName("fname")
                    .HasColumnType("GivenNameType")
                    .HasMaxLength(15);

                entity.Property(e => e.FuiExempt)
                    .HasColumnName("fui_exempt")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.FwtDol)
                    .HasColumnName("fwt_dol")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.FwtNum)
                    .HasColumnName("fwt_num")
                    .HasColumnType("ExemptionsType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.GarnAmt)
                    .HasColumnName("garn_amt")
                    .HasColumnType("PrDeductionType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.GarnBal)
                    .HasColumnName("garn_bal")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.GarnFreq)
                    .HasColumnName("garn_freq")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.GarnType)
                    .HasColumnName("garn_type")
                    .HasColumnType("GarnishTypeType")
                    .HasMaxLength(1);

                entity.Property(e => e.Handicap)
                    .HasColumnName("handicap")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.HireDate)
                    .HasColumnName("hire_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.InWorkflow)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IndCode)
                    .HasColumnName("ind_code")
                    .HasColumnType("IndCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.InsPrem)
                    .HasColumnName("ins_prem")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Lname)
                    .HasColumnName("lname")
                    .HasColumnType("SurnameType")
                    .HasMaxLength(15);

                entity.Property(e => e.LoanAmt)
                    .HasColumnName("loan_amt")
                    .HasColumnType("PrDeductionType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.LoanBal)
                    .HasColumnName("loan_bal")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.LoanFreq)
                    .HasColumnName("loan_freq")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.Logifld)
                    .HasColumnName("logifld")
                    .HasColumnType("UserLogiFldType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.LunchAuto)
                    .HasColumnName("lunch_auto")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.MaritalStat)
                    .HasColumnName("marital_stat")
                    .HasColumnType("MaritalStatusType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.MfgDtRate)
                    .HasColumnName("mfg_dt_rate")
                    .HasColumnType("PayRateType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.MfgOtRate)
                    .HasColumnName("mfg_ot_rate")
                    .HasColumnType("PayRateType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.MfgRegRate)
                    .HasColumnName("mfg_reg_rate")
                    .HasColumnType("PayRateType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Mi)
                    .HasColumnName("mi")
                    .HasColumnType("InitialType")
                    .HasMaxLength(1);

                entity.Property(e => e.Military)
                    .HasColumnName("military")
                    .HasColumnType("MilitaryType")
                    .HasMaxLength(4);

                entity.Property(e => e.Mname)
                    .HasColumnName("mname")
                    .HasColumnType("OtherNameType")
                    .HasMaxLength(15);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("EmpNameType")
                    .HasMaxLength(35);

                entity.Property(e => e.Nationality)
                    .HasColumnName("nationality")
                    .HasColumnType("NationalityType")
                    .HasMaxLength(12);

                entity.Property(e => e.Nickname)
                    .HasColumnName("nickname")
                    .HasColumnType("OtherNameType")
                    .HasMaxLength(15);

                entity.Property(e => e.NoChldrn)
                    .HasColumnName("no_chldrn")
                    .HasColumnType("ChildrenType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.NoDpndts)
                    .HasColumnName("no_dpndts")
                    .HasColumnType("ChildrenType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.NoteExistsFlag)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OstDol)
                    .HasColumnName("ost_dol")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OstNum)
                    .HasColumnName("ost_num")
                    .HasColumnType("ExemptionsType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OtRate)
                    .HasColumnName("ot_rate")
                    .HasColumnType("PayRateType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PayFreq)
                    .HasColumnName("pay_freq")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('D')");

                entity.Property(e => e.PctUse)
                    .HasColumnName("pct_use")
                    .HasColumnType("PersonalCarUsePctType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Pension)
                    .HasColumnName("pension")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PhExt)
                    .HasColumnName("ph_ext")
                    .HasColumnType("PhoneExtType")
                    .HasMaxLength(13);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("PhoneType")
                    .HasMaxLength(25);

                entity.Property(e => e.Picture)
                    .HasColumnName("picture")
                    .HasColumnType("ImageType");

                entity.Property(e => e.PrFrom)
                    .HasColumnName("pr_from")
                    .HasColumnType("PrGenerateFromType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.RaiseDate)
                    .HasColumnName("raise_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RegRate)
                    .HasColumnName("reg_rate")
                    .HasColumnType("PayRateType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RetireType)
                    .HasColumnName("retire_type")
                    .HasColumnType("PrWithholdingTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('$')");

                entity.Property(e => e.ReviewDate)
                    .HasColumnName("review_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.RowPointer)
                    .HasColumnType("RowPointerType")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.SbDate)
                    .HasColumnName("sb_date")
                    .HasColumnType("Date4Type");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasColumnType("SexType")
                    .HasMaxLength(1);

                entity.Property(e => e.Shift)
                    .HasColumnName("shift")
                    .HasColumnType("ShiftType")
                    .HasMaxLength(3);

                entity.Property(e => e.SickHrDue)
                    .HasColumnName("sick_hr_due")
                    .HasColumnType("HoursOffType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Sname)
                    .HasColumnName("sname")
                    .HasColumnType("SuffixNameType")
                    .HasMaxLength(3);

                entity.Property(e => e.Spouse)
                    .HasColumnName("spouse")
                    .HasColumnType("EmpNameType")
                    .HasMaxLength(35);

                entity.Property(e => e.SrvLeave)
                    .HasColumnName("srv_leave")
                    .HasColumnType("DaysLeaveType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.SrvLyoff)
                    .HasColumnName("srv_lyoff")
                    .HasColumnType("DaysLeaveType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Ssn)
                    .HasColumnName("ssn")
                    .HasColumnType("SsnType")
                    .HasMaxLength(11);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("StateType")
                    .HasMaxLength(5);

                entity.Property(e => e.StateCode)
                    .HasColumnName("state_code")
                    .HasColumnType("PrTaxCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.StateCr)
                    .HasColumnName("state_cr")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.SuiExempt)
                    .HasColumnName("sui_exempt")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.SwtDol)
                    .HasColumnName("swt_dol")
                    .HasColumnType("PrAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.SwtNum)
                    .HasColumnName("swt_num")
                    .HasColumnType("ExemptionsType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.TermDate)
                    .HasColumnName("term_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.TipCr)
                    .HasColumnName("tip_cr")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.UfCdpdate)
                    .HasColumnName("uf_CDPDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UfCdplevel)
                    .HasColumnName("uf_CDPLevel")
                    .HasMaxLength(20);

                entity.Property(e => e.UfDeferralDate)
                    .HasColumnName("uf_deferral_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UfFireEvacDept)
                    .HasColumnName("uf_fire_evac_dept")
                    .HasColumnType("DeptType")
                    .HasMaxLength(6);

                entity.Property(e => e.UfMatchDate)
                    .HasColumnName("uf_match_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UfPartTime)
                    .HasColumnName("uf_PartTime")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.UfPlanEntryDate)
                    .HasColumnName("uf_plan_entry_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UfPlanMatchDate)
                    .HasColumnName("uf_plan_match_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UfTerminationReason)
                    .HasColumnName("uf_TerminationReason")
                    .HasMaxLength(100);

                entity.Property(e => e.UnionAcct)
                    .HasColumnName("union_acct")
                    .HasColumnType("AcctType")
                    .HasMaxLength(12);

                entity.Property(e => e.UnionAcctUnit1)
                    .HasColumnName("union_acct_unit1")
                    .HasColumnType("UnitCode1Type")
                    .HasMaxLength(4);

                entity.Property(e => e.UnionAcctUnit2)
                    .HasColumnName("union_acct_unit2")
                    .HasColumnType("UnitCode2Type")
                    .HasMaxLength(4);

                entity.Property(e => e.UnionAcctUnit3)
                    .HasColumnName("union_acct_unit3")
                    .HasColumnType("UnitCode3Type")
                    .HasMaxLength(4);

                entity.Property(e => e.UnionAcctUnit4)
                    .HasColumnName("union_acct_unit4")
                    .HasColumnType("UnitCode4Type")
                    .HasMaxLength(4);

                entity.Property(e => e.UnionAmt)
                    .HasColumnName("union_amt")
                    .HasColumnType("PrDeductionType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.UnionFreq)
                    .HasColumnName("union_freq")
                    .HasColumnType("PrPayFreqType")
                    .HasMaxLength(1);

                entity.Property(e => e.UnionType)
                    .HasColumnName("union_type")
                    .HasColumnType("UnionDuesTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('F')");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.VacHrDue)
                    .HasColumnName("vac_hr_due")
                    .HasColumnType("HoursOffType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.VacHrPd)
                    .HasColumnName("vac_hr_pd")
                    .HasColumnType("HoursOffType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.WStatus)
                    .HasColumnName("w_status")
                    .HasColumnType("AlienNumType")
                    .HasMaxLength(20);

                entity.Property(e => e.WageAcct)
                    .HasColumnName("wage_acct")
                    .HasColumnType("AcctType")
                    .HasMaxLength(12);

                entity.Property(e => e.WageAcctUnit1)
                    .HasColumnName("wage_acct_unit1")
                    .HasColumnType("UnitCode1Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WageAcctUnit2)
                    .HasColumnName("wage_acct_unit2")
                    .HasColumnType("UnitCode2Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WageAcctUnit3)
                    .HasColumnName("wage_acct_unit3")
                    .HasColumnType("UnitCode3Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WageAcctUnit4)
                    .HasColumnName("wage_acct_unit4")
                    .HasColumnType("UnitCode4Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WcClass)
                    .HasColumnName("wc_class")
                    .HasColumnType("DeCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.WorkCountryCode)
                    .HasColumnName("work_country_code")
                    .HasColumnType("CountryCodeType")
                    .HasMaxLength(2);

                entity.Property(e => e.YtdCoPdIn)
                    .HasColumnName("ytd_co_pd_in")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdCwt)
                    .HasColumnName("ytd_cwt")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdCwtGrs)
                    .HasColumnName("ytd_cwt_grs")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdEficaGr)
                    .HasColumnName("ytd_efica_gr")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdEic)
                    .HasColumnName("ytd_eic")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdEmedGrs)
                    .HasColumnName("ytd_emed_grs")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdEmpCon)
                    .HasColumnName("ytd_emp_con")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdEmprCon)
                    .HasColumnName("ytd_empr_con")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdFica)
                    .HasColumnName("ytd_fica")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdFuiGrs)
                    .HasColumnName("ytd_fui_grs")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdFwt)
                    .HasColumnName("ytd_fwt")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdFwtGrs)
                    .HasColumnName("ytd_fwt_grs")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdGrs)
                    .HasColumnName("ytd_grs")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdMed)
                    .HasColumnName("ytd_med")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdOst)
                    .HasColumnName("ytd_ost")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdOstGrs)
                    .HasColumnName("ytd_ost_grs")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdRficaGr)
                    .HasColumnName("ytd_rfica_gr")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdRmedGrs)
                    .HasColumnName("ytd_rmed_grs")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdSbGrs)
                    .HasColumnName("ytd_sb_grs")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdSuiGrs)
                    .HasColumnName("ytd_sui_grs")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdSwt)
                    .HasColumnName("ytd_swt")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdSwtGrs)
                    .HasColumnName("ytd_swt_grs")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdTipCr)
                    .HasColumnName("ytd_tip_cr")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YtdWcGrs)
                    .HasColumnName("ytd_wc_grs")
                    .HasColumnType("PrYtdAmountType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasColumnType("PostalCodeType")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Item1);

                entity.ToTable("item");

                entity.HasIndex(e => e.BflushLoc);

                entity.HasIndex(e => e.Buyer);

                entity.HasIndex(e => e.Charfld1);

                entity.HasIndex(e => e.CommCode);

                entity.HasIndex(e => e.Description)
                    .HasName("IX_item_desc");

                entity.HasIndex(e => e.FamilyCode);

                entity.HasIndex(e => e.RowPointer)
                    .HasName("IX_item_RowPointer")
                    .IsUnique();

                entity.HasIndex(e => e.SupplySite);

                entity.HasIndex(e => new { e.Job, e.Suffix })
                    .HasName("IX_item_job");

                entity.HasIndex(e => new { e.LowLevel, e.Item1 })
                    .HasName("IX_item_level")
                    .IsUnique();

                entity.HasIndex(e => new { e.PlanCode, e.Item1 })
                    .HasName("IX_item_plan")
                    .IsUnique();

                entity.HasIndex(e => new { e.ProductCode, e.Item1 })
                    .HasName("IX_item_product")
                    .IsUnique();

                entity.HasIndex(e => new { e.SerialTracked, e.Item1 })
                    .HasName("IX_item_serial")
                    .IsUnique();

                entity.HasIndex(e => new { e.UseReorderPoint, e.Item1 })
                    .HasName("IX_item_use_reorder_point")
                    .IsUnique();

                entity.HasIndex(e => new { e.Item1, e.Lowdate, e.RcptRqmt, e.RowPointer })
                    .HasName("IX_item_item_lowdate")
                    .IsUnique();

                entity.Property(e => e.Item1)
                    .HasColumnName("item")
                    .HasColumnType("ItemType")
                    .HasMaxLength(30)
                    .ValueGeneratedNever();

                entity.Property(e => e.AbcCode)
                    .HasColumnName("abc_code")
                    .HasColumnType("AbcCodeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.AcceptReq)
                    .HasColumnName("accept_req")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.ActiveForCustomerPortal)
                    .HasColumnName("active_for_customer_portal")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.ActiveForDataIntegration)
                    .HasColumnName("active_for_data_integration")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.AltItem)
                    .HasColumnName("alt_item")
                    .HasColumnType("ItemType")
                    .HasMaxLength(30);

                entity.Property(e => e.AsmFixed)
                    .HasColumnName("asm_fixed")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AsmFixture)
                    .HasColumnName("asm_fixture")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AsmMatl)
                    .HasColumnName("asm_matl")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AsmOther)
                    .HasColumnName("asm_other")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AsmOutside)
                    .HasColumnName("asm_outside")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AsmRun)
                    .HasColumnName("asm_run")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AsmSetup)
                    .HasColumnName("asm_setup")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AsmTool)
                    .HasColumnName("asm_tool")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AsmVar)
                    .HasColumnName("asm_var")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AttrGroup)
                    .HasColumnName("attr_group")
                    .HasColumnType("AttributeGroupType")
                    .HasMaxLength(10);

                entity.Property(e => e.AutoJob)
                    .IsRequired()
                    .HasColumnName("auto_job")
                    .HasColumnType("ConfigAutoJobType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AutoPost)
                    .IsRequired()
                    .HasColumnName("auto_post")
                    .HasColumnType("ConfigAutoPostType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AvgFovhdCost)
                    .HasColumnName("avg_fovhd_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AvgLbrCost)
                    .HasColumnName("avg_lbr_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AvgMatlCost)
                    .HasColumnName("avg_matl_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AvgOutCost)
                    .HasColumnName("avg_out_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AvgUCost)
                    .HasColumnName("avg_u_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AvgVovhdCost)
                    .HasColumnName("avg_vovhd_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Backflush)
                    .HasColumnName("backflush")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BatchReleaseAttribute1)
                    .HasColumnName("batch_release_attribute1")
                    .HasColumnType("ApsFloatType");

                entity.Property(e => e.BatchReleaseAttribute2)
                    .HasColumnName("batch_release_attribute2")
                    .HasColumnType("ApsFloatType");

                entity.Property(e => e.BatchReleaseAttribute3)
                    .HasColumnName("batch_release_attribute3")
                    .HasColumnType("ApsFloatType");

                entity.Property(e => e.BflushLoc)
                    .HasColumnName("bflush_loc")
                    .HasColumnType("LocType")
                    .HasMaxLength(15);

                entity.Property(e => e.BomLastImportDate)
                    .HasColumnName("bom_last_import_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.Buyer)
                    .HasColumnName("buyer")
                    .HasColumnType("NameType")
                    .HasMaxLength(60);

                entity.Property(e => e.CfgModel)
                    .HasColumnName("cfg_model")
                    .HasColumnType("ConfigModelType")
                    .HasMaxLength(255);

                entity.Property(e => e.ChangeDate)
                    .HasColumnName("change_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.Charfld1)
                    .HasColumnName("charfld1")
                    .HasColumnType("UserCharFldType")
                    .HasMaxLength(20);

                entity.Property(e => e.Charfld2)
                    .HasColumnName("charfld2")
                    .HasColumnType("UserCharFldType")
                    .HasMaxLength(20);

                entity.Property(e => e.Charfld3)
                    .HasColumnName("charfld3")
                    .HasColumnType("UserCharFldType")
                    .HasMaxLength(20);

                entity.Property(e => e.Charfld4)
                    .HasColumnName("charfld4")
                    .HasColumnType("UserCharFldType")
                    .HasMaxLength(20);

                entity.Property(e => e.ChgDate)
                    .HasColumnName("chg_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.CoPostConfig)
                    .HasColumnName("co_post_config")
                    .HasColumnType("ConfigPostConfigType")
                    .HasMaxLength(80);

                entity.Property(e => e.CommCode)
                    .HasColumnName("comm_code")
                    .HasColumnType("CommodityCodeType")
                    .HasMaxLength(12);

                entity.Property(e => e.CompFixed)
                    .HasColumnName("comp_fixed")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompFixture)
                    .HasColumnName("comp_fixture")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompMatl)
                    .HasColumnName("comp_matl")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompOther)
                    .HasColumnName("comp_other")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompOutside)
                    .HasColumnName("comp_outside")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompRun)
                    .HasColumnName("comp_run")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompSetup)
                    .HasColumnName("comp_setup")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompTool)
                    .HasColumnName("comp_tool")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompVar)
                    .HasColumnName("comp_var")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ControlledByExternalIcs)
                    .HasColumnName("controlled_by_external_ics")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.CostMethod)
                    .HasColumnName("cost_method")
                    .HasColumnType("CostMethodType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.CostType)
                    .HasColumnName("cost_type")
                    .HasColumnType("CostTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CurBrokerageCost)
                    .HasColumnName("cur_brokerage_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CurDutyCost)
                    .HasColumnName("cur_duty_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CurFovhdCost)
                    .HasColumnName("cur_fovhd_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CurFreightCost)
                    .HasColumnName("cur_freight_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CurInsuranceCost)
                    .HasColumnName("cur_insurance_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CurLbrCost)
                    .HasColumnName("cur_lbr_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CurLocFrtCost)
                    .HasColumnName("cur_loc_frt_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CurMatCost)
                    .HasColumnName("cur_mat_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CurMatlCost)
                    .HasColumnName("cur_matl_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CurOutCost)
                    .HasColumnName("cur_out_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CurUCost)
                    .HasColumnName("cur_u_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CurVovhdCost)
                    .HasColumnName("cur_vovhd_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Datefld)
                    .HasColumnName("datefld")
                    .HasColumnType("UserDateFldType");

                entity.Property(e => e.DaysSupply)
                    .HasColumnName("days_supply")
                    .HasColumnType("DaysSupplyType")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.Decifld1)
                    .HasColumnName("decifld1")
                    .HasColumnType("UserDeciFldType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Decifld2)
                    .HasColumnName("decifld2")
                    .HasColumnType("UserDeciFldType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Decifld3)
                    .HasColumnName("decifld3")
                    .HasColumnType("UserDeciFldType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("DescriptionType")
                    .HasMaxLength(40);

                entity.Property(e => e.DimensionGroup)
                    .HasColumnName("dimension_group")
                    .HasColumnType("AttributeGroupType")
                    .HasMaxLength(10);

                entity.Property(e => e.DockTime)
                    .HasColumnName("dock_time")
                    .HasColumnType("LeadTimeType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DrawingNbr)
                    .HasColumnName("drawing_nbr")
                    .HasColumnType("DrawingNbrType")
                    .HasMaxLength(25);

                entity.Property(e => e.DuePeriod)
                    .HasColumnName("due_period")
                    .HasColumnType("DuePeriodType");

                entity.Property(e => e.EarliestPlannedPoReceipt)
                    .HasColumnName("earliest_planned_po_receipt")
                    .HasColumnType("DateType");

                entity.Property(e => e.ExciseTaxPercent)
                    .HasColumnName("excise_tax_percent")
                    .HasColumnType("ExciseTaxPercentType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExpLeadTime)
                    .HasColumnName("exp_lead_time")
                    .HasColumnType("LeadTimeType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.FamilyCode)
                    .HasColumnName("family_code")
                    .HasColumnType("FamilyCodeType")
                    .HasMaxLength(10);

                entity.Property(e => e.FeatStr)
                    .HasColumnName("feat_str")
                    .HasColumnType("FeatStrType")
                    .HasMaxLength(40);

                entity.Property(e => e.FeatTempl)
                    .HasColumnName("feat_templ")
                    .HasColumnType("FeatTemplateType")
                    .HasMaxLength(55);

                entity.Property(e => e.FeatType)
                    .HasColumnName("feat_type")
                    .HasColumnType("ListDepIndType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.Featured)
                    .HasColumnName("featured")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.FixedOrderQty)
                    .HasColumnName("fixed_order_qty")
                    .HasColumnType("QtyUnitType");

                entity.Property(e => e.FovhdCost)
                    .HasColumnName("fovhd_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InWorkflow)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IncludeInNetChangePlanning)
                    .HasColumnName("include_in_net_change_planning")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.InfinitePart)
                    .HasColumnName("infinite_part")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.InventoryLclTolerance)
                    .HasColumnName("inventory_lcl_tolerance")
                    .HasColumnType("TolerancePercentType");

                entity.Property(e => e.InventoryUclTolerance)
                    .HasColumnName("inventory_ucl_tolerance")
                    .HasColumnType("TolerancePercentType");

                entity.Property(e => e.IssueBy)
                    .HasColumnName("issue_by")
                    .HasColumnType("ListLocLotType")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('LOT')");

                entity.Property(e => e.Job)
                    .HasColumnName("job")
                    .HasColumnType("JobType")
                    .HasMaxLength(20);

                entity.Property(e => e.JobConfigurable)
                    .HasColumnName("job_configurable")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.JobPostConfig)
                    .HasColumnName("job_post_config")
                    .HasColumnType("ConfigPostConfigType")
                    .HasMaxLength(80);

                entity.Property(e => e.Kit)
                    .HasColumnName("kit")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.LastInv)
                    .HasColumnName("last_inv")
                    .HasColumnType("DateType");

                entity.Property(e => e.LbrCost)
                    .HasColumnName("lbr_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LeadTime)
                    .HasColumnName("lead_time")
                    .HasColumnType("LeadTimeType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Logifld)
                    .HasColumnName("logifld")
                    .HasColumnType("UserLogiFldType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.LotAttrGroup)
                    .HasColumnName("lot_attr_group")
                    .HasColumnType("AttributeGroupType")
                    .HasMaxLength(10);

                entity.Property(e => e.LotGenExp)
                    .HasColumnName("lot_gen_exp")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.LotPrefix)
                    .HasColumnName("lot_prefix")
                    .HasColumnType("LotPrefixType")
                    .HasMaxLength(15);

                entity.Property(e => e.LotSize)
                    .HasColumnName("lot_size")
                    .HasColumnType("QtyPerType")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.LotTracked)
                    .HasColumnName("lot_tracked")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.LowLevel)
                    .HasColumnName("low_level")
                    .HasColumnType("LowLevelType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Lowdate)
                    .HasColumnName("lowdate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(convert(datetime,'1753-01-01',121))");

                entity.Property(e => e.LstLotSize)
                    .HasColumnName("lst_lot_size")
                    .HasColumnType("LotSizeType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.LstUCost)
                    .HasColumnName("lst_u_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MatlCost)
                    .HasColumnName("matl_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MatlType)
                    .HasColumnName("matl_type")
                    .HasColumnType("MatlTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.MfgSupplySwitchingActive)
                    .HasColumnName("mfg_supply_switching_active")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.MpsFlag)
                    .HasColumnName("mps_flag")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.MpsPlanFence)
                    .HasColumnName("mps_plan_fence")
                    .HasColumnType("PlanFenceType");

                entity.Property(e => e.MrpPart)
                    .HasColumnName("mrp_part")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.MustUseFutureRcptsBeforePln)
                    .HasColumnName("must_use_future_rcpts_before_pln")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.NaftaCountryOfOrigin)
                    .HasColumnName("nafta_country_of_origin")
                    .HasColumnType("NAFTACountryOfOriginType")
                    .HasMaxLength(3);

                entity.Property(e => e.NaftaPrefCrit)
                    .HasColumnName("nafta_pref_crit")
                    .HasColumnType("NAFTAPreferenceCriterionType")
                    .HasMaxLength(1);

                entity.Property(e => e.NextConfig)
                    .HasColumnName("next_config")
                    .HasColumnType("FeatSuffixType")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.NoteExistsFlag)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OrderConfigurable)
                    .HasColumnName("order_configurable")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OrderMax)
                    .HasColumnName("order_max")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OrderMin)
                    .HasColumnName("order_min")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OrderMult)
                    .HasColumnName("order_mult")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Origin)
                    .HasColumnName("origin")
                    .HasColumnType("EcCodeType")
                    .HasMaxLength(2);

                entity.Property(e => e.OutCost)
                    .HasColumnName("out_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Overview)
                    .HasColumnName("overview")
                    .HasColumnType("ProductOverviewType");

                entity.Property(e => e.PmtCode)
                    .HasColumnName("p_m_t_code")
                    .HasColumnType("PMTCodeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.PaperTime)
                    .HasColumnName("paper_time")
                    .HasColumnType("LeadTimeType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PassReq)
                    .HasColumnName("pass_req")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.PhantomFlag)
                    .HasColumnName("phantom_flag")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Picture)
                    .HasColumnName("picture")
                    .HasColumnType("ImageType");

                entity.Property(e => e.PlanCode)
                    .HasColumnName("plan_code")
                    .HasColumnType("UserCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.PlanFlag)
                    .HasColumnName("plan_flag")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PreassignLots)
                    .HasColumnName("preassign_lots")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.PreassignSerials)
                    .HasColumnName("preassign_serials")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.PrintKitComponents)
                    .HasColumnName("print_kit_components")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.ProdMix)
                    .HasColumnName("prod_mix")
                    .HasColumnType("ProdMixType")
                    .HasMaxLength(7);

                entity.Property(e => e.ProdType)
                    .HasColumnName("prod_type")
                    .HasColumnType("ProdTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('J')");

                entity.Property(e => e.Producer)
                    .HasColumnName("producer")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("product_code")
                    .HasColumnType("ProductCodeType")
                    .HasMaxLength(10);

                entity.Property(e => e.QtyAllocjob)
                    .HasColumnName("qty_allocjob")
                    .HasColumnType("QtyTotlType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.QtyMfgYtd)
                    .HasColumnName("qty_mfg_ytd")
                    .HasColumnType("QtyCumuType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.QtyUsedYtd)
                    .HasColumnName("qty_used_ytd")
                    .HasColumnType("QtyCumuType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RatePerDay)
                    .HasColumnName("rate_per_day")
                    .HasColumnType("RunRateType")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.RcptRqmt)
                    .IsRequired()
                    .HasColumnName("rcpt_rqmt")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(' ')");

                entity.Property(e => e.RcvdOverPoQtyTolerance)
                    .HasColumnName("rcvd_over_po_qty_tolerance")
                    .HasColumnType("TolerancePercentType");

                entity.Property(e => e.RcvdUnderPoQtyTolerance)
                    .HasColumnName("rcvd_under_po_qty_tolerance")
                    .HasColumnType("TolerancePercentType");

                entity.Property(e => e.ReasonCode)
                    .HasColumnName("reason_code")
                    .HasColumnType("ReasonCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.RecordDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReorderPoint)
                    .HasColumnName("reorder_point")
                    .HasColumnType("QtyUnitType");

                entity.Property(e => e.Reservable)
                    .HasColumnName("reservable")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("RevisionType")
                    .HasMaxLength(8);

                entity.Property(e => e.RowPointer)
                    .HasColumnType("RowPointerType")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.SafetyStockPercent)
                    .HasColumnName("safety_stock_percent")
                    .HasColumnType("SafetyStockPercentType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.SafetyStockRule)
                    .HasColumnName("safety_stock_rule")
                    .HasColumnType("SafetyStockRuleType")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SaveCurrentRevUponBomImport)
                    .HasColumnName("save_current_rev_upon_bom_import")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.SeparationAttribute)
                    .HasColumnName("separation_attribute")
                    .HasColumnType("ApsAttribType")
                    .HasMaxLength(30);

                entity.Property(e => e.SerialLength)
                    .HasColumnName("serial_length")
                    .HasColumnType("SerialLengthType")
                    .HasDefaultValueSql("(30)");

                entity.Property(e => e.SerialPrefix)
                    .HasColumnName("serial_prefix")
                    .HasColumnType("SerialPrefixType")
                    .HasMaxLength(30);

                entity.Property(e => e.SerialTracked)
                    .HasColumnName("serial_tracked")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Setupgroup)
                    .HasColumnName("setupgroup")
                    .HasColumnType("SetupGroupType")
                    .HasMaxLength(10);

                entity.Property(e => e.ShelfLife)
                    .HasColumnName("shelf_life")
                    .HasColumnType("ShelfLifeType");

                entity.Property(e => e.ShowInDropDownList)
                    .HasColumnName("show_in_drop_down_list")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ShrinkFact)
                    .HasColumnName("shrink_fact")
                    .HasColumnType("ScrapFactorType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("ItemStatusType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.StatusChgUserCode)
                    .HasColumnName("status_chg_user_code")
                    .HasColumnType("UserCodeType")
                    .HasMaxLength(3);

                entity.Property(e => e.Stocked)
                    .HasColumnName("stocked")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.SubMatl)
                    .HasColumnName("sub_matl")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SubjectToExciseTax)
                    .HasColumnName("subject_to_excise_tax")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.SubjectToNaftaRvc)
                    .HasColumnName("subject_to_nafta_rvc")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.Suffix)
                    .HasColumnName("suffix")
                    .HasColumnType("SuffixType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.SupplySite)
                    .HasColumnName("supply_site")
                    .HasColumnType("SiteType")
                    .HasMaxLength(8);

                entity.Property(e => e.SupplyToleranceHrs)
                    .HasColumnName("supply_tolerance_hrs")
                    .HasColumnType("SupplyToleranceHoursType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.SupplyWhse)
                    .HasColumnName("supply_whse")
                    .HasColumnType("WhseType")
                    .HasMaxLength(4);

                entity.Property(e => e.TariffClassification)
                    .HasColumnName("tariff_classification")
                    .HasColumnType("TariffClassificationType")
                    .HasMaxLength(20);

                entity.Property(e => e.TaxCode1)
                    .HasColumnName("tax_code1")
                    .HasColumnType("TaxCodeType")
                    .HasMaxLength(6);

                entity.Property(e => e.TaxCode2)
                    .HasColumnName("tax_code2")
                    .HasColumnType("TaxCodeType")
                    .HasMaxLength(6);

                entity.Property(e => e.TaxFreeDays)
                    .HasColumnName("tax_free_days")
                    .HasColumnType("TaxFreeDaysType");

                entity.Property(e => e.TaxFreeMatl)
                    .HasColumnName("tax_free_matl")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.TimeFenceRule)
                    .HasColumnName("time_fence_rule")
                    .HasColumnType("ListTimeFenceRuleType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.TimeFenceValue)
                    .HasColumnName("time_fence_value")
                    .HasColumnType("ApsFloatType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.TopSeller)
                    .HasColumnName("top_seller")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.TrackEcn)
                    .HasColumnName("track_ecn")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.TrackPieces)
                    .HasColumnName("track_pieces")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.Um)
                    .HasColumnName("u_m")
                    .HasColumnType("UMType")
                    .HasMaxLength(3);

                entity.Property(e => e.UWsPrice)
                    .HasColumnName("u_ws_price")
                    .HasColumnType("CostPrcType");

                entity.Property(e => e.Uf2Bin)
                    .HasColumnName("uf_2Bin")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.UfAmsCost)
                    .HasColumnName("uf_AmsCost")
                    .HasColumnType("decimal(18, 8)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.UfBinSs).HasColumnName("uf_BinSS");

                entity.Property(e => e.UfBroker)
                    .HasColumnName("uf_broker")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('N/A')");

                entity.Property(e => e.UfCcgplmbomupd)
                    .HasColumnName("Uf_CCGPLMBOMUpd")
                    .HasMaxLength(20);

                entity.Property(e => e.UfCcgplmitemUpd)
                    .HasColumnName("Uf_CCGPLMItemUpd")
                    .HasMaxLength(20);

                entity.Property(e => e.UfCcgplmkeepBomRevHist).HasColumnName("Uf_CCGPLMKeepBomRevHist");

                entity.Property(e => e.UfCustRev)
                    .HasColumnName("uf_cust_rev")
                    .HasMaxLength(7);

                entity.Property(e => e.UfDimensions)
                    .HasColumnName("uf_dimensions")
                    .HasMaxLength(50);

                entity.Property(e => e.UfDrawNum)
                    .HasColumnName("uf_DrawNum")
                    .HasMaxLength(25);

                entity.Property(e => e.UfEau1).HasColumnName("uf_EAU1");

                entity.Property(e => e.UfEau2).HasColumnName("uf_EAU2");

                entity.Property(e => e.UfEau3).HasColumnName("uf_EAU3");

                entity.Property(e => e.UfEau4)
                    .HasColumnName("uf_EAU4")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UfEauTtm)
                    .HasColumnName("uf_EAU_TTM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UfEaucurrent).HasColumnName("uf_EAUCurrent");

                entity.Property(e => e.UfEcm)
                    .HasColumnName("uf_ECM")
                    .HasMaxLength(25);

                entity.Property(e => e.UfFabricationOverride)
                    .HasColumnName("uf_FabricationOverride")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UfFgbinSize)
                    .HasColumnName("uf_FGBinSize")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.UfIpc)
                    .HasColumnName("Uf_IPC")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('None')");

                entity.Property(e => e.UfItar)
                    .HasColumnName("uf_ITAR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UfLastReceipt)
                    .HasColumnName("Uf_LastReceipt")
                    .HasColumnType("datetime");

                entity.Property(e => e.UfLastUsage)
                    .HasColumnName("Uf_LastUsage")
                    .HasColumnType("datetime");

                entity.Property(e => e.UfLeadtimeQuoteDate)
                    .HasColumnName("uf_Leadtime_QuoteDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UfLotSizeDate)
                    .HasColumnName("uf_LotSizeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UfLotSizeSource)
                    .HasColumnName("uf_LotSizeSource")
                    .HasMaxLength(50);

                entity.Property(e => e.UfMfgLeadtime).HasColumnName("uf_Mfg_Leadtime");

                entity.Property(e => e.UfMinMethod)
                    .HasColumnName("uf_MinMethod")
                    .HasMaxLength(20);

                entity.Property(e => e.UfMountingTech)
                    .HasColumnName("uf_MountingTech")
                    .HasMaxLength(60);

                entity.Property(e => e.UfOrigPlanCode)
                    .HasColumnName("uf_OrigPlanCode")
                    .HasMaxLength(3);

                entity.Property(e => e.UfPcbpanel).HasColumnName("Uf_PCBPanel");

                entity.Property(e => e.UfPlc)
                    .HasColumnName("uf_PLC")
                    .HasMaxLength(10);

                entity.Property(e => e.UfPreferredPackaging)
                    .HasColumnName("uf_PreferredPackaging")
                    .HasMaxLength(50);

                entity.Property(e => e.UfProductType)
                    .HasColumnName("uf_ProductType")
                    .HasMaxLength(20);

                entity.Property(e => e.UfProjSetDate)
                    .HasColumnName("uf_ProjSet_Date")
                    .HasMaxLength(50);

                entity.Property(e => e.UfProjSetReason)
                    .HasColumnName("uf_ProjSet_Reason")
                    .HasMaxLength(50);

                entity.Property(e => e.UfProjectCode)
                    .HasColumnName("uf_ProjectCode")
                    .HasMaxLength(150);

                entity.Property(e => e.UfPullRate)
                    .HasColumnName("uf_PullRate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.UfRegulated)
                    .HasColumnName("uf_Regulated")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.UfRmbinSize)
                    .HasColumnName("uf_RMBinSize")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.UfRoHs)
                    .HasColumnName("Uf_RoHS")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Unknown')");

                entity.Property(e => e.UfSegment)
                    .HasColumnName("uf_Segment")
                    .HasMaxLength(30);

                entity.Property(e => e.UfShelfLifeType)
                    .HasColumnName("uf_ShelfLifeType")
                    .HasMaxLength(1);

                entity.Property(e => e.UfShortDescription)
                    .HasColumnName("uf_ShortDescription")
                    .HasMaxLength(40);

                entity.Property(e => e.UfSnlogId).HasColumnName("uf_snlogID");

                entity.Property(e => e.UfSourceRestriction)
                    .HasColumnName("uf_source_restriction")
                    .HasMaxLength(50);

                entity.Property(e => e.UfStdComments)
                    .HasColumnName("uf_StdComments")
                    .HasMaxLength(100);

                entity.Property(e => e.UfStdFlag).HasColumnName("uf_StdFlag");

                entity.Property(e => e.UfStdLtMethod)
                    .HasColumnName("uf_std_lt_method")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Quote')");

                entity.Property(e => e.UfStdMethod)
                    .HasColumnName("uf_StdMethod")
                    .HasMaxLength(40);

                entity.Property(e => e.UfStdPotext)
                    .HasColumnName("uf_StdPOText")
                    .HasColumnType("ntext");

                entity.Property(e => e.UfTeam)
                    .HasColumnName("uf_Team")
                    .HasMaxLength(10);

                entity.Property(e => e.UfTested)
                    .HasColumnName("uf_tested")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitBrokerageCost)
                    .HasColumnName("unit_brokerage_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitCost)
                    .HasColumnName("unit_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitDutyCost)
                    .HasColumnName("unit_duty_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitFreightCost)
                    .HasColumnName("unit_freight_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitInsuranceCost)
                    .HasColumnName("unit_insurance_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitLocFrtCost)
                    .HasColumnName("unit_loc_frt_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitMatCost)
                    .HasColumnName("unit_mat_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitWeight)
                    .HasColumnName("unit_weight")
                    .HasColumnType("ItemWeightType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.UseReorderPoint)
                    .HasColumnName("use_reorder_point")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.VarExpLead)
                    .HasColumnName("var_exp_lead")
                    .HasColumnType("VarLeadTimeType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.VarLead)
                    .HasColumnName("var_lead")
                    .HasColumnType("VarLeadTimeType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.VovhdCost)
                    .HasColumnName("vovhd_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WeightUnits)
                    .HasColumnName("weight_units")
                    .HasColumnType("WeightUnitsType")
                    .HasMaxLength(3);

                entity.HasOne(d => d.JobNavigation)
                    .WithMany(p => p.ItemNavigation)
                    .HasForeignKey(d => new { d.Job, d.Suffix })
                    .HasConstraintName("itemFk7");
            });

            modelBuilder.Entity<Itemloc>(entity =>
            {
                entity.HasKey(e => new { e.Whse, e.Item, e.Loc });

                entity.ToTable("itemloc");

                entity.HasIndex(e => e.RowPointer)
                    .HasName("IX_itemloc_RowPointer")
                    .IsUnique();

                entity.HasIndex(e => new { e.Whse, e.Item, e.Rank })
                    .HasName("IX_itemloc");

                entity.HasIndex(e => new { e.Whse, e.Loc, e.Item })
                    .HasName("IX_itemloc_loc")
                    .IsUnique();

                entity.HasIndex(e => new { e.Item, e.Loc, e.Wc, e.Whse })
                    .HasName("IX_itemloc_item_loc_wc_whse")
                    .IsUnique();

                entity.HasIndex(e => new { e.Item, e.Wc, e.Whse, e.Rank });

                entity.Property(e => e.Whse)
                    .HasColumnName("whse")
                    .HasColumnType("WhseType")
                    .HasMaxLength(4);

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasColumnType("ItemType")
                    .HasMaxLength(30);

                entity.Property(e => e.Loc)
                    .HasColumnName("loc")
                    .HasColumnType("LocType")
                    .HasMaxLength(15);

                entity.Property(e => e.AssignedToBePickedQty)
                    .HasColumnName("assigned_to_be_picked_qty")
                    .HasColumnType("QtyUnitType");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.FovhdAcct)
                    .HasColumnName("fovhd_acct")
                    .HasColumnType("AcctType")
                    .HasMaxLength(12);

                entity.Property(e => e.FovhdAcctUnit1)
                    .HasColumnName("fovhd_acct_unit1")
                    .HasColumnType("UnitCode1Type")
                    .HasMaxLength(4);

                entity.Property(e => e.FovhdAcctUnit2)
                    .HasColumnName("fovhd_acct_unit2")
                    .HasColumnType("UnitCode2Type")
                    .HasMaxLength(4);

                entity.Property(e => e.FovhdAcctUnit3)
                    .HasColumnName("fovhd_acct_unit3")
                    .HasColumnType("UnitCode3Type")
                    .HasMaxLength(4);

                entity.Property(e => e.FovhdAcctUnit4)
                    .HasColumnName("fovhd_acct_unit4")
                    .HasColumnType("UnitCode4Type")
                    .HasMaxLength(4);

                entity.Property(e => e.FovhdCost)
                    .HasColumnName("fovhd_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InWorkflow)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.InvAcct)
                    .HasColumnName("inv_acct")
                    .HasColumnType("AcctType")
                    .HasMaxLength(12);

                entity.Property(e => e.InvAcctUnit1)
                    .HasColumnName("inv_acct_unit1")
                    .HasColumnType("UnitCode1Type")
                    .HasMaxLength(4);

                entity.Property(e => e.InvAcctUnit2)
                    .HasColumnName("inv_acct_unit2")
                    .HasColumnType("UnitCode2Type")
                    .HasMaxLength(4);

                entity.Property(e => e.InvAcctUnit3)
                    .HasColumnName("inv_acct_unit3")
                    .HasColumnType("UnitCode3Type")
                    .HasMaxLength(4);

                entity.Property(e => e.InvAcctUnit4)
                    .HasColumnName("inv_acct_unit4")
                    .HasColumnType("UnitCode4Type")
                    .HasMaxLength(4);

                entity.Property(e => e.LastCountQtyOnHand)
                    .HasColumnName("last_count_qty_on_hand")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastCountQtyRsvd)
                    .HasColumnName("last_count_qty_rsvd")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LbrAcct)
                    .HasColumnName("lbr_acct")
                    .HasColumnType("AcctType")
                    .HasMaxLength(12);

                entity.Property(e => e.LbrAcctUnit1)
                    .HasColumnName("lbr_acct_unit1")
                    .HasColumnType("UnitCode1Type")
                    .HasMaxLength(4);

                entity.Property(e => e.LbrAcctUnit2)
                    .HasColumnName("lbr_acct_unit2")
                    .HasColumnType("UnitCode2Type")
                    .HasMaxLength(4);

                entity.Property(e => e.LbrAcctUnit3)
                    .HasColumnName("lbr_acct_unit3")
                    .HasColumnType("UnitCode3Type")
                    .HasMaxLength(4);

                entity.Property(e => e.LbrAcctUnit4)
                    .HasColumnName("lbr_acct_unit4")
                    .HasColumnType("UnitCode4Type")
                    .HasMaxLength(4);

                entity.Property(e => e.LbrCost)
                    .HasColumnName("lbr_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LocType)
                    .HasColumnName("loc_type")
                    .HasColumnType("LocTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.MatlCost)
                    .HasColumnName("matl_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MrbFlag)
                    .HasColumnName("mrb_flag")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.NewRank).HasColumnType("ItemlocRankType");

                entity.Property(e => e.NoteExistsFlag)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OutAcct)
                    .HasColumnName("out_acct")
                    .HasColumnType("AcctType")
                    .HasMaxLength(12);

                entity.Property(e => e.OutAcctUnit1)
                    .HasColumnName("out_acct_unit1")
                    .HasColumnType("UnitCode1Type")
                    .HasMaxLength(4);

                entity.Property(e => e.OutAcctUnit2)
                    .HasColumnName("out_acct_unit2")
                    .HasColumnType("UnitCode2Type")
                    .HasMaxLength(4);

                entity.Property(e => e.OutAcctUnit3)
                    .HasColumnName("out_acct_unit3")
                    .HasColumnType("UnitCode3Type")
                    .HasMaxLength(4);

                entity.Property(e => e.OutAcctUnit4)
                    .HasColumnName("out_acct_unit4")
                    .HasColumnType("UnitCode4Type")
                    .HasMaxLength(4);

                entity.Property(e => e.OutCost)
                    .HasColumnName("out_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PermFlag)
                    .HasColumnName("perm_flag")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.QtyContained)
                    .HasColumnName("qty_contained")
                    .HasColumnType("QtyUnitNoNegType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyOnHand)
                    .HasColumnName("qty_on_hand")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.QtyRsvd)
                    .HasColumnName("qty_rsvd")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Rank)
                    .HasColumnName("rank")
                    .HasColumnType("ItemlocRankType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowPointer)
                    .HasColumnType("RowPointerType")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UnitCost)
                    .HasColumnName("unit_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.VovhdAcct)
                    .HasColumnName("vovhd_acct")
                    .HasColumnType("AcctType")
                    .HasMaxLength(12);

                entity.Property(e => e.VovhdAcctUnit1)
                    .HasColumnName("vovhd_acct_unit1")
                    .HasColumnType("UnitCode1Type")
                    .HasMaxLength(4);

                entity.Property(e => e.VovhdAcctUnit2)
                    .HasColumnName("vovhd_acct_unit2")
                    .HasColumnType("UnitCode2Type")
                    .HasMaxLength(4);

                entity.Property(e => e.VovhdAcctUnit3)
                    .HasColumnName("vovhd_acct_unit3")
                    .HasColumnType("UnitCode3Type")
                    .HasMaxLength(4);

                entity.Property(e => e.VovhdAcctUnit4)
                    .HasColumnName("vovhd_acct_unit4")
                    .HasColumnType("UnitCode4Type")
                    .HasMaxLength(4);

                entity.Property(e => e.VovhdCost)
                    .HasColumnName("vovhd_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Wc)
                    .HasColumnName("wc")
                    .HasColumnType("WcType")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => new { e.Job1, e.Suffix });

                entity.ToTable("job");

                entity.HasIndex(e => e.CustNum)
                    .HasName("IX_job_cust");

                entity.HasIndex(e => e.RowPointer)
                    .HasName("IX_job_RowPointer")
                    .IsUnique();

                entity.HasIndex(e => e.Whse);

                entity.HasIndex(e => new { e.PsNum, e.Type });

                entity.HasIndex(e => new { e.RootJob, e.RootSuf })
                    .HasName("IX_job_root_job");

                entity.HasIndex(e => new { e.Item, e.Suffix, e.Type })
                    .HasName("IX_job_item_suffix");

                entity.HasIndex(e => new { e.OrdNum, e.OrdLine, e.OrdRelease })
                    .HasName("IX_job_ord_num");

                entity.HasIndex(e => new { e.Item, e.Job1, e.Suffix, e.Type, e.Stat })
                    .HasName("ix_job_item_job");

                entity.HasIndex(e => new { e.Type, e.Item, e.MidnightOfJobSchCompdate, e.RcptRqmt, e.RowPointer })
                    .HasName("IX_job_item_midnight_of_job_sch_compdate")
                    .IsUnique();

                entity.HasIndex(e => new { e.Type, e.Item, e.MidnightOfJobSchEndDate, e.RcptRqmt, e.RowPointer })
                    .HasName("IX_job_item_midnight_of_job_sch_end_date")
                    .IsUnique();

                entity.Property(e => e.Job1)
                    .HasColumnName("job")
                    .HasColumnType("JobType")
                    .HasMaxLength(20);

                entity.Property(e => e.Suffix)
                    .HasColumnName("suffix")
                    .HasColumnType("SuffixType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CoProductMix)
                    .HasColumnName("co_product_mix")
                    .HasColumnType("CoProductMixType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ConfigId)
                    .HasColumnName("config_id")
                    .HasColumnType("ConfigIdType")
                    .HasMaxLength(12);

                entity.Property(e => e.ContainsTaxFreeMatl)
                    .HasColumnName("contains_tax_free_matl")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CustNum)
                    .HasColumnName("cust_num")
                    .HasColumnType("CustNumType")
                    .HasMaxLength(7);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("DescriptionType")
                    .HasMaxLength(40);

                entity.Property(e => e.EffectDate)
                    .HasColumnName("effect_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.EstJob)
                    .HasColumnName("est_job")
                    .HasColumnType("JobType")
                    .HasMaxLength(20);

                entity.Property(e => e.EstSuf)
                    .HasColumnName("est_suf")
                    .HasColumnType("SuffixType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ExportType)
                    .IsRequired()
                    .HasColumnName("export_type")
                    .HasColumnType("ListDirectIndirectNonExportType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.InWorkflow)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IsExternal)
                    .HasColumnName("is_external")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasColumnName("item")
                    .HasColumnType("ItemType")
                    .HasMaxLength(30);

                entity.Property(e => e.JcbAcct)
                    .HasColumnName("jcb_acct")
                    .HasColumnType("AcctType")
                    .HasMaxLength(12);

                entity.Property(e => e.JcbAcctUnit1)
                    .HasColumnName("jcb_acct_unit1")
                    .HasColumnType("UnitCode1Type")
                    .HasMaxLength(4);

                entity.Property(e => e.JcbAcctUnit2)
                    .HasColumnName("jcb_acct_unit2")
                    .HasColumnType("UnitCode2Type")
                    .HasMaxLength(4);

                entity.Property(e => e.JcbAcctUnit3)
                    .HasColumnName("jcb_acct_unit3")
                    .HasColumnType("UnitCode3Type")
                    .HasMaxLength(4);

                entity.Property(e => e.JcbAcctUnit4)
                    .HasColumnName("jcb_acct_unit4")
                    .HasColumnType("UnitCode4Type")
                    .HasMaxLength(4);

                entity.Property(e => e.JobDate)
                    .HasColumnName("job_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.LowLevel)
                    .HasColumnName("low_level")
                    .HasColumnType("LowLevelType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.LstTrxDate)
                    .HasColumnName("lst_trx_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.MidnightOfJobSchCompdate)
                    .HasColumnName("midnight_of_job_sch_compdate")
                    .HasColumnType("DateType");

                entity.Property(e => e.MidnightOfJobSchEndDate)
                    .HasColumnName("midnight_of_job_sch_end_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.NoteExistsFlag)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OrdLine)
                    .HasColumnName("ord_line")
                    .HasColumnType("CoProjTaskTrnLineType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OrdNum)
                    .HasColumnName("ord_num")
                    .HasColumnType("CoProjTrnNumType")
                    .HasMaxLength(10);

                entity.Property(e => e.OrdRelease)
                    .HasColumnName("ord_release")
                    .HasColumnType("CoReleaseType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OrdType)
                    .HasColumnName("ord_type")
                    .HasColumnType("RefTypeIKOTType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.Picked)
                    .HasColumnName("picked")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PreassignLots)
                    .HasColumnName("preassign_lots")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.PreassignSerials)
                    .HasColumnName("preassign_serials")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.ProdMix)
                    .HasColumnName("prod_mix")
                    .HasColumnType("ProdMixType")
                    .HasMaxLength(7);

                entity.Property(e => e.ProspectId)
                    .HasColumnName("prospect_id")
                    .HasColumnType("ProspectIDType")
                    .HasMaxLength(7);

                entity.Property(e => e.PsNum)
                    .HasColumnName("ps_num")
                    .HasColumnType("PsNumType")
                    .HasMaxLength(10);

                entity.Property(e => e.QtyComplete)
                    .HasColumnName("qty_complete")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.QtyReleased)
                    .HasColumnName("qty_released")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.QtyScrapped)
                    .HasColumnName("qty_scrapped")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RcptRqmt)
                    .IsRequired()
                    .HasColumnName("rcpt_rqmt")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasComputedColumnSql("('C')");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RefJob)
                    .HasColumnName("ref_job")
                    .HasColumnType("JobType")
                    .HasMaxLength(20);

                entity.Property(e => e.RefOper)
                    .HasColumnName("ref_oper")
                    .HasColumnType("OperNumType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RefSeq)
                    .HasColumnName("ref_seq")
                    .HasColumnType("JobmatlSequenceType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RefSuf)
                    .HasColumnName("ref_suf")
                    .HasColumnType("SuffixType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("RevisionType")
                    .HasMaxLength(8);

                entity.Property(e => e.Rework)
                    .HasColumnName("rework")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.RollupDate)
                    .HasColumnName("rollup_date")
                    .HasColumnType("DateTimeType");

                entity.Property(e => e.RootJob)
                    .HasColumnName("root_job")
                    .HasColumnType("JobType")
                    .HasMaxLength(20);

                entity.Property(e => e.RootSuf)
                    .HasColumnName("root_suf")
                    .HasColumnType("SuffixType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RowPointer)
                    .HasColumnType("RowPointerType")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Scheduled)
                    .HasColumnName("scheduled")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("JobStatusType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('F')");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("JobTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('E')");

                entity.Property(e => e.UfRevisedRevision)
                    .HasColumnName("uf_revised_revision")
                    .HasMaxLength(25);

                entity.Property(e => e.UnlinkedXref)
                    .HasColumnName("unlinked_xref")
                    .HasColumnType("ListYesNoType");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Whse)
                    .HasColumnName("whse")
                    .HasColumnType("WhseType")
                    .HasMaxLength(4);

                entity.Property(e => e.WipAcct)
                    .HasColumnName("wip_acct")
                    .HasColumnType("AcctType")
                    .HasMaxLength(12);

                entity.Property(e => e.WipAcctUnit1)
                    .HasColumnName("wip_acct_unit1")
                    .HasColumnType("UnitCode1Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipAcctUnit2)
                    .HasColumnName("wip_acct_unit2")
                    .HasColumnType("UnitCode2Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipAcctUnit3)
                    .HasColumnName("wip_acct_unit3")
                    .HasColumnType("UnitCode3Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipAcctUnit4)
                    .HasColumnName("wip_acct_unit4")
                    .HasColumnType("UnitCode4Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipComplete)
                    .HasColumnName("wip_complete")
                    .HasColumnType("AmountType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipFovhdAcct)
                    .HasColumnName("wip_fovhd_acct")
                    .HasColumnType("AcctType")
                    .HasMaxLength(12);

                entity.Property(e => e.WipFovhdAcctUnit1)
                    .HasColumnName("wip_fovhd_acct_unit1")
                    .HasColumnType("UnitCode1Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipFovhdAcctUnit2)
                    .HasColumnName("wip_fovhd_acct_unit2")
                    .HasColumnType("UnitCode2Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipFovhdAcctUnit3)
                    .HasColumnName("wip_fovhd_acct_unit3")
                    .HasColumnType("UnitCode3Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipFovhdAcctUnit4)
                    .HasColumnName("wip_fovhd_acct_unit4")
                    .HasColumnType("UnitCode4Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipFovhdComp)
                    .HasColumnName("wip_fovhd_comp")
                    .HasColumnType("AmountType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipFovhdTotal)
                    .HasColumnName("wip_fovhd_total")
                    .HasColumnType("AmountType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipLbrAcct)
                    .HasColumnName("wip_lbr_acct")
                    .HasColumnType("AcctType")
                    .HasMaxLength(12);

                entity.Property(e => e.WipLbrAcctUnit1)
                    .HasColumnName("wip_lbr_acct_unit1")
                    .HasColumnType("UnitCode1Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipLbrAcctUnit2)
                    .HasColumnName("wip_lbr_acct_unit2")
                    .HasColumnType("UnitCode2Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipLbrAcctUnit3)
                    .HasColumnName("wip_lbr_acct_unit3")
                    .HasColumnType("UnitCode3Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipLbrAcctUnit4)
                    .HasColumnName("wip_lbr_acct_unit4")
                    .HasColumnType("UnitCode4Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipLbrComp)
                    .HasColumnName("wip_lbr_comp")
                    .HasColumnType("AmountType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipLbrTotal)
                    .HasColumnName("wip_lbr_total")
                    .HasColumnType("AmountType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipMatlComp)
                    .HasColumnName("wip_matl_comp")
                    .HasColumnType("AmountType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipMatlTotal)
                    .HasColumnName("wip_matl_total")
                    .HasColumnType("AmountType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipOutAcct)
                    .HasColumnName("wip_out_acct")
                    .HasColumnType("AcctType")
                    .HasMaxLength(12);

                entity.Property(e => e.WipOutAcctUnit1)
                    .HasColumnName("wip_out_acct_unit1")
                    .HasColumnType("UnitCode1Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipOutAcctUnit2)
                    .HasColumnName("wip_out_acct_unit2")
                    .HasColumnType("UnitCode2Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipOutAcctUnit3)
                    .HasColumnName("wip_out_acct_unit3")
                    .HasColumnType("UnitCode3Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipOutAcctUnit4)
                    .HasColumnName("wip_out_acct_unit4")
                    .HasColumnType("UnitCode4Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipOutComp)
                    .HasColumnName("wip_out_comp")
                    .HasColumnType("AmountType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipOutTotal)
                    .HasColumnName("wip_out_total")
                    .HasColumnType("AmountType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipSpecial)
                    .HasColumnName("wip_special")
                    .HasColumnType("AmountType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipTotal)
                    .HasColumnName("wip_total")
                    .HasColumnType("AmountType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipVovhdAcct)
                    .HasColumnName("wip_vovhd_acct")
                    .HasColumnType("AcctType")
                    .HasMaxLength(12);

                entity.Property(e => e.WipVovhdAcctUnit1)
                    .HasColumnName("wip_vovhd_acct_unit1")
                    .HasColumnType("UnitCode1Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipVovhdAcctUnit2)
                    .HasColumnName("wip_vovhd_acct_unit2")
                    .HasColumnType("UnitCode2Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipVovhdAcctUnit3)
                    .HasColumnName("wip_vovhd_acct_unit3")
                    .HasColumnType("UnitCode3Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipVovhdAcctUnit4)
                    .HasColumnName("wip_vovhd_acct_unit4")
                    .HasColumnType("UnitCode4Type")
                    .HasMaxLength(4);

                entity.Property(e => e.WipVovhdComp)
                    .HasColumnName("wip_vovhd_comp")
                    .HasColumnType("AmountType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipVovhdTotal)
                    .HasColumnName("wip_vovhd_total")
                    .HasColumnType("AmountType")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Jobmatl>(entity =>
            {
                entity.HasKey(e => new { e.Job, e.Suffix, e.OperNum, e.Sequence });

                entity.ToTable("jobmatl");

                entity.HasIndex(e => e.Item);

                entity.HasIndex(e => e.RowPointer)
                    .HasName("IX_jobmatl_RowPointer")
                    .IsUnique();

                entity.HasIndex(e => new { e.BflushLoc, e.Item });

                entity.HasIndex(e => new { e.Job, e.Suffix, e.BomSeq })
                    .HasName("IX_jobmatl_bom_seq");

                entity.HasIndex(e => new { e.Job, e.Suffix, e.Feature })
                    .HasName("IX_jobmatl_feature");

                entity.HasIndex(e => new { e.Job, e.Suffix, e.Item })
                    .HasName("IX_jobmatl_matlitem");

                entity.HasIndex(e => new { e.Job, e.Suffix, e.OperNum, e.AltGroup, e.AltGroupRank })
                    .HasName("IX_jobmatl_group_rank");

                entity.HasIndex(e => new { e.Job, e.Suffix, e.OperNum, e.AltGroupRank, e.AltGroup })
                    .HasName("IX_jobmatl_rank_group");

                entity.Property(e => e.Job)
                    .HasColumnName("job")
                    .HasColumnType("JobType")
                    .HasMaxLength(20);

                entity.Property(e => e.Suffix)
                    .HasColumnName("suffix")
                    .HasColumnType("SuffixType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OperNum)
                    .HasColumnName("oper_num")
                    .HasColumnType("OperNumType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence")
                    .HasColumnType("JobmatlSequenceType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ACost)
                    .HasColumnName("a_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AFovhdCost)
                    .HasColumnName("a_fovhd_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ALbrCost)
                    .HasColumnName("a_lbr_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AMatlCost)
                    .HasColumnName("a_matl_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AOutCost)
                    .HasColumnName("a_out_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AVovhdCost)
                    .HasColumnName("a_vovhd_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AltGroup)
                    .HasColumnName("alt_group")
                    .HasColumnType("JobmatlSequenceType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.AltGroupRank)
                    .HasColumnName("alt_group_rank")
                    .HasColumnType("JobmatlRankType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Backflush)
                    .HasColumnName("backflush")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BflushLoc)
                    .HasColumnName("bflush_loc")
                    .HasColumnType("LocType")
                    .HasMaxLength(15);

                entity.Property(e => e.BomSeq)
                    .HasColumnName("bom_seq")
                    .HasColumnType("EcnBomSeqType");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("CostPrcType");

                entity.Property(e => e.CostConv)
                    .HasColumnName("cost_conv")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("DescriptionType")
                    .HasMaxLength(40);

                entity.Property(e => e.EffectDate)
                    .HasColumnName("effect_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.Feature)
                    .HasColumnName("feature")
                    .HasColumnType("FeatureType")
                    .HasMaxLength(8);

                entity.Property(e => e.FixovhdT)
                    .HasColumnName("fixovhd_t")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fmatlovhd)
                    .HasColumnName("fmatlovhd")
                    .HasColumnType("OverheadRateType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.FovhdCost)
                    .HasColumnName("fovhd_cost")
                    .HasColumnType("CostPrcType");

                entity.Property(e => e.FovhdCostConv)
                    .HasColumnName("fovhd_cost_conv")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InWorkflow)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IncPrice)
                    .HasColumnName("inc_price")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IncPriceConv)
                    .HasColumnName("inc_price_conv")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasColumnName("item")
                    .HasColumnType("ItemType")
                    .HasMaxLength(30);

                entity.Property(e => e.LbrCost)
                    .HasColumnName("lbr_cost")
                    .HasColumnType("CostPrcType");

                entity.Property(e => e.LbrCostConv)
                    .HasColumnName("lbr_cost_conv")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ManufacturerId)
                    .HasColumnName("manufacturer_id")
                    .HasColumnType("ManufacturerIdType")
                    .HasMaxLength(7);

                entity.Property(e => e.ManufacturerItem)
                    .HasColumnName("manufacturer_item")
                    .HasColumnType("ManufacturerItemType")
                    .HasMaxLength(30);

                entity.Property(e => e.MatlCost)
                    .HasColumnName("matl_cost")
                    .HasColumnType("CostPrcType");

                entity.Property(e => e.MatlCostConv)
                    .HasColumnName("matl_cost_conv")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MatlQty)
                    .HasColumnName("matl_qty")
                    .HasColumnType("QtyPerType")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.MatlQtyConv)
                    .HasColumnName("matl_qty_conv")
                    .HasColumnType("QtyPerType")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.MatlType)
                    .HasColumnName("matl_type")
                    .HasColumnType("MatlTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.NewSequence)
                    .HasColumnName("new_sequence")
                    .HasColumnType("JobmatlSequenceType");

                entity.Property(e => e.NoteExistsFlag)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ObsDate)
                    .HasColumnName("obs_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.OptCode)
                    .HasColumnName("opt_code")
                    .HasColumnType("OptCodeType")
                    .HasMaxLength(8);

                entity.Property(e => e.OutCost)
                    .HasColumnName("out_cost")
                    .HasColumnType("CostPrcType");

                entity.Property(e => e.OutCostConv)
                    .HasColumnName("out_cost_conv")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PickDate)
                    .HasColumnName("pick_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.PlannedAlternate)
                    .HasColumnName("planned_alternate")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PoUnitCost)
                    .HasColumnName("po_unit_cost")
                    .HasColumnType("CostPrcType");

                entity.Property(e => e.Probable)
                    .HasColumnName("probable")
                    .HasColumnType("ProbableType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.QtyIssued)
                    .HasColumnName("qty_issued")
                    .HasColumnType("QtyPerType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.QtyVar)
                    .HasColumnName("qty_var")
                    .HasColumnType("QtyPerType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RefLineSuf)
                    .HasColumnName("ref_line_suf")
                    .HasColumnType("SuffixPoLineProjTaskReqTrnLineType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RefNum)
                    .HasColumnName("ref_num")
                    .HasColumnType("JobPoProjReqTrnNumType")
                    .HasMaxLength(10);

                entity.Property(e => e.RefRelease)
                    .HasColumnName("ref_release")
                    .HasColumnType("OperNumPoReleaseType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RefType)
                    .HasColumnName("ref_type")
                    .HasColumnType("RefTypeIJKPRTType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.RowPointer)
                    .HasColumnType("RowPointerType")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ScrapFact)
                    .HasColumnName("scrap_fact")
                    .HasColumnType("ScrapFactorType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Um)
                    .HasColumnName("u_m")
                    .HasColumnType("UMType")
                    .HasMaxLength(3);

                entity.Property(e => e.UfAmsPlan)
                    .HasColumnName("uf_AmsPlan")
                    .HasColumnType("decimal(19, 8)");

                entity.Property(e => e.UfMaterialUsageVarianceReason)
                    .HasColumnName("Uf_MaterialUsageVarianceReason")
                    .HasMaxLength(50);

                entity.Property(e => e.Units)
                    .HasColumnName("units")
                    .HasColumnType("JobmatlUnitsType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('U')");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.VarovhdT)
                    .HasColumnName("varovhd_t")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Vmatlovhd)
                    .HasColumnName("vmatlovhd")
                    .HasColumnType("OverheadRateType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.VovhdCost)
                    .HasColumnName("vovhd_cost")
                    .HasColumnType("CostPrcType");

                entity.Property(e => e.VovhdCostConv)
                    .HasColumnName("vovhd_cost_conv")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Jobroute>(entity =>
            {
                entity.HasKey(e => new { e.Job, e.Suffix, e.OperNum });

                entity.ToTable("jobroute");

                entity.HasIndex(e => e.Complete)
                    .HasName("IX_jobroute_cmplt");

                entity.HasIndex(e => e.RowPointer)
                    .HasName("IX_jobroute_RowPointer")
                    .IsUnique();

                entity.HasIndex(e => e.Wc);

                entity.Property(e => e.Job)
                    .HasColumnName("job")
                    .HasColumnType("JobType")
                    .HasMaxLength(20);

                entity.Property(e => e.Suffix)
                    .HasColumnName("suffix")
                    .HasColumnType("SuffixType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OperNum)
                    .HasColumnName("oper_num")
                    .HasColumnType("OperNumType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BflushType)
                    .HasColumnName("bflush_type")
                    .HasColumnType("BflushTypeType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CntrlPoint)
                    .HasColumnName("cntrl_point")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.Complete)
                    .HasColumnName("complete")
                    .HasColumnType("ListYesNoType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.EffectDate)
                    .HasColumnName("effect_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.Efficiency)
                    .HasColumnName("efficiency")
                    .HasColumnType("EfficiencyType")
                    .HasDefaultValueSql("(100)");

                entity.Property(e => e.FixovhdRate)
                    .HasColumnName("fixovhd_rate")
                    .HasColumnType("OverheadRateType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.FixovhdTLbr)
                    .HasColumnName("fixovhd_t_lbr")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FixovhdTMch)
                    .HasColumnName("fixovhd_t_mch")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FovhdRateMch)
                    .HasColumnName("fovhd_rate_mch")
                    .HasColumnType("OverheadRateType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.InWorkflow)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.NoteExistsFlag)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ObsDate)
                    .HasColumnName("obs_date")
                    .HasColumnType("DateType");

                entity.Property(e => e.QtyComplete)
                    .HasColumnName("qty_complete")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.QtyMoved)
                    .HasColumnName("qty_moved")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.QtyReceived)
                    .HasColumnName("qty_received")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.QtyScrapped)
                    .HasColumnName("qty_scrapped")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowPointer)
                    .HasColumnType("RowPointerType")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RunBasisLbr)
                    .HasColumnName("run_basis_lbr")
                    .HasColumnType("RunBasisLbrType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('H')");

                entity.Property(e => e.RunBasisMch)
                    .HasColumnName("run_basis_mch")
                    .HasColumnType("RunBasisMchType")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('H')");

                entity.Property(e => e.RunCostTLbr)
                    .HasColumnName("run_cost_t_lbr")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RunHrsTLbr)
                    .HasColumnName("run_hrs_t_lbr")
                    .HasColumnType("TotalHoursType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RunHrsTMch)
                    .HasColumnName("run_hrs_t_mch")
                    .HasColumnType("TotalHoursType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RunHrsVLbr)
                    .HasColumnName("run_hrs_v_lbr")
                    .HasColumnType("RunHoursType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RunHrsVMch)
                    .HasColumnName("run_hrs_v_mch")
                    .HasColumnType("RunHoursType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RunRateLbr)
                    .HasColumnName("run_rate_lbr")
                    .HasColumnType("RunRateType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.SetupCostT)
                    .HasColumnName("setup_cost_t")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupHrsT)
                    .HasColumnName("setup_hrs_t")
                    .HasColumnType("TotalHoursType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupHrsV)
                    .HasColumnName("setup_hrs_v")
                    .HasColumnType("TotalHoursType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupRate)
                    .HasColumnName("setup_rate")
                    .HasColumnType("RunRateType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.VarovhdRate)
                    .HasColumnName("varovhd_rate")
                    .HasColumnType("OverheadRateType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.VarovhdTLbr)
                    .HasColumnName("varovhd_t_lbr")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VarovhdTMch)
                    .HasColumnName("varovhd_t_mch")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VovhdRateMch)
                    .HasColumnName("vovhd_rate_mch")
                    .HasColumnType("OverheadRateType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Wc)
                    .IsRequired()
                    .HasColumnName("wc")
                    .HasColumnType("WcType")
                    .HasMaxLength(6);

                entity.Property(e => e.WipAmt)
                    .HasColumnName("wip_amt")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipFovhdAmt)
                    .HasColumnName("wip_fovhd_amt")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipLbrAmt)
                    .HasColumnName("wip_lbr_amt")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipMatlAmt)
                    .HasColumnName("wip_matl_amt")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipOutAmt)
                    .HasColumnName("wip_out_amt")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WipVovhdAmt)
                    .HasColumnName("wip_vovhd_amt")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Yield)
                    .HasColumnName("yield")
                    .HasColumnType("YieldType")
                    .HasDefaultValueSql("((100.0))");

                entity.HasOne(d => d.JobNavigation)
                    .WithMany(p => p.Jobroute)
                    .HasForeignKey(d => new { d.Job, d.Suffix })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobrouteFk1");
            });

            modelBuilder.Entity<LotLoc>(entity =>
            {
                entity.HasKey(e => new { e.Whse, e.Item, e.Lot, e.Loc });

                entity.ToTable("lot_loc");

                entity.HasIndex(e => e.Item);

                entity.HasIndex(e => e.Loc)
                    .HasName("IX_lot_loc_loc_only");

                entity.HasIndex(e => e.Lot);

                entity.HasIndex(e => e.RowPointer)
                    .HasName("IX_lot_loc_RowPointer")
                    .IsUnique();

                entity.HasIndex(e => new { e.Whse, e.Item, e.Loc })
                    .HasName("IX_lot_loc_loc");

                entity.Property(e => e.Whse)
                    .HasColumnName("whse")
                    .HasColumnType("WhseType")
                    .HasMaxLength(4);

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasColumnType("ItemType")
                    .HasMaxLength(30);

                entity.Property(e => e.Lot)
                    .HasColumnName("lot")
                    .HasColumnType("LotType")
                    .HasMaxLength(15);

                entity.Property(e => e.Loc)
                    .HasColumnName("loc")
                    .HasColumnType("LocType")
                    .HasMaxLength(15);

                entity.Property(e => e.AssignedToBePickedQty)
                    .HasColumnName("assigned_to_be_picked_qty")
                    .HasColumnType("QtyUnitType");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.FovhdCost)
                    .HasColumnName("fovhd_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InWorkflow)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.LastCountQtyOnHand)
                    .HasColumnName("last_count_qty_on_hand")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastCountQtyRsvd)
                    .HasColumnName("last_count_qty_rsvd")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LbrCost)
                    .HasColumnName("lbr_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MatlCost)
                    .HasColumnName("matl_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NoteExistsFlag)
                    .HasColumnType("FlagNyType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.OutCost)
                    .HasColumnName("out_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyContained)
                    .HasColumnName("qty_contained")
                    .HasColumnType("QtyUnitNoNegType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyOnHand)
                    .HasColumnName("qty_on_hand")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.QtyRsvd)
                    .HasColumnName("qty_rsvd")
                    .HasColumnType("QtyUnitType")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("CurrentDateType")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowPointer)
                    .HasColumnType("RowPointerType")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UnitCost)
                    .HasColumnName("unit_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasColumnType("UsernameType")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.VovhdCost)
                    .HasColumnName("vovhd_cost")
                    .HasColumnType("CostPrcType")
                    .HasDefaultValueSql("((0))");
            });
        }
    }
}

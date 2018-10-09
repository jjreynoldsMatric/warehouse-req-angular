using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WarehouseReqs.Models
{
    public partial class WarehouseRequisitionContext : DbContext
    {
        public WarehouseRequisitionContext()
        {
        }

        public WarehouseRequisitionContext(DbContextOptions<WarehouseRequisitionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ReasonCode> ReasonCode { get; set; }
        public virtual DbSet<Requisition> Requisition { get; set; }
        public virtual DbSet<RequisitionItem> RequisitionItem { get; set; }
        public virtual DbSet<RequisitionItemActions> RequisitionItemActions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=SLDB1;Database=WarehouseRequisition;User Id=sa;Password=$yt3LinE;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReasonCode>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("reason_code");

                entity.Property(e => e.Code)
                    .HasColumnName("reasonCode")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WhseAction)
                    .IsRequired()
                    .HasColumnName("whseAction")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Requisition>(entity =>
            {
                entity.ToTable("requisition");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Employee)
                    .IsRequired()
                    .HasColumnName("employee")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Job)
                    .HasColumnName("job")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<RequisitionItem>(entity =>
            {
                entity.ToTable("requisition_item");

                entity.HasIndex(e => e.RequisitionId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Backflush).HasColumnName("backflush");

                entity.Property(e => e.CycleCounted).HasColumnName("cycle_counted");

                entity.Property(e => e.Filled).HasColumnName("filled");

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemDescription)
                    .HasColumnName("item_description")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Lot)
                    .HasColumnName("lot")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LotTracked).HasColumnName("lot_tracked");

                entity.Property(e => e.Operation)
                    .HasColumnName("operation")
                    .HasMaxLength(250);

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(20, 8)");

                entity.Property(e => e.QuantityFilled)
                    .HasColumnName("quantity_filled")
                    .HasColumnType("decimal(20, 8)");

                entity.Property(e => e.ReasonCode)
                    .HasColumnName("reasonCode")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RequisitionId).HasColumnName("requisition_id");

                entity.Property(e => e.SerialTracked).HasColumnName("serial_tracked");

                entity.Property(e => e.Totalcost)
                    .HasColumnName("totalcost")
                    .HasColumnType("decimal(20, 8)");

                entity.Property(e => e.Unitcost)
                    .HasColumnName("unitcost")
                    .HasColumnType("decimal(20, 8)");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

            });

            modelBuilder.Entity<RequisitionItemActions>(entity =>
            {
                entity.ToTable("requisition_item_actions");

                entity.HasIndex(e => e.RequisitionitemId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasColumnName("action")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActionBy)
                    .IsRequired()
                    .HasColumnName("actionBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ActionDate)
                    .HasColumnName("actionDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(20, 8)");

                entity.Property(e => e.RequisitionitemId).HasColumnName("requisitionitem_id");

                entity.HasOne(d => d.Requisitionitem)
                    .WithMany(p => p.RequisitionItemActions)
                    .HasForeignKey(d => d.RequisitionitemId);
            });
        }
    }
}

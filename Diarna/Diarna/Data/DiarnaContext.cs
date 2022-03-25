using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Diarna.Data.Domain;

#nullable disable

namespace Diarna.Data
{
    public partial class DiarnaContext : DbContext
    {
        public DiarnaContext()
        {
        }

        public DiarnaContext(DbContextOptions<DiarnaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAuthorization> TblAuthorizations { get; set; }
        public virtual DbSet<TblBuilding> TblBuildings { get; set; }
        public virtual DbSet<TblContractingExpnse> TblContractingExpnses { get; set; }
        public virtual DbSet<TblContractingImport> TblContractingImports { get; set; }
        public virtual DbSet<TblItem> TblItems { get; set; }
        public virtual DbSet<TblItemType> TblItemTypes { get; set; }
        public virtual DbSet<TblMonthlyFiltring> TblMonthlyFiltrings { get; set; }
        public virtual DbSet<TblRentExpense> TblRentExpenses { get; set; }
        public virtual DbSet<TblRentUser> TblRentUsers { get; set; }
        public virtual DbSet<TblRentedUnit> TblRentedUnits { get; set; }
        public virtual DbSet<TblReservation> TblReservations { get; set; }
        public virtual DbSet<TblReservationDate> TblReservationDates { get; set; }
        public virtual DbSet<TblShare> TblShares { get; set; }
        public virtual DbSet<TblSystemUser> TblSystemUsers { get; set; }
        public virtual DbSet<TblSystemUserAuthorization> TblSystemUserAuthorizations { get; set; }
        public virtual DbSet<TblTender> TblTenders { get; set; }
        public virtual DbSet<TblTenderShare> TblTenderShares { get; set; }
        public virtual DbSet<TblUnit> TblUnits { get; set; }
        public virtual DbSet<TblUnitsShare> TblUnitsShares { get; set; }
        public virtual DbSet<TblUserShare> TblUserShares { get; set; }
        public virtual DbSet<TblVillage> TblVillages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAuthorization>(entity =>
            {
                entity.ToTable("tbl_authorization");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ScreenName)
                    .HasMaxLength(200)
                    .HasColumnName("screenName");
            });

            modelBuilder.Entity<TblBuilding>(entity =>
            {
                entity.ToTable("tbl_building");

                entity.HasIndex(e => e.Name, "uniqueNameForBuilding")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.VillageId).HasColumnName("village_id");

                entity.HasOne(d => d.Village)
                    .WithMany(p => p.TblBuildings)
                    .HasForeignKey(d => d.VillageId)
                    .HasConstraintName("FK_tbl_building_tbl_village1");
            });

            modelBuilder.Entity<TblContractingExpnse>(entity =>
            {
                entity.ToTable("tbl_contractingExpnses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Remarks).HasColumnName("remarks");

                entity.Property(e => e.TenderId).HasColumnName("tender_id");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("unitPrice");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblContractingExpnses)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_tbl_contractingExpnses_tbl_item1");

                entity.HasOne(d => d.Tender)
                    .WithMany(p => p.TblContractingExpnses)
                    .HasForeignKey(d => d.TenderId)
                    .HasConstraintName("FK_tbl_contractingExpnses_tbl_tenders1");
            });

            modelBuilder.Entity<TblContractingImport>(entity =>
            {
                entity.ToTable("tbl_contractingImports");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Remarks).HasColumnName("remarks");

                entity.Property(e => e.TenderId).HasColumnName("tender_id");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("unitPrice");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblContractingImports)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_tbl_contractingImports_tbl_item1");

                entity.HasOne(d => d.Tender)
                    .WithMany(p => p.TblContractingImports)
                    .HasForeignKey(d => d.TenderId)
                    .HasConstraintName("FK_tbl_contractingImports_tbl_tenders1");
            });

            modelBuilder.Entity<TblItem>(entity =>
            {
                entity.ToTable("tbl_item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GeneralExpenses).HasColumnName("generalExpenses");

                entity.Property(e => e.ItemtypeId).HasColumnName("itemtype_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.HasOne(d => d.Itemtype)
                    .WithMany(p => p.TblItems)
                    .HasForeignKey(d => d.ItemtypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tbl_item_tbl_itemType");
            });

            modelBuilder.Entity<TblItemType>(entity =>
            {
                entity.ToTable("tbl_itemType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TblMonthlyFiltring>(entity =>
            {
                entity.HasKey(e => new { e.UnitId, e.Date });

                entity.ToTable("tbl_monthlyFiltring");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("value");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.TblMonthlyFiltrings)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_monthlyFiltring_tbl_units1");
            });

            modelBuilder.Entity<TblRentExpense>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.Date, e.UnitId });

                entity.ToTable("tbl_rentExpenses");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.ItemValue)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("itemValue");

                entity.Property(e => e.Remarks).HasColumnName("remarks");

                entity.Property(e => e.SharesId).HasColumnName("Shares_id");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblRentExpenses)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_rentExpenses_tbl_item1");

                entity.HasOne(d => d.Shares)
                    .WithMany(p => p.TblRentExpenses)
                    .HasForeignKey(d => d.SharesId)
                    .HasConstraintName("FK_tbl_rentExpenses_tbl_shares1");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.TblRentExpenses)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_rentExpenses_tbl_units");
            });

            modelBuilder.Entity<TblRentUser>(entity =>
            {
                entity.ToTable("tbl_rentUsers");

                entity.HasIndex(e => e.Mobile, "uniqueMobile")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(12)
                    .HasColumnName("mobile");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<TblRentedUnit>(entity =>
            {
                entity.ToTable("tbl_rentedUnits");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeliveryPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("deliveryPrice");

                entity.Property(e => e.Remarks).HasColumnName("remarks");

                entity.Property(e => e.RentEndDate)
                    .HasColumnType("date")
                    .HasColumnName("rentEndDate");

                entity.Property(e => e.RentStartDate)
                    .HasColumnType("date")
                    .HasColumnName("rentStartDate");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.TblRentedUnits)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_tbl_RentedUnits_tbl_units");
            });

            modelBuilder.Entity<TblReservation>(entity =>
            {
                entity.HasKey(e => new { e.UnitId, e.DateId });

                entity.ToTable("tbl_reservation");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.DateId).HasColumnName("date_id");

                entity.Property(e => e.ConfirmReservation).HasColumnName("confirmReservation");

                entity.Property(e => e.DepositValue)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("depositValue");

                entity.Property(e => e.InsuranceValue)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("insuranceValue");

                entity.Property(e => e.Remarks).HasColumnName("remarks");

                entity.Property(e => e.RentUserId).HasColumnName("rentUser_id");

                entity.Property(e => e.TotalValue)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("totalValue");

                entity.HasOne(d => d.Date)
                    .WithMany(p => p.TblReservations)
                    .HasForeignKey(d => d.DateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_reservation_tbl_reservationDate1");

                entity.HasOne(d => d.RentUser)
                    .WithMany(p => p.TblReservations)
                    .HasForeignKey(d => d.RentUserId)
                    .HasConstraintName("FK_tbl_reservation_tbl_RentUsers");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.TblReservations)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_reservation_tbl_units1");
            });

            modelBuilder.Entity<TblReservationDate>(entity =>
            {
                entity.ToTable("tbl_reservationDate");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");
            });

            modelBuilder.Entity<TblShare>(entity =>
            {
                entity.ToTable("tbl_shares");

                entity.HasIndex(e => e.Name, "UniqueSharesName")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionProfit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("additionProfit");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

                entity.Property(e => e.ManagePercent).HasColumnName("managePercent");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Percent).HasColumnName("percent");

                entity.Property(e => e.ShareType).HasColumnName("shareType");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");

                entity.Property(e => e.UserCash)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("userCash");

                entity.Property(e => e.UserMinProfit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("userMinProfit");

                entity.Property(e => e.UserSharesId).HasColumnName("userShares_id");

                entity.HasOne(d => d.UserShares)
                    .WithMany(p => p.TblShares)
                    .HasForeignKey(d => d.UserSharesId)
                    .HasConstraintName("FK_tbl_shares_tbl_userShares1");
            });

            modelBuilder.Entity<TblSystemUser>(entity =>
            {
                entity.ToTable("tbl_systemUsers");

                entity.HasIndex(e => e.Mobile, "uniqueSysUserMobile")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(12)
                    .HasColumnName("mobile");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .HasColumnName("password");

                entity.Property(e => e.SuperAdmin).HasColumnName("superAdmin");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<TblSystemUserAuthorization>(entity =>
            {
                entity.HasKey(e => new { e.SysUserId, e.AuthId });

                entity.ToTable("tbl_systemUser_authorization");

                entity.Property(e => e.SysUserId).HasColumnName("sysUser_id");

                entity.Property(e => e.AuthId).HasColumnName("auth_id");

                entity.HasOne(d => d.Auth)
                    .WithMany(p => p.TblSystemUserAuthorizations)
                    .HasForeignKey(d => d.AuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_systemUser_authorization_tbl_authorization");

                entity.HasOne(d => d.SysUser)
                    .WithMany(p => p.TblSystemUserAuthorizations)
                    .HasForeignKey(d => d.SysUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_systemUser_authorization_tbl_systemUsers");
            });

            modelBuilder.Entity<TblTender>(entity =>
            {
                entity.ToTable("tbl_tenders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(300)
                    .HasColumnName("name");

                entity.Property(e => e.TatalPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tatalPrice");
            });

            modelBuilder.Entity<TblTenderShare>(entity =>
            {
                entity.HasKey(e => new { e.TenderId, e.Year, e.SharesId })
                    .HasName("PK_tbl_tender_userShares");

                entity.ToTable("tbl_tender_Shares");

                entity.Property(e => e.TenderId).HasColumnName("tender_id");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.Property(e => e.SharesId).HasColumnName("shares_id");

                entity.Property(e => e.SharePercentage).HasColumnName("sharePercentage");

                entity.HasOne(d => d.Shares)
                    .WithMany(p => p.TblTenderShares)
                    .HasForeignKey(d => d.SharesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_tender_userShares_tbl_shares1");

                entity.HasOne(d => d.Tender)
                    .WithMany(p => p.TblTenderShares)
                    .HasForeignKey(d => d.TenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_tender_userShares_tbl_tenders1");
            });

            modelBuilder.Entity<TblUnit>(entity =>
            {
                entity.ToTable("tbl_units");

                entity.HasIndex(e => e.Name, "uniqueNameForUnits")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.IsValid).HasColumnName("isValid");

                entity.Property(e => e.MinDepositValue)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("minDepositValue");

                entity.Property(e => e.MinInsuranceValue)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("minInsuranceValue");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Remarks).HasColumnName("remarks");

                entity.Property(e => e.SystemOwned).HasColumnName("systemOwned");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.TblUnits)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("FK_tbl_units_tbl_building1");
            });

            modelBuilder.Entity<TblUnitsShare>(entity =>
            {
                entity.HasKey(e => new { e.UnitId, e.Year, e.SharesId })
                    .HasName("PK_tbl_userShares_units");

                entity.ToTable("tbl_units_Shares");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.Property(e => e.SharesId).HasColumnName("shares_id");

                entity.HasOne(d => d.Shares)
                    .WithMany(p => p.TblUnitsShares)
                    .HasForeignKey(d => d.SharesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_userShares_units_tbl_shares1");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.TblUnitsShares)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_userShares_units_tbl_units1");
            });

            modelBuilder.Entity<TblUserShare>(entity =>
            {
                entity.ToTable("tbl_userShares");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthId).HasColumnName("auth_id");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(12)
                    .HasColumnName("mobile");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .HasColumnName("password");

                entity.HasOne(d => d.Auth)
                    .WithMany(p => p.TblUserShares)
                    .HasForeignKey(d => d.AuthId)
                    .HasConstraintName("FK_tbl_userShares_tbl_authorization");
            });

            modelBuilder.Entity<TblVillage>(entity =>
            {
                entity.ToTable("tbl_village");

                entity.HasIndex(e => e.Name, "uniqueNameForVillage")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

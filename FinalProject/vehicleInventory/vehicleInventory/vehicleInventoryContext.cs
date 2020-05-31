using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace vehicleInventory
{
    public partial class vehicleInventoryContext : DbContext
    {
        public vehicleInventoryContext()
        {
        }

        public vehicleInventoryContext(DbContextOptions<vehicleInventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Vehicles> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=vehicleInventory;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.HasKey(e => e.VehicleID);

                entity.ToTable("vehicles");

                entity.Property(e => e.VehicleID).HasColumnName("vehicleID");

                entity.Property(e => e.DealerCertified).HasColumnName("dealerCertified");

                entity.Property(e => e.Make).HasMaxLength(50);

                entity.Property(e => e.Mileage).HasColumnName("mileage");

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.MSRP).HasColumnName("MSRP");

                entity.Property(e => e.SellingPrice).HasColumnName("sellingPrice");

                entity.Property(e => e.StockNumber)
                    .HasColumnName("stockNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Trim).HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.VehicleType)
                    .HasColumnName("vehicleType")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.VIN)
                    .HasColumnName("VIN")
                    .HasMaxLength(17);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

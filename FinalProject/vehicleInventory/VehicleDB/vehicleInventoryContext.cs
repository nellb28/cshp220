using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VehicleDB
{
    public partial class VehicleInventoryContext : DbContext
    {
        public VehicleInventoryContext()
        {
        }

        public VehicleInventoryContext(DbContextOptions<VehicleInventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Vehicle> Vehicle { get; set; }

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
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.VehicleID);

                entity.ToTable("vehicles");

                entity.Property(e => e.VehicleID).HasColumnName("vehicleID");

                entity.Property(e => e.VehicleDealerCertified).HasColumnName("dealerCertified");

                entity.Property(e => e.VehicleMake)
                    .HasColumnName("make")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleMileage).HasColumnName("mileage");

                entity.Property(e => e.VehicleModel)
                    .HasColumnName("model")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleMSRP).HasColumnName("MSRP");

                entity.Property(e => e.VehicleSellingPrice).HasColumnName("sellingPrice");

                entity.Property(e => e.VehicleStockNumber)
                    .HasColumnName("stockNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleTrim)
                    .HasColumnName("trim")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleType)
                    .HasColumnName("type")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.VehicleType)
                    .HasColumnName("vehicleType")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.VehicleVIN)
                    .HasColumnName("VIN")
                    .HasMaxLength(17);

                entity.Property(e => e.VehicleYear).HasColumnName("year");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

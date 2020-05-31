using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VehicleDB
{
    public partial class VehiclesContext : DbContext
    {
        public VehiclesContext()
        {
        }

        public VehiclesContext(DbContextOptions<VehiclesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Vehicles> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Vehicles;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.HasKey(e => e.VehicleId);

                entity.ToTable("vehicles");

                entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

                entity.Property(e => e.VehicleMake).HasMaxLength(50);

                entity.Property(e => e.VehicleModel).HasMaxLength(50);

                entity.Property(e => e.VehicleMsrp).HasColumnName("VehicleMSRP");

                entity.Property(e => e.VehicleStockNumber).HasMaxLength(50);

                entity.Property(e => e.VehicleTrim).HasMaxLength(50);

                entity.Property(e => e.VehicleType)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.VehicleVin)
                    .HasColumnName("VehicleVIN")
                    .HasMaxLength(17);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BusBooking.DataAccess.Entities
{
    public partial class BusBookingContext : DbContext
    {
        public BusBookingContext()
        {
        }

        public BusBookingContext(DbContextOptions<BusBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BusBooking> BusBookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-I1G62A5\\SQLEXPRESS;Database=BusBooking;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BusBooking>(entity =>
            {
                entity.HasKey(e => e.Number)
                    .HasName("PK_BusBoooking");

                entity.ToTable("BusBooking");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

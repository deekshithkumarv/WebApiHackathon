using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusBooking.DataAccess.Entities
{
    public partial class BusDBContext : DbContext
    {
        public BusDBContext()
        {
        }

        public BusDBContext(DbContextOptions<BusDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BusBooking> BusBookings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=BusDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusBooking>(entity =>
            {
                entity.ToTable("BusBooking");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Number).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

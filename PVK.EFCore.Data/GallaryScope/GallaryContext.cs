using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.GallaryScope
{
   public class GallaryContext: DbContext
    {
        public GallaryContext()
        {

        }

        public GallaryContext(DbContextOptions<GallaryContext> options) : base(options)
        {

        }

        public virtual DbSet<TblGallary> TblGallaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblGallary>(
               entity =>
               {
                   entity.HasKey(e => e.GuidGallaryId);
                   entity.ToTable("tbl_Gallary");

                   entity.Property(e => e.GuidGallaryId)
                   .HasColumnName("Guid_Gallaryid")
                   .HasColumnType("string")
                   .IsRequired(true);

                   entity.Property(e => e.Name)
                   .HasColumnName("Name")
                   .HasColumnType("string")
                   .IsRequired(false);

                   entity.Property(e => e.Date_Inactive)
                    .HasColumnName("Date_Inactive")
                    .HasColumnType("datetime")
                    .IsRequired(false);

                   entity.Property(e => e.Date_Created)
                   .HasColumnName("Date_Created")
                   .HasColumnType("datetime")
                   .IsRequired(false);

                   entity.Property(e => e.Date_Modified)
                   .HasColumnName("Date_Modified")
                   .HasColumnType("datetime")
                   .IsRequired(false);

                   entity.Property(e => e.Uid_Modified)
                   .HasColumnName("Uid_Modified")
                   .HasColumnType("string")
                   .IsRequired(false);

                   entity.Property(e => e.Uid_Created)
                   .HasColumnName("Uid_Created")
                   .HasColumnType("string")
                   .IsRequired(false);

               });
        }
    }
}

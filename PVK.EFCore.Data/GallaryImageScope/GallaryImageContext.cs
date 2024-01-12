using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace PVK.EFCore.Data.GallaryImageScope
{
    public class GallaryImageContext : DbContext
    {
        public GallaryImageContext()
        {

        }

        public GallaryImageContext(DbContextOptions<GallaryImageContext> options) : base(options)
        {

        }

        public virtual DbSet<TblGallaryImage> TblGallaryImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblGallaryImage>(
               entity =>
               {
                   entity.HasKey(e => e.GuidGallaryimageid);
                   entity.ToTable("tbl_GallaryImage");

                   entity.Property(e => e.GuidGallaryimageid)
                   .HasColumnName("Guid_Gallaryimageid")
                   .HasColumnType("string")
                   .IsRequired(true);

                   entity.Property(e => e.GuidGallaryid)
                   .HasColumnName("Guid_Gallaryid")
                   .HasColumnType("string")
                   .IsRequired(true);

                   entity.Property(e => e.ImageUrl)
                   .HasColumnName("Image_Url")
                   .HasColumnType("string")
                   .IsRequired(false);

                   entity.Property(e => e.IsPrimery)
                   .HasColumnName("Is_Primery")
                   .HasColumnType("bit");
              

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

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace PVK.EFCore.Data.GallaryVideoScope
{
    public class GallaryVideoContext : DbContext
    {
        public GallaryVideoContext()
        {

        }

        public GallaryVideoContext(DbContextOptions<GallaryVideoContext> options) : base(options)
        {

        }
        public virtual DbSet<TblGallaryVideo> TblGallaryVideos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblGallaryVideo>(
               entity =>
               {
                   entity.HasKey(e => e.GuidGallaryvideoid);
                   entity.ToTable("tbl_GallaryVideo");

                   entity.Property(e => e.GuidGallaryvideoid)
                   .HasColumnName("Guid_Gallaryvideoid")
                   .HasColumnType("string")
                   .IsRequired(true);

                   entity.Property(e => e.GuidGallaryid)
                   .HasColumnName("Guid_Gallaryid")
                   .HasColumnType("string")
                   .IsRequired(false);

                   entity.Property(e => e.videourl)
                   .HasColumnName("videourl")
                   .HasColumnType("string")
                   .IsRequired(false);

                   entity.Property(e => e.IsPrimery)
                   .HasColumnName("Is_Primery")
                   .HasColumnType("bool");
                   

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

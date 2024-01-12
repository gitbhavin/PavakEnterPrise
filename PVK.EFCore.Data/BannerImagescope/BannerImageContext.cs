using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.BannerImagescope
{
    public class BannerImageContext: DbContext
    {
        public BannerImageContext()
        {

        }
        public BannerImageContext(DbContextOptions<BannerImageContext> options) : base(options)
        {

        }
        public virtual DbSet<TblBannerImage> TblBannerImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBannerImage>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_BannerImageId);

                    entity.ToTable("tbl_BannerImage");

                    entity.Property(e => e.Guid_BannerId)
                    .HasColumnName("Guid_BannerId")
                    .HasColumnType("string")
                    .IsRequired(true);

                    entity.Property(e => e.Image_Url)
                    .HasColumnName("Image_Url")
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

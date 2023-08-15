using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.BannerScope
{
    public class BannerContext : DbContext
    {
        public BannerContext()
        {

        }
        public BannerContext(DbContextOptions<BannerContext> options) : base(options)
        {

        }
        public virtual DbSet<TblBanner> TblBanners { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBanner>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_BannerId);

                    entity.ToTable("tbl_Banner");

                    entity.Property(e => e.Guid_BannerId)
                    .HasColumnName("Guid_BannerId")
                    .HasColumnType("string")
                    .IsRequired(true);

                    entity.Property(e => e.PageName)
                    .HasColumnName("PageName")
                    .HasColumnType("string")
                    .IsRequired(false);


                    entity.Property(e => e.SectionName)
                    .HasColumnName("SectionName")
                    .HasColumnType("string");

                    entity.Property(e => e.Order_Sequence)
                   .HasColumnName("Order_Sequence")
                   .HasColumnType("int");

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

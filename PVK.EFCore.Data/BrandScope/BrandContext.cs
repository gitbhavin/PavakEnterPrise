using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.BrandScope
{
    public class BrandContext : DbContext
    {
        public BrandContext()
        {

        }

        public BrandContext(DbContextOptions<BrandContext> options) : base(options)
        {

        }

        public virtual DbSet<TblBrand> TblBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBrand>(
                entity =>
                {
                    entity.HasKey(e => e.GuidBrandId);

                    entity.ToTable("tblbrands");

                    entity.Property(e => e.GuidBrandId)
                    .HasColumnName("Guid_BrandId")
                    .HasColumnType("string")
                    .IsRequired(true);

                    entity.Property(e => e.BrandName)
                    .HasColumnName("BrandName")
                    .HasColumnType("string");
                });
        }
    }
}

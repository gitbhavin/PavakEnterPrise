using Microsoft.EntityFrameworkCore;
using PVK.EFCore.Data.UserScope;
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

                    entity.ToTable("tbl_Brand");

                    entity.Property(e => e.GuidBrandId)
                    .HasColumnName("Guid_BrandId")
                    .HasColumnType("string")
                    .IsRequired(true);

                    entity.Property(e => e.BrandName)
                    .HasColumnName("Brand_Name")
                    .HasColumnType("string")
                    .IsRequired(false); ;

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

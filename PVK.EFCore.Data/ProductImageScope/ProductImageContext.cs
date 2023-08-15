using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.ProductImageScope
{
  public  class ProductImageContext: DbContext
    {
        public ProductImageContext()
        {

        }
        public ProductImageContext(DbContextOptions<ProductImageContext> options) : base(options)
        {

        }
        public virtual DbSet<TblProductImage> TblProductImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblProductImage>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_ProductImageId);

                    entity.ToTable("tbl_ProductImage");

                    entity.Property(e => e.Guid_ProductId)
                    .HasColumnName("Guid_ProductId")
                    .HasColumnType("string")
                    .IsRequired(true);                

                    entity.Property(e => e.Image_Url)
                    .HasColumnName("Image_Url")
                    .HasColumnType("string");
                   

                    entity.Property(e => e.Is_Primary)
                    .HasColumnName("Is_Primary")
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

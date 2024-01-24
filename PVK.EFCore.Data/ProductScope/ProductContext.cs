using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.ProductScope
{
   public class ProductContext : DbContext
    {
        public ProductContext()
        {

        }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        public virtual DbSet<TblProduct> TblProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


         
            modelBuilder.Entity<TblProduct>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_ProductId);

                    entity.ToTable("tbl_Product");

                    entity.Property(e => e.Guid_CategoryId)
                    .HasColumnName("Guid_CategoryId")
                    .HasColumnType("string");

                    entity.Property(e => e.Guid_SubCategoryId)
                    .HasColumnName("Guid_SubCategoryId")
                    .HasColumnType("string")
                    .IsRequired(false);


                    entity.Property(e => e.Guid_SubSubCategoryId)
                    .HasColumnName("Guid_SubSubCategoryId")
                    .HasColumnType("string");

                    entity.Property(e => e.Guid_BrandId)
                   .HasColumnName("Guid_BrandId")
                   .HasColumnType("string");


                    entity.Property(e => e.ProductName)
                  .HasColumnName("ProductName")
                  .HasColumnType("string");

                    entity.Property(e => e.Price)
                  .HasColumnName("Price")
                  .HasColumnType("decimal");

                    entity.Property(e => e.Discount)
                  .HasColumnName("Discount")
                  .HasColumnType("decimal");

                    entity.Property(e => e.Available_Stock)
                 .HasColumnName("Available_Stock")
                 .HasColumnType("decimal");

                    entity.Property(e => e.Full_Description)
               .HasColumnName("Full_Description")
               .HasColumnType("string");

                    entity.Property(e => e.Thumbnail_Image_Url)
              .HasColumnName("Thumbnail_Image_Url")
              .HasColumnType("string");

                    entity.Property(e => e.Short_Description)
              .HasColumnName("Short_Description")
              .HasColumnType("string");

                    entity.Property(e => e.Is_InSale)
                    .HasColumnName("Is_InSale")
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

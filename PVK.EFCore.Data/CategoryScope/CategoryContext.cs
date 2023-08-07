using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.CategoryScope
{
   public class CategoryContext : DbContext
    {
        public CategoryContext()
        {

        }
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
        {

        }

        public virtual DbSet<TblCategory> TblCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCategory>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_CategoryId);

                    entity.ToTable("tbl_Categories");

                    entity.Property(e => e.Guid_SubCategoryId)
                    .HasColumnName("Guid_SubCategoryId")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Guid_SubSubCategoryId)
                    .HasColumnName("Guid_SubSubCategoryId")
                    .HasColumnType("string")
                    .IsRequired(false);


                    entity.Property(e => e.CategoryName)
                    .HasColumnName("CategoryName")
                    .HasColumnType("string");

                    entity.Property(e => e.CategoryImg)
                   .HasColumnName("CategoryImg")
                   .HasColumnType("string");


                    entity.Property(e => e.Description)
                  .HasColumnName("Description")
                  .HasColumnType("string");

                 

                  

                    entity.Property(e => e.IsPreorder)
              .HasColumnName("IsPreorder")
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

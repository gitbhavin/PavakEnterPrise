using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.ReviewScope
{
   public class ReviewContext : DbContext
    {
        public ReviewContext()
        {

        }
        public ReviewContext(DbContextOptions<ReviewContext> options) : base(options)
        {

        }
        public virtual DbSet<TblReview> TblReviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblReview>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_ReviewId);

                    entity.ToTable("tbl_Review");

                    entity.Property(e => e.Guid_UserId)
                    .HasColumnName("Guid_UserId")
                    .HasColumnType("string");

                    entity.Property(e => e.Guid_ProductId)
                    .HasColumnName("Guid_ProductId")
                    .HasColumnType("string")
                    .IsRequired(false);


                    entity.Property(e => e.Rating_Count)
                    .HasColumnName("Rating_Count")
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

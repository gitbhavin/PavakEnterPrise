using Microsoft.EntityFrameworkCore;
using PVK.EFCore.Data.ProductScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.OrderDetailscope
{
   public class OrderDetailContext:DbContext
    {
        public OrderDetailContext()
        {

        }
        public OrderDetailContext(DbContextOptions<OrderDetailContext> options) : base(options)
        {

        }
        public virtual DbSet<TblOrderDetail> TblOrderDetails { get; set; }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           

            modelBuilder.Entity<TblOrderDetail>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_OrderDetailsId);

                    entity.ToTable("tbl_OrderDetails");

                    entity.Property(e => e.Guid_OrderId)
                    .HasColumnName("Guid_OrderId")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Guid_ProductId)
                    .HasColumnName("Guid_ProductId")
                    .HasColumnType("string")
                    .IsRequired(false);


                    entity.Property(e => e.Price)
                    .HasColumnName("Price")
                    .HasColumnType("double");

                    entity.Property(e => e.Quantity)
                   .HasColumnName("Quantity")
                   .HasColumnType("double");


                    entity.Property(e => e.Discount_Price)
                  .HasColumnName("Discount_Price")
                  .HasColumnType("double");



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

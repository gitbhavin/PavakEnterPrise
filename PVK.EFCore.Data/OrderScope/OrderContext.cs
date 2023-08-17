using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.OrderScope
{
    public class OrderContext :DbContext
    {
        public OrderContext()
        {

        }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }
        public virtual DbSet<TblOrder> TblOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblOrder>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_OrderId);

                    entity.ToTable("tbl_Order");

                    entity.Property(e => e.Guid_UserId)
                    .HasColumnName("Guid_UserId")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Guid_PickupLocationId)
                    .HasColumnName("Guid_PickupLocationId")
                    .HasColumnType("string")
                    .IsRequired(false);


                    entity.Property(e => e.Tax)
                    .HasColumnName("Tax")
                    .HasColumnType("double");

                    entity.Property(e => e.Total)
                   .HasColumnName("Total")
                   .HasColumnType("double");


                    entity.Property(e => e.Discount)
                  .HasColumnName("Discount")
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

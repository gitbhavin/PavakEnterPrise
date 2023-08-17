using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.OrderStatusScope
{
    public class OrderStatusContext:DbContext
    {
        public OrderStatusContext()
        {

        }
        public OrderStatusContext(DbContextOptions<OrderStatusContext> options) : base(options)
        {

        }
        public virtual DbSet<TblOrderStatus> TblOrderStatuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblOrderStatus>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_OrderStatusId);

                    entity.ToTable("tbl_OrderStatus");

                    entity.Property(e => e.Guid_OrderId)
                    .HasColumnName("Guid_OrderId")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Is_PickUp)
                    .HasColumnName("Is_PickUp")
                    .HasColumnType("bool")
                    .IsRequired(false);


                    entity.Property(e => e.Status)
                    .HasColumnName("Status")
                    .HasColumnType("string");

                    entity.Property(e => e.Date_Status)
                     .HasColumnName("Date_Status")
                     .HasColumnType("datetime")
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

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.PaymentScope
{
    public class PaymentContext : DbContext
    {
        public PaymentContext()
        {

        }
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {

        }
        public virtual DbSet<TblPayment> TblPayments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblPayment>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_PaymentId);

                    entity.ToTable("tbl_Payment");

                    entity.Property(e => e.Guid_OrderId)
                    .HasColumnName("Guid_OrderId")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Guid_UserId)
                    .HasColumnName("Guid_UserId")
                    .HasColumnType("string")
                    .IsRequired(false);


                    entity.Property(e => e.Amount)
                    .HasColumnName("Amount")
                    .HasColumnType("double");

                    entity.Property(e => e.Is_Refunded)
                   .HasColumnName("Is_Refunded")
                   .HasColumnType("bool");


                    entity.Property(e => e.PaymentGateway)
                  .HasColumnName("PaymentGateway")
                  .HasColumnType("string");

                    entity.Property(e => e.TransferId)
                  .HasColumnName("TransferId")
                  .HasColumnType("string");

                    entity.Property(e => e.Date_Refunded)
                  .HasColumnName("Date_Refunded")
                  .HasColumnType("datetime");

                    entity.Property(e => e.PaymentStatus)
               .HasColumnName("PaymentStatus")
               .HasColumnType("string");
                  

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

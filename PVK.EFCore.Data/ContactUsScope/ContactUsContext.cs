using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.ContactUsScope
{
    public class ContactUsContext : DbContext
    {
        public ContactUsContext()
        {

        }
        public ContactUsContext(DbContextOptions<ContactUsContext> options) : base(options)
        {

        }

        public virtual DbSet<TblContactUs> TblContactUs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblContactUs>(
                entity =>
                {
                    entity.HasKey(e => e.GuidContactusid);
                    entity.ToTable("tbl_ContactUs");

                    entity.Property(e => e.GuidContactusid)
                    .HasColumnName("Guid_Contactusid")
                    .HasColumnType("string")
                    .IsRequired(true);

                    entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Phone)
                    .HasColumnName("Phone")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Message)
                    .HasColumnName("Message")
                    .HasColumnType("string")
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

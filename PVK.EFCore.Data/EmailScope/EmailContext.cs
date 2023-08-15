using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.EmailScope
{
    public class EmailContext : DbContext
    {
        public EmailContext()
        {

        }
        public EmailContext(DbContextOptions<EmailContext> options) : base(options)
        {

        }
        public virtual DbSet<TblEmail> TblEmails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEmail>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_Emailid);

                    entity.ToTable("tbl_Email");

                    entity.Property(e => e.FromAddress)
                    .HasColumnName("FromAddress")
                    .HasColumnType("string");

                    entity.Property(e => e.ToAddress)
                    .HasColumnName("ToAddress")
                    .HasColumnType("string")
                    .IsRequired(false);


                    entity.Property(e => e.BccAddress)
                    .HasColumnName("BccAddress")
                    .HasColumnType("string");

                    entity.Property(e => e.Subject)
                   .HasColumnName("Subject")
                   .HasColumnType("string");


                    entity.Property(e => e.Body)
                  .HasColumnName("Body")
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

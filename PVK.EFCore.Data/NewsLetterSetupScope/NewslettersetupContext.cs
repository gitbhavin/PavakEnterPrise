using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.NewsLetterSetupScope
{
   public class NewslettersetupContext : DbContext
    {
        public NewslettersetupContext()
        {

        }

        public NewslettersetupContext(DbContextOptions<NewslettersetupContext> options) : base(options)
        {

        }

        public virtual DbSet<tblNewsLetterSetup> TblNewsLetterSetups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblNewsLetterSetup>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_NewslatterId);

                    entity.ToTable("tbl_NewsLetterSetup");

                    entity.Property(e => e.EmailId)
                    .HasColumnName("EmailId")
                    .HasColumnType("string")
                    .IsRequired(true);                  

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

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.EmailTemplateScope
{
    public class EmailTemplateContext : DbContext
    {
        public EmailTemplateContext()
        {

        }
        public EmailTemplateContext(DbContextOptions<EmailTemplateContext> options) : base(options)
        {

        }
        public virtual DbSet<TblEmailTemplate> TblEmailTemplates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEmailTemplate>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_EmailTemplateid);

                    entity.ToTable("tbl_EmailTemplate");

                    entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("string");

                    entity.Property(e => e.Subject)
                    .HasColumnName("Subject")
                    .HasColumnType("string")
                    .IsRequired(false);


                    entity.Property(e => e.Code)
                    .HasColumnName("Code")
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

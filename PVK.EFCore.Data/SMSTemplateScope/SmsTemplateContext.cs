using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PVK.EFCore.Data.SMSTemplate
{
    public class SmsTemplateContext:DbContext
    {
        public SmsTemplateContext()
        {

        }

        public SmsTemplateContext(DbContextOptions<SmsTemplateContext> options): base(options)
        {

        }
        public virtual DbSet<TblSmsTemplate> TblSmsTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblSmsTemplate>(
                entity =>
                {
                    entity.HasKey(e => e.GuidSMSTemplateId);
                    entity.ToTable("tbl_SMSTemplate");

                    entity.Property(e => e.GuidSMSTemplateId)
                    .HasColumnName("Guid_SMSTemplateid")
                    .HasColumnType("string")
                    .IsRequired(true);

                    entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Code)
                    .HasColumnName("Code")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Subject)
                    .HasColumnName("Subject")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Body)
                    .HasColumnName("Body")
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

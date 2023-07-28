using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.SmsUrlScope
{
    public class SmsurlContext : DbContext
    {
        public SmsurlContext()
        {

        }

        public SmsurlContext(DbContextOptions<SmsurlContext> options) : base(options)
        {

        }
        public virtual DbSet<TblSmsurl> TblSmsurls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblSmsurl>(
                entity =>
                {
                    entity.HasKey(e => e.GuidSMSURL);
                    entity.ToTable("tbl_SMSURL");

                    entity.Property(e => e.GuidSMSURL)
                    .HasColumnName("Guid_SMSURL")
                    .HasColumnType("string")
                    .IsRequired(true);

                    entity.Property(e => e.Url)
                    .HasColumnName("Url")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.DateInactive)
                    .HasColumnName("Date_Inactive")
                    .HasColumnType("datetime")
                    .IsRequired(false);
                });
        }
    }
}

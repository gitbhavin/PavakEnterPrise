using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.RoleScope
{
    public class RoleContext : DbContext
    {
        public RoleContext()
        {

        }
        public RoleContext(DbContextOptions<RoleContext> options) : base(options)
        {

        }
        public virtual DbSet<tblRole> TblRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblRole>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_RoleId);

                    entity.ToTable("tbl_Role");

                    entity.Property(e => e.RoleName)
                    .HasColumnName("RoleName")
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

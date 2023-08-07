using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.UserRoleScope
{
   public class UserRoleContext : DbContext
    {
        public UserRoleContext()
        {

        }
        public UserRoleContext(DbContextOptions<UserRoleContext> options) : base(options)
        {

        }
        public virtual DbSet<TblUserRole> TblUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblUserRole>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_UserRoleId);

                    entity.ToTable("tbl_UserRole");

                    entity.Property(e => e.Guid_UserId)
                  .HasColumnName("Guid_UserId")
                  .HasColumnType("string")
                  .IsRequired(true);

                    entity.Property(e => e.Guid_RoleId)
                    .HasColumnName("Guid_RoleId")
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

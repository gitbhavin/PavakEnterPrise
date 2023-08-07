using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.UserScope
{
   public class UserContext : DbContext
    {
        public UserContext()
        {

        }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public virtual DbSet<TblUser> TblUsers { get; set; }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblUser>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_Userid);

                    entity.ToTable("tbl_User");

                    entity.Property(e => e.Guid_Userid)
                    .HasColumnName("Guid_Userid")
                    .HasColumnType("string")
                    .IsRequired(true);

                    entity.Property(e => e.VersionId)
                    .HasColumnName("VersionId")
                    .HasColumnType("int")
                    .IsRequired(false);
                    

                    entity.Property(e => e.FirstName)
                    .HasColumnName("FirstName")
                    .HasColumnType("string");

                    entity.Property(e => e.LastName)
                   .HasColumnName("LastName")
                   .HasColumnType("string");


                    entity.Property(e => e.Email)
                  .HasColumnName("Email")
                  .HasColumnType("string");

                    entity.Property(e => e.Phone)
                  .HasColumnName("Phone")
                  .HasColumnType("string");

                    entity.Property(e => e.UserName)
                  .HasColumnName("UserName")
                  .HasColumnType("string");

                    entity.Property(e => e.Password)
               .HasColumnName("Password")
               .HasColumnType("string");

                    entity.Property(e => e.IMG_URL)
              .HasColumnName("IMG_URL")
              .HasColumnType("string");

                    entity.Property(e => e.Gender)
              .HasColumnName("Gender")
              .HasColumnType("string");

                    entity.Property(e => e.Source)
                    .HasColumnName("Source")
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

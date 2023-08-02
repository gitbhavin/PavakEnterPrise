using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.TokenScope
{
   public class TokenContext : DbContext
    {
        public TokenContext()
        {

        }
        public TokenContext(DbContextOptions<TokenContext> options) : base(options)
        {

        }
      
        public virtual DbSet<UserToken> UserTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            modelBuilder.Entity<UserToken>(
             entity =>
             {
                 entity.HasKey(e => e.Guid_UserTokenId);

                 entity.ToTable("tbl_UserToken");

                 entity.Property(e => e.Guid_UserTokenId)
                 .HasColumnName("Guid_UserTokenId")
                 .HasColumnType("string")
                 .IsRequired(true);

                 entity.Property(e => e.Guid_UserId)
                 .HasColumnName("Guid_UserId")
                 .HasColumnType("string")
                 .IsRequired(false);


                 entity.Property(e => e.AccessToken)
                 .HasColumnName("AccessToken")
                 .HasColumnType("string");

                 entity.Property(e => e.RefreshToken)
                .HasColumnName("RefreshToken")
                .HasColumnType("string");


                 entity.Property(e => e.AccessToken_Expiry)
               .HasColumnName("AccessToken_Expiry")
               .HasColumnType("DateTimeOffset");

                 entity.Property(e => e.RefreshToken_Expiry)
               .HasColumnName("RefreshToken_Expiry")
               .HasColumnType("DateTimeOffset");



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
               .HasColumnType("datetime")
               .IsRequired(false);

             });
        }
    }
}


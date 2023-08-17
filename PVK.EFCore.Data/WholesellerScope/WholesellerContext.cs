using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.WholesellerScope
{
   public class WholesellerContext: DbContext
    {
        public WholesellerContext()
        {

        }
        public WholesellerContext(DbContextOptions<WholesellerContext> options) : base(options)
        {

        }
        public virtual DbSet<TblWholeseller> TblWholesellers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblWholeseller>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_Wholesellerid);

                    entity.ToTable("tbl_Wholeseller");

                    entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasColumnType("string");

                    entity.Property(e => e.Phonenumber)
                    .HasColumnName("Phonenumber")
                    .HasColumnType("string")
                    .IsRequired(false);


                    entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .HasColumnType("string");

                    entity.Property(e => e.Message)
                   .HasColumnName("Message")
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

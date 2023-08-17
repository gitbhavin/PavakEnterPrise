using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.AddressScope
{
   public class AddressContext: DbContext
    {
        public AddressContext()
        {

        }

        public AddressContext(DbContextOptions<AddressContext> options) : base(options)
        {

        }

        public virtual DbSet<TblAddress> TblAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAddress>(
                entity =>
                {
                    entity.HasKey(e => e.GuidAddressId);
                    entity.ToTable("tbl_Address");

                    entity.Property(e => e.GuidAddressId)
                    .HasColumnName("Guid_AddressId")
                    .HasColumnType("string")
                    .IsRequired(true);

                    entity.Property(e => e.VersionId)
                    .HasColumnName("VersionId")
                    .HasColumnType("int");
                    

                    entity.Property(e => e.FirstName)
                    .HasColumnName("FirstName")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.LastName)
                    .HasColumnName("LastName")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Phone)
                    .HasColumnName("Phone")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Address1)
                    .HasColumnName("Address1")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Address2)
                    .HasColumnName("Address2")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.City)
                    .HasColumnName("City")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.State)
                    .HasColumnName("State")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Zipcode)
                    .HasColumnName("Zipcode")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.Country)
                    .HasColumnName("Country")
                    .HasColumnType("string")
                    .IsRequired(false);

                    entity.Property(e => e.IsDefault)
                    .HasColumnName("Is_Default")
                    .HasColumnType("bool");
                    

                    entity.Property(e => e.IsBilling)
                    .HasColumnName("Is_Billing")
                    .HasColumnType("bool");



                    entity.Property(e => e.IsDelivery)
                    .HasColumnName("Is_Delivery")
                    .HasColumnType("bool");


                    entity.Property(e => e.Latitude)
                    .HasColumnName("Latitude")
                    .HasColumnType("decimal(10,6)");



                    entity.Property(e => e.Longitude)
                    .HasColumnName("Longitude")
                    .HasColumnType("decimal(10,6)");
                    

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

using Microsoft.EntityFrameworkCore;
using PVK.EFCore.Data.BaseScope;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVK.EFCore.Data.PickupLocationScope
{
    public class PickupLocationContext : DbContext
    {

        public PickupLocationContext()
        {

        }
        public PickupLocationContext(DbContextOptions<PickupLocationContext> options) : base(options)
        {

        }
        public virtual DbSet<TblPickupLocation> TblPickupLocations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblPickupLocation>(
                entity =>
                {
                    entity.HasKey(e => e.Guid_PickupLocationId);

                    entity.ToTable("tbl_PickUpLocation");

                    entity.Property(e => e.Address1)
                    .HasColumnName("Address1")
                    .HasColumnType("string");
                    


                    entity.Property(e => e.Address2)
                    .HasColumnName("Address2")
                    .HasColumnType("string");

                    entity.Property(e => e.City)
                   .HasColumnName("City")
                   .HasColumnType("string");


                    entity.Property(e => e.CityName)
                  .HasColumnName("CityName")
                  .HasColumnType("string");

                    entity.Property(e => e.Latitude)
                  .HasColumnName("Latitude")
                  .HasColumnType("double");

                    entity.Property(e => e.Longitude)
                  .HasColumnName("Longitude")
                  .HasColumnType("double");

                    entity.Property(e => e.Zipcode)
               .HasColumnName("Zipcode")
               .HasColumnType("string");

                    entity.Property(e => e.Country)
              .HasColumnName("Country")
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

using Microsoft.EntityFrameworkCore;
using PVK.EFCore.Data.BrandScope;
using PVK.EFCore.Data.UserScope;
using System;
using System.Collections.Generic;
using System.Text;


namespace PVK.EFCore.Data.UnitScope
{
    public class UnitContext : DbContext
    {
        public UnitContext()
        {

        }

        public UnitContext(DbContextOptions<UnitContext> options) : base(options)
        {

        }

        public virtual DbSet<TblUnit> TblUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblUnit>(
                entity =>
                {
                    entity.HasKey(e => e.unitguid);

                    entity.ToTable("tbl_Unit");

                    entity.Property(e => e.unitguid)
                    .HasColumnName("unitguid")
                    .HasColumnType("string")
                    .IsRequired(true);

                    entity.Property(e => e.unitname)
                    .HasColumnName("unitname")
                    .HasColumnType("string")
                    .IsRequired(false); 

                   
                });


        }
    }
}

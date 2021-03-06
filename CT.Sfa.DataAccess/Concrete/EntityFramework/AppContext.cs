﻿using CT.Sfa.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CT.Sfa.DataAccess.Concrete.EntityFramework
{
    public class AppContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(@"User Id=DSS;Password=teneke;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.55.5.148)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=MOBMVCT)));");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {
            modelBuilder.HasDefaultSchema("DSS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId).HasName("PK_ID_MAMUL");
                entity.ToTable("LU_MAMUL");
                entity.Property(e=>e.ProductId).HasColumnName("ID_MAMUL");
                entity.Property(e => e.ProductName).HasColumnName("DS_MAMUL");
                entity.Property(e => e.ProductNo).HasColumnName("MAMUL_NO");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.MenuId).HasName("PK_ID_CEM_MENU");
                entity.ToTable("CEM_MENU");
                entity.Property(e => e.MenuId).HasColumnName("MENU_ID");
                entity.Property(e => e.MenuName).HasColumnName("MENU_NAME");
                entity.Property(e => e.ParentMenu).HasColumnName("PARENT_MENU");
                entity.Property(e => e.Controller).HasColumnName("CONTROLLER");
                entity.Property(e => e.Action).HasColumnName("ACTION");
                entity.Property(e => e.RowNumber).HasColumnName("ROW_NUMBER");
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Menu> Menus { get; set; }

    }
}

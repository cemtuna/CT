using CT.Sfa.Entities.Concrete;
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
                entity.HasKey(e => e.ID_MAMUL).HasName("PK_ID_MAMUL");
                entity.ToTable("LU_MAMUL");

            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

    }
}

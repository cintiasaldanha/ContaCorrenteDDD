using Microsoft.EntityFrameworkCore;
using ContaCorrenteDDD.Domain.Entities;
using ContaCorrenteDDD.Infra.Data.Mapping;

namespace ContaCorrenteDDD.Infra.Data.Context
{
    public class SQLiteContext : DbContext
    {
        public DbSet<Correntista> Correntista { get; set; }
        public DbSet<ContaCorrente> ContaCorrente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Utiliza servidor SQLite local. 
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("DataSource=app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Correntista>(new CorrentistaMap().Configure);

            modelBuilder.Entity<ContaCorrente>(new ContaCorrenteMap().Configure);
        }
    }
}
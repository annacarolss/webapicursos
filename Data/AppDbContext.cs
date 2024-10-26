using ApiCursos.Estudantes;
using ApiCursos.Turmas;
using Microsoft.EntityFrameworkCore;

namespace ApiCursos.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudante>()
                .HasMany(e => e.Turmas)
                .WithMany();

            modelBuilder.Entity<Turma>()
            .HasIndex(t => t.Codigo)
            .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "Data Source=Banco.sqlite");

            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }
    }
}

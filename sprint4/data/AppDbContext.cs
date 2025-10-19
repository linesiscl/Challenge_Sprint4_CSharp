using Microsoft.EntityFrameworkCore;
using sprint4.model;
using System.Security.Principal;

namespace sprint4.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Investimento> Investimento { get; set; }
        public DbSet<Transacao> Transacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}

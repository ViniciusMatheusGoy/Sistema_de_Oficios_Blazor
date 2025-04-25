using GerenciamentoOficios.Models;
using Microsoft.EntityFrameworkCore;

public class DbContextBanco: DbContext{
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Setor> Setores => Set<Setor>();
    public DbSet<Oficio> Oficios => Set<Oficio>();

    public DbContextBanco(DbContextOptions<DbContextBanco> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Setor>().Property(e => e.Nome).IsRequired();

        modelBuilder.Entity<Usuario>().Property(e => e.Nome).IsRequired();
        modelBuilder.Entity<Usuario>().Property(e => e.CPF).IsRequired();
        modelBuilder.Entity<Usuario>().Property(e => e.Contato).IsRequired();
        modelBuilder.Entity<Usuario>().Property(e => e.Role).IsRequired();

        modelBuilder.Entity<Oficio>().Property(e => e.CaminhoArquivo).IsRequired();
        modelBuilder.Entity<Oficio>().Property(e => e.Conteudo).IsRequired();
        modelBuilder.Entity<Oficio>().Property(e => e.DestinatarioID).IsRequired();

    }

}
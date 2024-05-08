using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestePositivo.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TestePositivo.Models.AlunoModel> AlunoModel { get; set; } = default!;

    public DbSet<TestePositivo.Models.EnderecoModel> EnderecoModel { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurando a entidade AlunoModel
        modelBuilder.Entity<AlunoModel>()
            .HasMany(a => a.Enderecos)  // Assume que você adicionou uma lista de Enderecos em AlunoModel
            .WithOne(e => e.Aluno)
            .HasForeignKey(e => e.AlunoModelId);

        // Configurando a entidade EnderecoModel
        modelBuilder.Entity<EnderecoModel>()
       .HasOne(e => e.Aluno)
       .WithMany(a => a.Enderecos)
       .HasForeignKey(e => e.AlunoModelId);
    }
}
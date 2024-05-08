using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestePositivo.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TestePositivo.Models.AlunoModel> AlunoModel { get; set; } = default!;

public DbSet<TestePositivo.Models.EnderecoModel> EnderecoModel { get; set; } = default!;
    }

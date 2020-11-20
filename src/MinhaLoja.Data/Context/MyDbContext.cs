using Microsoft.EntityFrameworkCore;
using MinhaLoja.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhaLoja.Data.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);

            
            foreach (var relatioship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relatioship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaLoja.Business.Models;

namespace MinhaLoja.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome).IsRequired().HasColumnType("varchar(200)");

            builder.Property(f => f.Documento).IsRequired().HasColumnType("varchar(14)");

            builder.ToTable("Fornecedores");

            //1:1 => FORNECEDOR : ENDERECO
            builder.HasOne(f => f.Endereco).WithOne(e => e.Fornecedor);

            //1:N => FORNECEDOR : PRODUTOS
            builder.HasMany(f => f.Produtos).WithOne(p => p.Fornecedor).HasForeignKey(p => p.FornecedorId);

        }
    }
}

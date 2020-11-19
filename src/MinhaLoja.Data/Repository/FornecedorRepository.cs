using Microsoft.EntityFrameworkCore;
using MinhaLoja.Business.Interfaces;
using MinhaLoja.Business.Models;
using MinhaLoja.Data.Context;
using System;
using System.Threading.Tasks;

namespace MinhaLoja.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MyDbContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking().Include(f => f.Endereco).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
           return await Db.Fornecedores.AsNoTracking()
                .Include(f=>f.Produtos).Include(f=>f.Endereco).FirstOrDefaultAsync(f=>f.Id==id);
        }
    }
}

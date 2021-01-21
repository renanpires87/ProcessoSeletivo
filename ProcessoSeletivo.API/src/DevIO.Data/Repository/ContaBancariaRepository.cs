using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class ContaBancariaRepository : Repository<ContaBancaria>, IContaBancariaRepository
    {
        public ContaBancariaRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<ContaBancaria> ObterContaBancariaPorId(Guid id)
        {
            return await Db.ContasBancarias.AsNoTracking()
                .Include(c => c.Banco)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ContaBancaria>> ObterContasBancarias()
        {
            return await Db.ContasBancarias.AsNoTracking()
                .Include(c => c.Banco)
                .ToListAsync();
        }
    }
}
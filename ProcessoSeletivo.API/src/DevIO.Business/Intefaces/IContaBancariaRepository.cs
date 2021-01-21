using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IContaBancariaRepository : IRepository<ContaBancaria>
    {
        Task<IEnumerable<ContaBancaria>> ObterContasBancarias();

        Task<ContaBancaria> ObterContaBancariaPorId(Guid id);
    }
}
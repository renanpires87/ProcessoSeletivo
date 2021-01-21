using System;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IContaBancariaService : IDisposable
    {
        Task<bool> Adicionar(ContaBancaria contaBancaria);
        Task<bool> Atualizar(ContaBancaria contaBancaria);
        Task<bool> Remover(Guid id);
    }
}
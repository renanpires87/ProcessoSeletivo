using System;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class ContaBancariaService : BaseService, IContaBancariaService
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;

        public ContaBancariaService(IContaBancariaRepository contaBancariaRepository,
                                 INotificador notificador) : base(notificador)
        {
            _contaBancariaRepository = contaBancariaRepository;
        }

        public async Task<bool> Adicionar(ContaBancaria contaBancaria)
        {
            if (!ExecutarValidacao(new ContaBancariaValidation(), contaBancaria)) return false;

            if (_contaBancariaRepository.Buscar(f => f.NumeroDaAgencia == contaBancaria.NumeroDaAgencia &&
                f.NumeroDaConta == contaBancaria.NumeroDaConta).Result.Any())
            {
                Notificar("Já existe uma conta bancaria com esses dados informado.");
                return false;
            }

            await _contaBancariaRepository.Adicionar(contaBancaria);
            return true;
        }

        public async Task<bool> Atualizar(ContaBancaria contaBancaria)
        {
            if (!ExecutarValidacao(new ContaBancariaValidation(), contaBancaria)) return false;

            if (_contaBancariaRepository.Buscar(f => f.NumeroDaAgencia == contaBancaria.NumeroDaAgencia &&
                f.NumeroDaConta == contaBancaria.NumeroDaConta && f.Id != contaBancaria.Id).Result.Any())
            {
                Notificar("Já existe uma conta bancaria com esses dados informado.");
                return false;
            }

            await _contaBancariaRepository.Atualizar(contaBancaria);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _contaBancariaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _contaBancariaRepository?.Dispose();
            _contaBancariaRepository?.Dispose();
        }
    }
}
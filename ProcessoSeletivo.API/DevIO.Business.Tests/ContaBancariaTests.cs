using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Services;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;

namespace DevIO.Business.Tests
{
    public class ContaBancariaTests
    {
        private readonly AutoMocker _mocker;
        private readonly ContaBancariaService _contaBancariaService;

        public ContaBancariaTests()
        {
            _mocker = new AutoMocker();
            _contaBancariaService = _mocker.CreateInstance<ContaBancariaService>();
        }

        [Fact(DisplayName = "Adicionar Conta Bancaria dados invalidos")]
        [Trait("Categoria","Conta Bancaria Tests")]
        public async Task AdicionarContaBancaria_DadosInvalidos()
        {
            // Arrange
            var contaBancaria = new ContaBancaria();

            // Act
            var result = await _contaBancariaService.Adicionar(contaBancaria);

            // Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Adicionar Conta Bancaria com sucesso")]
        [Trait("Categoria", "Conta Bancaria Tests")]
        public async Task AdicionarContaBancaria_DadosOk()
        {
            // Arrange
            var contaBancaria = new ContaBancaria();
            contaBancaria.SetNumeroDaConta("1234");
            contaBancaria.SetNumeroDaAgencia("1234");
            contaBancaria.SetTipoPessoa(TipoPessoa.PessoaFisica);
            contaBancaria.SetNomeRazaoSocialTitular("Nome Xpto");
            contaBancaria.SetCpfCnpj("24958620044");

            // Act
            var result = await _contaBancariaService.Adicionar(contaBancaria);

            // Assert
            Assert.True(result);
        }
    }
}

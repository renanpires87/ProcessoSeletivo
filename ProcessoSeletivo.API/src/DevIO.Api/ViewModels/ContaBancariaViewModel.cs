using DevIO.Business.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.ViewModels
{
    public class ContaBancariaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid BancoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NumeroDaConta { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NumeroDaAgencia { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public TipoPessoa TipoPessoa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NomeRazaoSocialTitular { get; set; }

        public BancoViewModel Banco { get; set; }

        public DateTime DataAbertura { get; set; } = DateTime.Now;

        public bool Ativo { get; set; } = true;
    }
}
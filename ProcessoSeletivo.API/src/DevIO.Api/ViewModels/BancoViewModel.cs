using System;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.ViewModels
{
    public class BancoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CodigoBanco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NomeInstituicao { get; set; }

    }
}
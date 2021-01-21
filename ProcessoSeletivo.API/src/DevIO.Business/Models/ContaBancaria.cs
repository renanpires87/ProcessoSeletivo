using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.Models
{
    public class ContaBancaria : Entity
    {
        public Guid BancoId { get; private set; }

        public string NumeroDaConta { get; private set; }

        public string NumeroDaAgencia { get; private set; }

        public string CpfCnpj { get; private set; }

        public TipoPessoa TipoPessoa { get; private set; }

        public string NomeRazaoSocialTitular { get; private set; }

        public DateTime DataAbertura { get; private set; }

        public bool Ativo { get; private set; }


        /* EF Relation */
        public Banco Banco { get; private set; }

        #region Metodos

        public void MapearNovosDados(ContaBancaria contaBancaria)
        {
            BancoId = contaBancaria.BancoId;
            NumeroDaConta = contaBancaria.NumeroDaConta;
            NumeroDaAgencia = contaBancaria.NumeroDaAgencia;
            CpfCnpj = contaBancaria.CpfCnpj;
            TipoPessoa = contaBancaria.TipoPessoa;
            NomeRazaoSocialTitular = contaBancaria.NomeRazaoSocialTitular;
            Ativo = contaBancaria.Ativo;
        }

        public void SetNumeroDaConta(string numeroDaConta)
        {
            NumeroDaConta = numeroDaConta;
        }

        public void SetNumeroDaAgencia(string numeroDaAgencia)
        {
            NumeroDaAgencia = numeroDaAgencia;
        }

        public void SetCpfCnpj(string cpfCnpj)
        {
            CpfCnpj = cpfCnpj;
        }

        public void SetTipoPessoa(TipoPessoa tipoPessoa)
        {
            TipoPessoa = tipoPessoa;
        }

        public void SetNomeRazaoSocialTitular(string nomeRazaoSocialTitular)
        {
            NomeRazaoSocialTitular = nomeRazaoSocialTitular;
        }

        #endregion
    }
}

import { Banco } from 'src/app/conta-bancaria/models/banco';

export class ContaBancaria {
    id: string;
    bancoId: string;
    numeroDaConta: string;
    numeroDaAgencia: string;
    tipoPessoa: number;
    cpfCnpj: string;
    banco: Banco;
    nomeRazaoSocialTitular: string;
    dataAbertura: Date;
    ativo: boolean;
}
import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { Observable, Observer } from 'rxjs';
import { Banco } from '../models/banco';
import { ContaBancaria } from '../models/contabancaria'
import { ContaBancariaService } from './contabancaria.service'

const banco: Banco = { id: "123123", "codigoBanco": "234234", "nomeInstituicao": "XPTO" }
const contaBancaria: ContaBancaria[] = [
    {
        id: "3123123",
        bancoId: "4234234",
        numeroDaConta: "3123123",
        numeroDaAgencia: "4234234",
        tipoPessoa: 1,
        cpfCnpj: "34234234",
        banco: banco,
        nomeRazaoSocialTitular: "Teste XPTO",
        dataAbertura: new Date(),
        ativo: true,
    }];

function createResponse(body) {
    return Observable.create((observer: Observer<any>) => {
        observer.next(body);
    });
}

class MockHttp {
    get() {
        return createResponse(contaBancaria);
    }
}

describe('contaBancariaService', () => {

    let service: ContaBancariaService;
    let http: HttpClient;

    beforeEach(() => {
        const bed = TestBed.configureTestingModule({
            providers: [
                { provide: HttpClient, useClass: MockHttp },
                ContaBancariaService
            ]
        });
        http = bed.get(HttpClient);
        service = bed.get(ContaBancariaService);

    });

    it('Deve retornar lista de Contas Bancarias', () => {
        service.obterTodos()
        .subscribe((result) => {
            expect(result.length).toBe(1);
            expect(result).toEqual(contaBancaria);
        });
    });

});
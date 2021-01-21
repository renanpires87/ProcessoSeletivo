import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs";
import { catchError, map } from "rxjs/operators";

import { BaseService } from 'src/app/services/base.service';
import { ContaBancaria } from '../models/contabancaria';
import { Banco } from "../models/banco";

@Injectable()
export class ContaBancariaService extends BaseService {

    contaBancaria: ContaBancaria = new ContaBancaria();

    constructor(private http: HttpClient) { super() }

    obterTodos(): Observable<ContaBancaria[]> {
        return this.http
            .get<ContaBancaria[]>(this.UrlServiceV1 + "contasbancarias", super.ObterAuthHeaderJson())
            .pipe(catchError(super.serviceError));
    }

    obterPorId(id: string): Observable<ContaBancaria> {
        return this.http
            .get<ContaBancaria>(this.UrlServiceV1 + "contasbancarias/" + id, super.ObterAuthHeaderJson())
            .pipe(catchError(super.serviceError));
    }

    novaContaBancaria(contaBancaria: ContaBancaria): Observable<ContaBancaria> {
        return this.http
            .post(this.UrlServiceV1 + "contasbancarias", contaBancaria, this.ObterAuthHeaderJson())
            .pipe(
                map(super.extractData),
                catchError(super.serviceError));
    }

    atualizarContaBancaria(contaBancaria: ContaBancaria): Observable<ContaBancaria> {
        return this.http
            .put(this.UrlServiceV1 + "contasbancarias/" + contaBancaria.id, contaBancaria, super.ObterAuthHeaderJson())
            .pipe(
                map(super.extractData),
                catchError(super.serviceError));
    }

    excluirContaBancaria(id: string): Observable<ContaBancaria> {
        return this.http
            .delete(this.UrlServiceV1 + "contasbancarias/" + id, super.ObterAuthHeaderJson())
            .pipe(
                map(super.extractData),
                catchError(super.serviceError));
    }

    obterBancos(): Observable<Banco[]> {
        return this.http
            .get<Banco[]>(this.UrlServiceV1 + "contasbancarias/obter-bancos", super.ObterAuthHeaderJson())
            .pipe(catchError(super.serviceError));
    }
}

import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ContaBancaria } from '../models/contabancaria';
import { ContaBancariaService } from './contabancaria.service';

@Injectable()
export class ContaBancariaResolve implements Resolve<ContaBancaria> {

    constructor(private contaBancariaService: ContaBancariaService) { }

    resolve(route: ActivatedRouteSnapshot) {
        return this.contaBancariaService.obterPorId(route.params['id']);
    }
}
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ContaBancariaAppComponent } from './contabancaria.app.component';
import { NovoComponent } from './novo/novo.component';
import { ListaComponent } from './lista/lista.component';
import { EditarComponent } from './editar/editar.component';
import { ContaBancariaGuard } from './services/contabancaria.guard';
import { ContaBancariaResolve } from './services/contabancaria.resolve';


const contaBancariaRouterConfig: Routes = [
    {
        path: '', component: ContaBancariaAppComponent,
        children: [
            {
                path: 'listar-todos', component: ListaComponent
            },
            {
                path: 'adicionar-novo', component: NovoComponent,
                canDeactivate: [ContaBancariaGuard],
                canActivate: [ContaBancariaGuard]
            },
            {
                path: 'editar/:id', component: EditarComponent,
                canActivate: [ContaBancariaGuard],
                resolve: {
                    contaBancaria: ContaBancariaResolve
                }
            }
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(contaBancariaRouterConfig)
    ],
    exports: [RouterModule]
})
export class ContaBancariaRoutingModule { }
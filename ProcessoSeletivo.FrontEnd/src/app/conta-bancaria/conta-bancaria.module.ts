import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NovoComponent } from './novo/novo.component';
import { EditarComponent } from './editar/editar.component';
import { ListaComponent } from './lista/lista.component';
import { ContaBancariaRoutingModule } from './contabancaria.route';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgBrazil } from 'ng-brazil';
import { TextMaskModule } from 'angular2-text-mask';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ContaBancariaService } from './services/contabancaria.service';
import { ContaBancariaGuard } from './services/contabancaria.guard';
import { ContaBancariaResolve } from './services/contabancaria.resolve'
import { ContaBancariaAppComponent } from './contabancaria.app.component';



@NgModule({
  declarations: [
    ContaBancariaAppComponent,
    NovoComponent,
    EditarComponent,
    ListaComponent
  ],
  imports: [
    CommonModule,
    ContaBancariaRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgBrazil,
    TextMaskModule,
    NgxSpinnerModule
  ],
  providers: [
    ContaBancariaService,
    ContaBancariaResolve,
    ContaBancariaGuard
  ]
})
export class ContaBancariaModule { }

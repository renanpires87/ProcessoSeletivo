import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ContaBancaria } from '../models/contabancaria';
import { ContaBancariaService } from '../services/contabancaria.service';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.css']
})
export class ListaComponent implements OnInit {

  public contasBancarias: ContaBancaria[];
  errorMessage: string;

  constructor(private contaBancariaService: ContaBancariaService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.contaBancariaService.obterTodos()
      .subscribe(
        contasBancarias => this.contasBancarias = contasBancarias,
        error => this.errorMessage);
  }

  excluir(id: string) {
    if (window.confirm('Tem certeza que excluir a conta bancária?')) {
      this.contaBancariaService.excluirContaBancaria(id)
        .subscribe(
          sucesso => {
            this.toastr.success('Excluido com sucesso!');
            this.contasBancarias.splice(this.contasBancarias.findIndex(x => x.id === id), 1);
          },
          falha => { this.toastr.error('Ocorreu um erro!', 'Opa :('); }
        )
    }
  }

}

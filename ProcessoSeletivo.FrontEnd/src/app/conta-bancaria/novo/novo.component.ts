import { Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { AbstractControl, FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { FormBaseComponent } from 'src/app/base-components/form-base.component';
import { ContaBancaria } from '../models/contabancaria';

import { utilsBr } from 'js-brasil';
import { ContaBancariaService } from '../services/contabancaria.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NgBrazilValidators } from 'ng-brazil';
import { StringUtils } from 'src/app/utils/string-utils';
import { Banco } from '../models/banco';

@Component({
  selector: 'app-novo',
  templateUrl: './novo.component.html',
  styleUrls: ['./novo.component.css']
})
export class NovoComponent extends FormBaseComponent implements OnInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  contaBancariaForm: FormGroup;
  contaBancaria: ContaBancaria = new ContaBancaria();
  bancos: Banco[] = [];

  textoDocumento: string = 'CPF (requerido)';

  MASKS = utilsBr.MASKS;
  formResult: string = '';

  constructor(private fb: FormBuilder,
    private contaBancariaService: ContaBancariaService,
    private router: Router,
    private toastr: ToastrService) {

    super();

    this.validationMessages = {
      nomeRazaoSocialTitular: {
        required: 'Informe o Nome ou Razão Social',
      },
      cpfCnpj: {
        required: 'Informe o Documento',
        cpf: 'CPF em formato inválido',
        cnpj: 'CNPJ em formato inválido'
      },
      bancoId: {
        required: 'Escolha um banco',
      },
      numeroDaAgencia: {
        required: 'Informe o Número da Angência',
      },
      numeroDaConta: {
        required: 'Informe o Número da Conta',
      },
    };

    super.configurarMensagensValidacaoBase(this.validationMessages);
  }

  ngOnInit() {

    this.contaBancariaService.obterBancos()
      .subscribe(
        bancos => this.bancos = bancos);

    this.contaBancariaForm = this.fb.group({
      nomeRazaoSocialTitular: ['', [Validators.required]],
      cpfCnpj: ['', [Validators.required, NgBrazilValidators.cpf]],
      tipoPessoa: ['', [Validators.required]],
      bancoId: ['', [Validators.required]],
      numeroDaAgencia: ['', [Validators.required]],
      numeroDaConta: ['', [Validators.required]],
    });

    this.contaBancariaForm.patchValue({ tipoPessoa: '1', ativo: true });
  }

  ngAfterViewInit(): void {

    this.tipoPessoaForm().valueChanges
      .subscribe(() => {
        this.trocarValidacaoDocumento();
        super.configurarValidacaoFormularioBase(this.formInputElements, this.contaBancariaForm)
        super.validarFormulario(this.contaBancariaForm);
      });

    super.configurarValidacaoFormularioBase(this.formInputElements, this.contaBancariaForm)
  }

  trocarValidacaoDocumento() {
    if (this.tipoPessoaForm().value === "1") {
      this.documento().clearValidators();
      this.documento().setValidators([Validators.required, NgBrazilValidators.cpf]);
      this.textoDocumento = "CPF (requerido)";
    }
    else {
      this.documento().clearValidators();
      this.documento().setValidators([Validators.required, NgBrazilValidators.cnpj]);
      this.textoDocumento = "CNPJ (requerido)";
    }
  }

  tipoPessoaForm(): AbstractControl {
    return this.contaBancariaForm.get('tipoPessoa');
  }

  documento(): AbstractControl {
    return this.contaBancariaForm.get('cpfCnpj');
  }

  adicionarContaBancaria() {
    if (this.contaBancariaForm.dirty && this.contaBancariaForm.valid) {

      this.contaBancaria = Object.assign({}, this.contaBancaria, this.contaBancariaForm.value);
      this.formResult = JSON.stringify(this.contaBancaria);

      this.contaBancaria.cpfCnpj = StringUtils.somenteNumeros(this.contaBancaria.cpfCnpj);
      // forçando o tipo contaBancaria ser serializado como INT
      this.contaBancaria.tipoPessoa = parseInt(this.contaBancaria.tipoPessoa.toString());

      this.contaBancariaService.novaContaBancaria(this.contaBancaria)
        .subscribe(
          sucesso => { this.processarSucesso(sucesso) },
          falha => { this.processarFalha(falha) }
        );
    }
  }

  processarSucesso(response: any) {
    this.contaBancariaForm.reset();
    this.errors = [];

    this.mudancasNaoSalvas = false;

    let toast = this.toastr.success('Conta Bancaria cadastrada com sucesso!', 'Sucesso!');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/contasbancarias/listar-todos']);
      });
    }
  }

  processarFalha(fail: any) {
    this.errors = fail.error.errors;
    this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }

}

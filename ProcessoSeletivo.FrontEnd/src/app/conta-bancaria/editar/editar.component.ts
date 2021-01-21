import { Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { AbstractControl, FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormBaseComponent } from 'src/app/base-components/form-base.component';
import { Banco } from '../models/banco';
import { ContaBancaria } from '../models/contabancaria';
import { ContaBancariaService } from '../services/contabancaria.service';
import { utilsBr } from 'js-brasil';
import { NgBrazilValidators } from 'ng-brazil';
import { StringUtils } from 'src/app/utils/string-utils';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent extends FormBaseComponent implements OnInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  contaBancariaForm: FormGroup;
  contaBancaria: ContaBancaria = new ContaBancaria();
  bancos: Banco[] = [];

  textoDocumento: string = 'CPF (requerido)';

  MASKS = utilsBr.MASKS;
  formResult: string = '';

  tipoPessoa: number;

  constructor(private fb: FormBuilder,
    private contaBancariaService: ContaBancariaService,
    private router: Router,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute) {

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

    this.contaBancaria = this.route.snapshot.data['contaBancaria'];
    this.tipoPessoa = this.contaBancaria.tipoPessoa;
  }

  ngOnInit() {

    this.spinner.show();

    this.contaBancariaService.obterBancos()
      .subscribe(
        bancos => this.bancos = bancos);

    this.contaBancariaForm = this.fb.group({
      nomeRazaoSocialTitular: ['', [Validators.required]],
      cpfCnpj: ['', [Validators.required, NgBrazilValidators.cpf]],
      ativo: ['', [Validators.required]],
      tipoPessoa: ['', [Validators.required]],
      bancoId: ['', [Validators.required]],
      numeroDaAgencia: ['', [Validators.required]],
      numeroDaConta: ['', [Validators.required]],
    });

    this.preencherForm();

    setTimeout(() => {
      this.spinner.hide();
    }, 1000);
  }

  preencherForm() {

    this.contaBancariaForm.patchValue({
      id: this.contaBancaria.id,
      ativo: this.contaBancaria.ativo,
      nomeRazaoSocialTitular: this.contaBancaria.nomeRazaoSocialTitular,
      cpfCnpj: this.contaBancaria.cpfCnpj,
      tipoPessoa: this.contaBancaria.tipoPessoa.toString(),
      bancoId: this.contaBancaria.bancoId,
      numeroDaAgencia: this.contaBancaria.numeroDaAgencia,
      numeroDaConta: this.contaBancaria.numeroDaConta
    });

    if (this.tipoPessoaForm().value === "1") {
      this.documento().setValidators([Validators.required, NgBrazilValidators.cpf]);
    }
    else {
      this.documento().setValidators([Validators.required, NgBrazilValidators.cnpj]);
    }
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

  atualizarContaBancaria() {
    if (this.contaBancariaForm.dirty && this.contaBancariaForm.valid) {

      this.contaBancaria = Object.assign({}, this.contaBancaria, this.contaBancariaForm.value);
      this.contaBancaria.banco = undefined;
      this.formResult = JSON.stringify(this.contaBancaria);

      this.contaBancaria.cpfCnpj = StringUtils.somenteNumeros(this.contaBancaria.cpfCnpj);
      // forçando o tipo contaBancaria ser serializado como INT
      this.contaBancaria.tipoPessoa = parseInt(this.contaBancaria.tipoPessoa.toString());

      this.contaBancariaService.atualizarContaBancaria(this.contaBancaria)
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

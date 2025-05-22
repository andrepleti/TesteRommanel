import { Component, OnInit } from '@angular/core';
import { FormBaseComponent } from '../../shared/form-base/form-base.component';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClienteService } from '../cliente.service';
import { first, map, switchMap } from 'rxjs';
import { Cliente } from '../../../models/Cliente';
import { FormValidationsService } from '../../shared/erro/form-validations.service';
import { ClienteAtualizarCommand } from '../../../models/ClienteAtualizarCommand';
import { ClienteInserirCommand } from '../../../models/ClienteInserirCommand';

@Component({
  selector: 'app-cliente-item',
  templateUrl: './cliente-item.component.html',
  standalone: false,
  styles: ``
})
export class ClienteItemComponent extends FormBaseComponent implements OnInit {

  edicao: boolean = false;

  constructor(
    protected override formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private service: ClienteService) {
      super(formBuilder);
   }

   override ngOnInit(): void {
    this.InicializarForm();

    this.activatedRoute.queryParams.subscribe(
      (queryParams: any) => {

        if (queryParams["texto"]) {
          this.textoAnterior = queryParams["texto"];
        }
        this.CarregarObjeto();
      }
    );

    this.CarregarParametros();
  }

   InicializarForm() {
    this.form = this.formBuilder.group({
      Id: [null, []],
      Tipo: [1, [FormValidationsService.ValidacaoSelecaoItem]],
      NomeRazaoSocial: [null, [Validators.required, Validators.maxLength(200)]],
      CpfCnpj: [null, [Validators.required, FormValidationsService.ValidacaoCPFECNPJ]],
      InscricaoEstadual: [null, []],
      Isento: [false, [Validators.required]],
      DataNascimento: [null, [Validators.required, FormValidationsService.ValidacaoDataMaior18Anos]],
      Telefone: [null, [Validators.required, Validators.maxLength(11)]],
      Email: [null, [Validators.required, Validators.maxLength(50), Validators.email]],
      Cep: [null, [Validators.required, Validators.maxLength(8)]],
      Logradouro: [null, [Validators.required, Validators.maxLength(200)]],
      Numero: [null, [Validators.required, Validators.maxLength(5)]],
      Bairro: [null, [Validators.required, Validators.maxLength(200)]],
      Cidade: [null, [Validators.required, Validators.maxLength(200)]],
      Estado: [null, [Validators.required, Validators.maxLength(2)]],
    });
  }

  CarregarObjeto() {
    this.activatedRoute.params
      .pipe(
        map(params => params["codigo"]),
        switchMap(codigo => this.service.Get(codigo))
      )
      .subscribe((x : Cliente) => {
        this.edicao = x.Id > 0;
        this.form.patchValue(x);
        this.form.patchValue({
          DataNascimento: x.DataNascimento == null ? null : this.FormatarData(x.DataNascimento)
        });
      });
  }

  CarregarParametros() {
    this.router.navigate([], { queryParams: { "texto": this.textoAnterior } });
  }

   Submit() {
    if (this.RetornarCampo('Id').value > 0) {
      var objetoAtualizar: ClienteAtualizarCommand = this.form.value;

      this.service.Put(objetoAtualizar)
      .pipe(first())
      .subscribe(
        () => {
          this.router.navigate(["/"]);
          }
        );
    } else {

      var objetoInserir: ClienteInserirCommand = this.form.value;

      this.service.Post(objetoInserir)
      .pipe(first())
      .subscribe(
        () => {
          this.router.navigate(["/"]);
          }
        );
      }
   }

   Voltar() {
    this.router.navigate(["/"], { queryParams: { "texto": this.textoAnterior } });
  }

  RetornarNomeRazaoSocialPorTipo() {
    return this.RetornarCampo("Tipo").value == 2 ? "Razão Social" : "Nome";
  }

  RetornarCpfCnpjPorTipo() {
    return this.RetornarCampo("Tipo").value == 2 ? "CNPJ" : "CPF";
  }

  RetornarMascaraCpfCnpjPorTipo() {
    return this.RetornarCampo("Tipo").value == 2 ? "00.000.000/0000-00" : "000.000.000-00";
  }

  AlterarIsencao() {
    if (this.RetornarCampo("Isento").value || this.RetornarCampo("Tipo").value != 2) {
     this.RetornarCampo("InscricaoEstadual").clearValidators(); 
    } else {
      this.RetornarCampo("InscricaoEstadual").addValidators([Validators.required, Validators.maxLength(15)]);
    }
    this.RetornarCampo("InscricaoEstadual").updateValueAndValidity();
  }

  AlterarTipo() {
    if (this.RetornarCampo("Tipo").value == 1) {
     this.RetornarCampo("DataNascimento").addValidators([Validators.required, FormValidationsService.ValidacaoDataMaior18Anos]);
    } else {
      this.RetornarCampo("DataNascimento").clearValidators();
    }
    this.RetornarCampo("DataNascimento").updateValueAndValidity();
    this.AlterarIsencao();
  }

  FormatarData(data: Date) {
    const d = new Date(data);
    let month = '' + (d.getMonth() + 1);
    let day = '' + d.getDate();
    const year = d.getFullYear();
    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;
    return [year, month, day].join('-');
  }

}

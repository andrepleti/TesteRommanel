import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClienteService } from '../cliente.service';
import { Cliente } from '../../../models/Cliente';
import { first } from 'rxjs';
import { FormBaseComponent } from '../../shared/form-base/form-base.component';

@Component({
  selector: 'app-cliente-lista',
  templateUrl: './cliente-lista.component.html',
  standalone: false,
  styles: ``
})
export class ClienteListaComponent extends FormBaseComponent implements OnInit {

    lista: Cliente[] = [];

    constructor(
    protected override formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private service: ClienteService) {
      super(formBuilder)
    }

    override ngOnInit(): void {
    this.InicializarForm();

    this.activatedRoute.queryParams.subscribe(
      (queryParams: any) => {

        if (queryParams["texto"]) {
          this.form.patchValue({
            Texto: queryParams["texto"]
          });
        } else {
          this.form.patchValue({
            Texto: ""
          });
        }

        this.CarregarLista();
      }
    );

    this.Submit();
  }

  InicializarForm() {
    this.form = this.formBuilder.group({
      Sistema: [0, []],
      Texto: ["", []]
    });
  }

  Submit() {
    this.router.navigate([], { queryParams: { "texto": this.RetornarCampo('Texto').value } });
  }

  CarregarLista() {
    this.service.ListarPor(this.RetornarCampo('Texto').value)
      .pipe(first())
      .subscribe(x => {
        this.lista = x;
      });
  }

  Deletar(codigo: number) {
      this.service.Delete(codigo)
        .pipe(first())
        .subscribe(
          () => {
            this.CarregarLista();
          }
        );
  }

  RetornarTipo(tipo: number) {
      switch (tipo) {
        case Cliente.ETipoPessoa.Fisica.valueOf():
          return "Física";
        case Cliente.ETipoPessoa.Juridica.valueOf():
          return "Jurídica";
        default:
          return "Física";
      }
    }

}

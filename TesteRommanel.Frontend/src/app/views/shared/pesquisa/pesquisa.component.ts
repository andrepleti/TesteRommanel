import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Params } from '@angular/router';
import { FormBaseComponent } from '../form-base/form-base.component';

@Component({
  selector: 'app-pesquisa',
  templateUrl: './pesquisa.component.html',
  standalone: false,
  styles: ``
})
export class PesquisaComponent extends FormBaseComponent implements OnInit {

  @Input() Parametros?: Params | null;
  @Input() PrimeiroValorInicial: any = 0;
  @Output() Pesquisar: EventEmitter<string> = new EventEmitter();

  constructor(
    protected override formBuilder: FormBuilder) {
      super(formBuilder)
   }

  override ngOnInit(): void {
  }

  Submit() {
    this.Pesquisar.emit(this.RetornarCampo('Texto').value);
  }

}

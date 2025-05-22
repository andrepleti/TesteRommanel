import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBaseComponent } from '../form-base/form-base.component';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-cmb-tipo-cliente',
  templateUrl: './cmb-tipo-cliente.component.html',
  standalone: false,
  styles: ``
})
export class CmbTipoClienteComponent extends FormBaseComponent implements OnInit {

  @Input() Nome: string = "Tipo";
  @Input() Texto: string = "Tipo Cliente";
  @Output() ValorAlterado: EventEmitter<any> = new EventEmitter();

  constructor(
    protected override formBuilder: FormBuilder) {
      super(formBuilder)
   }

  override ngOnInit(): void {
  }

  Alterado() {
    this.RetornarCampo(this.Nome).reset();
      this.Submit();
  }

  Submit() {
    this.ValorAlterado.emit();
  }

}

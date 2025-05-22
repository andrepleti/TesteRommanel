import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-form-base',
  template: '<div></div>',
  styles: [
  ]
})
export abstract class FormBaseComponent implements OnInit {

  @Input() form!: FormGroup;
  @Input() Disabled: boolean = false;
  submetido: boolean = false;
  exibirAvisoErros: boolean = false;
  textoAnterior: string = "";

  constructor(protected formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }

  abstract Submit(): any;

  OnSubmit() {
    this.submetido = true;
    if (this.form.valid) {
      this.Submit();
      this.exibirAvisoErros = false;
      window.scroll(0,0);
    } else {
      this.ExibirValidacoes(this.form);
      this.exibirAvisoErros = true;
    }
  }

  ExibirValidacoes(form: FormGroup) {
    Object.keys(form.controls).forEach(field => {
      const controle = form.get(field);
      if (controle instanceof FormControl) {
        controle.markAsTouched({ onlySelf: true });
      } else if (controle instanceof FormGroup) {
        this.ExibirValidacoes(controle);
      }
    });
  }

  LimparCampos() {
    this.submetido = false;
    this.form.reset();
  }

  RetornarCampo(campo: string) : FormControl {
    return this.form.get(campo) as FormControl;
  }

  RetornaLista(campo: string) : FormArray {
    return this.form.get(campo) as FormArray;
  }

  AplicaCssErro(campo: string) {
    return { 'is-invalid': this.VerificaValidTouched(campo) }  
  }

  VerificaValidTouched(campo: string) {    
    return !this.RetornarCampo(campo).valid && this.RetornarCampo(campo).touched;  
  }
}

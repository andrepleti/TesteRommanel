import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { PesquisaComponent } from './pesquisa/pesquisa.component';
import { CardComponent } from './card/card.component';
import { ErroComponent } from './erro/erro.component';
import { NgxMaskConfig, NgxMaskDirective, provideEnvironmentNgxMask } from 'ngx-mask';
import { CmbTipoClienteComponent } from './cmb-tipo-cliente/cmb-tipo-cliente.component';

const maskConfig: Partial<NgxMaskConfig> = { validation: false };

@NgModule({
  declarations: [
    PesquisaComponent,
    CardComponent,
    ErroComponent,
    CmbTipoClienteComponent,
  ],
  imports: [
    NgxMaskDirective,
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
  ],
  exports: [
    PesquisaComponent,
    CardComponent,
    ErroComponent,
    CmbTipoClienteComponent,
  ],
  providers: [
    provideEnvironmentNgxMask(maskConfig)
  ]
})
export class SharedModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteListaComponent } from './cliente-lista/cliente-lista.component';
import { ClienteItemComponent } from './cliente-item/cliente-item.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ClienteService } from './cliente.service';
import { SharedModule } from '../shared/shared.module';
import { ClienteRoutingModule } from './cliente-routing.module';
import { NgxMaskConfig, NgxMaskDirective, provideEnvironmentNgxMask } from 'ngx-mask';

const maskConfig: Partial<NgxMaskConfig> = { validation: false };

@NgModule({
  declarations: [
    ClienteListaComponent,
    ClienteItemComponent
  ],
  imports: [
    NgxMaskDirective,
    CommonModule,
    ReactiveFormsModule,
    ClienteRoutingModule,
    SharedModule
  ],
  providers: [
    ClienteService,
    provideEnvironmentNgxMask(maskConfig)
  ]
})
export class ClienteModule { }

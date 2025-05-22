import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteListaComponent } from './cliente-lista/cliente-lista.component';
import { ClienteItemComponent } from './cliente-item/cliente-item.component';

const routes: Routes = [
  { path: "", component: ClienteListaComponent },
  { path: ":codigo", component: ClienteItemComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClienteRoutingModule { }

import { Injectable } from '@angular/core';
import { HttpService } from '../../services/http.service';
import { Cliente } from '../../models/Cliente';
import { map } from 'rxjs';
import { ClienteInserirCommand } from '../../models/ClienteInserirCommand';
import { ClienteAtualizarCommand } from '../../models/ClienteAtualizarCommand';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  
  constructor(private httpService: HttpService<Cliente>) { }

  ListarPor(nome: string) {
    return this.httpService.Listar(`cliente?nome=${nome}`)
    .pipe(map(x => {
      return x;
    }));
  }

  Get(id: number) {
      return this.httpService.Get(`cliente/${id}`)
      .pipe(map(x => {
        return x;
    }));
  }

  Post(objeto: ClienteInserirCommand) {
    return this.httpService.Post("cliente", objeto);
  }

  Put(objeto: ClienteAtualizarCommand) {
    return this.httpService.Put("cliente", objeto);
  }

  Delete(id: number) {
    return this.httpService.Delete(`cliente/${id}`);
  }

}

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

  apiURL: string = "/api/cliente";

  ListarPor(nome: string) {
    return this.httpService.Listar(`${this.apiURL}?nome=${nome}`)
    .pipe(map(x => {
      return x;
    }));
  }

  Get(id: number) {
      return this.httpService.Get(`${this.apiURL}/${id}`)
      .pipe(map(x => {
        return x;
    }));
  }

  Post(objeto: ClienteInserirCommand) {
    return this.httpService.Post(this.apiURL, objeto);
  }

  Put(objeto: ClienteAtualizarCommand) {
    return this.httpService.Put(this.apiURL, objeto);
  }

  Delete(id: number) {
    return this.httpService.Delete(`${this.apiURL}/${id}`);
  }

}

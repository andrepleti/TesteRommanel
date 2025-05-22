import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HttpService<T> {

  constructor(private http: HttpClient) { }

  Get(caminho: string) {
    return this.http.get<T>(caminho).pipe(take(1));
  }

  Listar(caminho: string) {
    return this.http.get<T[]>(caminho).pipe(take(1));
  }

  Post(caminho: string, corpo: object) {
    return this.http.post<T>(caminho, corpo).pipe(take(1));
  }

  Put(caminho: string, corpo: object) {
    return this.http.put<T>(caminho, corpo).pipe(take(1));
  }

  Delete(caminho: string) {
    return this.http.delete(caminho).pipe(take(1));
  }
}
import { HttpErrorResponse, HttpEvent, HttpHandler, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { MensagemService } from './mensagem.service';

@Injectable({
    providedIn: 'root'
  })
export class HttpInterceptadorService {
  constructor(protected mensagemService: MensagemService) {}

intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
        map((evento: HttpEvent<any>) => {
            if (evento instanceof HttpResponse) {
                if (evento.body && evento.body.Mensagem) {
                  this.mensagemService.ChamarPorCodigo(evento.status, evento.body.Mensagem, "Mensagem");
                }
              }
            return evento;
        }),
        catchError((erro: HttpErrorResponse) => {
            const error = { mensagem: erro.error.Mensagem || erro.error.text || erro.statusText, status: erro.error.StatusCode || erro.status };
            if (error.status === 0) {
                error.mensagem = "Servidor não respondendo";
                error.status = 500;
            }
            this.mensagemService.ChamarPorCodigo(error.status, error.mensagem, "Erro");
            return throwError(error);
        }));
}
}

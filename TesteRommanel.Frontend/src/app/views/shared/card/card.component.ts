import { Component, Input, OnInit } from '@angular/core';
import { Params } from '@angular/router';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  standalone: false,
  styles: ``
})
export class CardComponent implements OnInit {

  @Input() Codigo: any = 0;
  @Input() TextoPrincipal: string = "";
  @Input() TextoSecundario: string | null = "";
  @Input() TextoMinimizado: string | null = "";
  @Input() OcultarLink: boolean = false;
  @Input() Ativo: boolean = true;
  @Input() Cor: string = "";
  @Input() Parametros?: Params | null;

  constructor() { }

  ngOnInit(): void {
  }

}

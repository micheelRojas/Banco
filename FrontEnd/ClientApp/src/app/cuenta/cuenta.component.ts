import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cuenta',
  templateUrl: './cuenta.component.html',
  styleUrls: ['./cuenta.component.css']
})
export class CuentaComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
export interface ICuenta {
  id: number,
  numeroCuenta: string,
  idCliente: number
}
export interface ICuentaVista {
  id: number,
  numeroCuenta: string,
  cliente: string,
  saldo: number,
  valor: number
}

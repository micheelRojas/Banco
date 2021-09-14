import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CuentaService } from '../cuenta.service';
import { Location } from '@angular/common';
import { ICuenta } from '../cuenta.component';
import { ICliente } from '../../cliente/cliente.component';
import { ClienteService } from '../../cliente/cliente.service';
@Component({
  selector: 'app-form-cuenta',
  templateUrl: './form-cuenta.component.html',
  styleUrls: ['./form-cuenta.component.css']
})
export class FormCuentaComponent implements OnInit {
  ListaClientes: ICliente[] = [];
  constructor(private fb: FormBuilder, private cuentaService: CuentaService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private location: Location, private clienteService: ClienteService) { }
  formGroup = this.fb.group({
    numeroCuenta: ['', [Validators.required]],
    idCliente: ['', [Validators.required]]
  });

  ngOnInit() {
    this.clienteService.getClientes().subscribe(cliente => this.LLenarClientes(cliente),
      error => console.log('Error al llenar lista clientes'))/* this.alertService.error(error))*/;
  }
  save() {
    let cuenta: ICuenta = Object.assign({}, this.formGroup.value);
    console.table(cuenta); //ver grado por consola
    if (this.formGroup.valid) {
      this.cuentaService.createCuenta(cuenta)
        .subscribe(cliente => this.goBack(),
          error => console.log('Error'));//this.mensaje.mensajeAlertaError('Error', error.error.toString()));
    } else {
      //this.mensaje.mensajeAlertaError('¡Error!', 'Registro no valido');
      console.log('Error 2');
    }
  }
  LLenarClientes(clientes: ICliente[]) {
    this.ListaClientes = clientes;
  }
  goBack(): void {
    //this.location.back();
    //this.mensaje.mensajeAlertaCorrecto('Exitoso!', 'Cuenta registrado correctamente');
    console.log('Guardado')
  }
  get numeroCuenta() {
    return this.formGroup.get('numeroCuenta');
  }
  get idCliente() {
    return this.formGroup.get('idCliente');
  }

}

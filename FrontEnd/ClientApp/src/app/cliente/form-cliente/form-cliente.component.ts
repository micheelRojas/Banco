import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { ClienteService } from '../cliente.service';
import {  Location } from '@angular/common';
import { ICliente } from '../cliente.component';
@Component({
  selector: 'app-form-cliente',
  templateUrl: './form-cliente.component.html',
  styleUrls: ['./form-cliente.component.css']
})
export class FormClienteComponent implements OnInit {

  constructor(private fb: FormBuilder, private clienteService: ClienteService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private location: Location) { }
  formGroup = this.fb.group({
    nombre: ['', [Validators.required]]
  });

  ngOnInit() {
  }

  save() {
    let cliente: ICliente = Object.assign({}, this.formGroup.value);
    console.table(cliente); //ver grado por consola
    if (this.formGroup.valid) {
      this.clienteService.createCliente(cliente)
        .subscribe(cliente => this.goBack(),
          error => console.log('Error'));//this.mensaje.mensajeAlertaError('Error', error.error.toString()));
    } else {
      //this.mensaje.mensajeAlertaError('¡Error!', 'Registro no valido');
      console.log('Error 2');
    }
  }
  goBack(): void {
    //this.location.back();
    //this.mensaje.mensajeAlertaCorrecto('Exitoso!', 'Cliente registrado correctamente');
    console.log('Guardado')
  }
  get nombre() {
    return this.formGroup.get('nombre');
  }
}

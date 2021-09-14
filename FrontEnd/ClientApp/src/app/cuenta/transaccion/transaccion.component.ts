import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ICuentaVista } from '../cuenta.component';
import { CuentaService } from '../cuenta.service';

@Component({
  selector: 'app-transaccion',
  templateUrl: './transaccion.component.html',
  styleUrls: ['./transaccion.component.css']
})
export class TransaccionComponent implements OnInit {

  constructor(private fb: FormBuilder, private cuentaService: CuentaService,
    private router: Router, private activatedRoute: ActivatedRoute) { }
  cuentas: ICuentaVista[];
  lista: string[] = ["Deposito", "Retiro"];
  numeroCuentaCtrl = new FormControl('', []);
  tipoCtrl = new FormControl('', []);
  formGroup = this.fb.group({
    numeroCuenta: ['', [Validators.required]],
    cliente: ['', [Validators.required]],
    saldo: ['', [Validators.required]],
    valor: ['', [Validators.required]]
  });
  ngOnInit() {
    
  }
  cargarFormulario(cuenta: ICuentaVista) {
    //console.log(this.numeroCuentaCtrl.value);
    //this.buscarCuenta(Number(this.numeroCuentaCtrl.value));
    this.formGroup.patchValue({
      numeroCuenta: cuenta.numeroCuenta,
      cliente: cuenta.cliente,
      saldo: cuenta.saldo,

    });
    
  }
  LLenarCuenta(cuentas: ICuentaVista[]) {
    this.cuentas = cuentas;
    console.log(this.cuentas);
    this.cargarFormulario(this.cuentas[0]);
  }
  buscarCuenta(event: Event) {
    this.cuentaService.getCuentaBuscada(Number(this.numeroCuentaCtrl.value)).subscribe(cuenta => this.LLenarCuenta(cuenta),
      error => console.log('Error no se encuentra cuenta'))/* this.alertService.error(error))*/;
  }
  transaccion(event: Event) {
    let cuentaVista: ICuentaVista = Object.assign({}, this.formGroup.value);
    if (this.tipoCtrl.value == "Deposito") {
      this.cuentaService.transaccionDeposito(cuentaVista).subscribe(cuenta => this.Sucessos(),
        error => console.log("Error en Deposito"));
      console.log(this.tipoCtrl.value);
      console.log(this.cuentas[0]);
    }
    else {
      this.cuentaService.transaccionRetiro(cuentaVista).subscribe(cuenta => this.Sucessos(),
        error => console.log("Error en retiro"));
      console.log(this.tipoCtrl.value);

    }
  }
    Sucessos() {
      console.log("Transacion Exitosa");
  }

  get numeroCuenta() {
    return this.formGroup.get('numeroCuenta');
  }
  get cliente() {
    return this.formGroup.get('cliente');
  }
  get saldo() {
    return this.formGroup.get('saldo');
  }
  get valor() {
    return this.formGroup.get('valor');
  }


}

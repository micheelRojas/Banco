import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ICuenta } from '../cuenta.component';
import { CuentaService } from '../cuenta.service';
@Component({
  selector: 'app-list-cuenta',
  templateUrl: './list-cuenta.component.html',
  styleUrls: ['./list-cuenta.component.css']
})
export class ListCuentaComponent implements OnInit, OnDestroy {
  suscription: Subscription;
  cuenta!: ICuenta[];
  displayedColumns: string[] = [
    'id',
    'numeroCuenta',
    'saldo',
    'idCliente',
     'nombreCliente'   ];
  dataSource = new MatTableDataSource<ICuenta>(this.cuenta);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(private cuentaService: CuentaService, private router: Router,
    private activatedRoute: ActivatedRoute) {
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit() {
    this.ConsultarCuenta();
    this.suscription = this.cuentaService.refresh$.subscribe(() => {
      this.ConsultarCuenta();
    });
  }
  ngOnDestroy(): void {
    this.suscription.unsubscribe();
  }
  ConsultarCuenta() {
    this.cuentaService.getCuentas()
      .subscribe(cuentas => this.dataSource.data = cuentas,
        error => console.log("Error"));
  }

}

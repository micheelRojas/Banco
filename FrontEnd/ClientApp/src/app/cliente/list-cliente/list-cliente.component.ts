import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ICliente } from '../cliente.component';
import { ClienteService } from '../cliente.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
@Component({
  selector: 'app-list-cliente',
  templateUrl: './list-cliente.component.html',
  styleUrls: ['./list-cliente.component.css']
})
export class ListClienteComponent implements OnInit, OnDestroy{
  suscription: Subscription;
  cliente!: ICliente[];
  displayedColumns: string[] = [
    'id',
    'nombre'];
  dataSource = new MatTableDataSource<ICliente>(this.cliente);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  constructor(private clienteService: ClienteService, private router: Router,
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
    this.ConsultarCliente();
    this.suscription = this.clienteService.refresh$.subscribe(() => {
      this.ConsultarCliente();
    });
  }
  ngOnDestroy(): void {
    this.suscription.unsubscribe();
  }
  ConsultarCliente() {
    this.clienteService.getClientes()
      .subscribe(clientes => this.dataSource.data = clientes,
        error => console.log("Error"));
  }

}

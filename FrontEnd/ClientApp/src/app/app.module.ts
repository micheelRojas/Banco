import { BrowserModule } from '@angular/platform-browser';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { Injectable, Type } from '@angular/core';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ClienteComponent } from './cliente/cliente.component';
import { FormClienteComponent } from './cliente/form-cliente/form-cliente.component';
import { ListClienteComponent } from './cliente/list-cliente/list-cliente.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MensajesModule } from './mensajes/mensajes.module';
import { ClienteService } from './cliente/cliente.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { CuentaComponent } from './cuenta/cuenta.component';
import { FormCuentaComponent } from './cuenta/form-cuenta/form-cuenta.component';
import { ListCuentaComponent } from './cuenta/list-cuenta/list-cuenta.component';
import { CuentaService } from './cuenta/cuenta.service';
import { TransaccionComponent } from './cuenta/transaccion/transaccion.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ClienteComponent,
    FormClienteComponent,
    ListClienteComponent,
    CuentaComponent,
    FormCuentaComponent,
    ListCuentaComponent,
    TransaccionComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'registrar-cliente', component: FormClienteComponent },
      { path: 'lista-cliente', component: ClienteComponent },
      { path: 'registrar-cuenta', component: FormCuentaComponent },
      { path: 'lista-cuenta', component: CuentaComponent },
      { path: 'transaccion', component: TransaccionComponent },

    ],),
    BrowserAnimationsModule,
    MatSortModule,
    MatTableModule
  ],
  //Aqu?? en providers se agregan todos los services de angular
  providers: [ClienteService, CuentaService],
  bootstrap: [AppComponent],
 schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }

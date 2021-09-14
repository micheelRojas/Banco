import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ICuenta, ICuentaVista } from './cuenta.component';

@Injectable({
  providedIn: 'root'
})
export class CuentaService {
  apiURL = this.baseUrl + "api/Cuenta";
  private _refresh$ = new Subject<void>();
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  get refresh$() {
    return this._refresh$;
  }
  getCuentas(): Observable<ICuenta[]> {
    return this.http.get<ICuenta[]>(this.apiURL);
  }
  getCuenta(id: number): Observable<ICuenta> {
    return this.http.get<ICuenta>(this.apiURL + '/' + id);
  }
  getCuentaBuscada(id: number): Observable<ICuentaVista[]> {
    return this.http.get<ICuentaVista[]>(this.apiURL + '/GetCuentaBuscada/' + id);
  }
  createCuenta(cuenta: ICuenta): Observable<ICuenta> {
    return this.http.post<ICuenta>(this.apiURL, cuenta)
      .pipe(
        tap(() => {
          this._refresh$.next();
        })
      );
  }
  transaccionDeposito(cuenta: ICuentaVista): Observable<ICuentaVista> {
    return this.http.put<ICuentaVista>(this.apiURL + '/PutDeposito/' + cuenta.numeroCuenta, cuenta);
  }
  transaccionRetiro(cuenta: ICuentaVista): Observable<ICuentaVista> {
    return this.http.put<ICuentaVista>(this.apiURL + '/PutRetiro/' + cuenta.numeroCuenta, cuenta);
  }

  
}

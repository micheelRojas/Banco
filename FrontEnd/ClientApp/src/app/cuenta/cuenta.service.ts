import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ICuenta } from './cuenta.component';

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
  createCliente(cuenta: ICuenta): Observable<ICuenta> {
    return this.http.post<ICuenta>(this.apiURL, cuenta)
      .pipe(
        tap(() => {
          this._refresh$.next();
        })
      );
  }
  
}

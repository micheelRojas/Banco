import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { ICliente } from './cliente.component';
import { tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  apiURL = this.baseUrl + "api/Cliente";
  private _refresh$ = new Subject<void>();
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  get refresh$() {
    return this._refresh$;
  }
  getClientes(): Observable<ICliente[]> {
    return this.http.get<ICliente[]>(this.apiURL);
  }
  getCliente(id: number): Observable<ICliente> {
    return this.http.get<ICliente>(this.apiURL + '/' + id);
  }
  createCliente(cliente: ICliente): Observable<ICliente> {
    return this.http.post<ICliente>(this.apiURL, cliente)
      .pipe(
        tap(() => {
          this._refresh$.next();
        })
      );
  }

}


import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExoplanetService {
  private apiUrl = 'https://exoplanetexplorer.azurewebsites.net/api/exoplanets'; 

  constructor(private http: HttpClient) {}

  getExoplanets(params: any): Observable<any[]> {
    let httpParams = new HttpParams();
    for (const key in params) {
      if (params[key] !== null && params[key] !== '') {
        httpParams = httpParams.set(key, params[key].toString());
      }
    }
    return this.http.get<any[]>(this.apiUrl, { params: httpParams });
  }
}
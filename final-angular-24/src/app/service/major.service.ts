import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MajorService {

  constructor(private http: HttpClient){ }

  getMajor(){
    return this.http.get<any>('http://localhost:5297/api/major-get')
  }
}

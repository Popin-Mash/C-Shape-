import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor(private http: HttpClient) { }
  getAddresses(parentId:any){
    let data ={
      parentId: parentId
    };
    return this.http.post<any>('http://localhost:5297/api/get-address' ,data);

  }
}

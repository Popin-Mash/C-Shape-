import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  addEmployee(data: any){
    return this.http.post<any>('http://localhost:5297/api/add-employee', data)
  }
  getEmployee(){
    return this.http.get<any>('http://localhost:5297/api/get-employee-list');
  }
}

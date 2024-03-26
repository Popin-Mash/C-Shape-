import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private http: HttpClient) { }
  getDepartment(){
    return this.http.get<any>('http://localhost:5297/api/Department');
  }
  // Get query by Id
  getDartmentById(departmentId:number){
    return this.http.get<any>('http://localhost:5297/api/department-by-id/' + departmentId)
  }

  // Save Data Department
  saveDepartment(data: any){
    return this.http.post<any>('http://localhost:5297/api/Department', data);
  }

  editDepartment(data: any){
    return this.http.post<any>('http://localhost:5297/api/Department-Edit',data)
  }

  deleteDepartment(data: any){
    return this.http.post<any>('http://localhost:5297/api/Department-Delete',data)
  }
    
    

}

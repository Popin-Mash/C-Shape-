import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class PositionService {

  constructor(private http : HttpClient) { }
  getPosition(){
    return this.http.get<any>('http://localhost:5297/api/position-get');
  }
  getPositionById(positionId:number){
    return this.http.get<any>('http://localhost:5297/api/position-by-id/' + positionId);
  }
  cudPosition(data:any){
    return this.http.post<any>('http://localhost:5297/api/positon-cud',data);
  }
}

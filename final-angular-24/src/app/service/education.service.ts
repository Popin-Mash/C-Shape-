import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EducationService {

  constructor(private http: HttpClient){ }

  getEducation(){
    return this.http.get<any>('http://localhost:5297/api/education-level-get')
  }
}

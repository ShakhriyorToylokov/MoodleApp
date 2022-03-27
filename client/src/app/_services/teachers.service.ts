import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Teacher } from '../_models/teacher';

@Injectable({
  providedIn: 'root'
})
export class TeachersService {
  baseUrl= environment.apiUrl;
  httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token
  })
}
  constructor(private http: HttpClient) { }

  getTeachers(){
    return this.http.get<Teacher[]>(this.baseUrl+'teachers', this.httpOptions);
  }

  getTeacher(username: string){
    return this.http.get<Teacher>(this.baseUrl+'teachers/'+ username ,this.httpOptions);
  }

  
  getCourses(username: string){
    return this.http.get<Teacher>(this.baseUrl+'teachers/'+ username,this.httpOptions).pipe(
      map(response=>{
        if (response?.courses) {
            return response.courses;
        }
      })
    );
  }
}

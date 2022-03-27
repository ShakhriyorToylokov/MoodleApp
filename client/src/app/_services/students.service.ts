import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Student } from '../_models/student';



@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  baseUrl= environment.apiUrl;
  httpOptions = {
    headers: new HttpHeaders({
      Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token
    })
  }
  constructor(private http: HttpClient) { }

  getStudents(){
    return this.http.get<Student[]>(this.baseUrl+'students', this.httpOptions);
  }

  getStudent(username: string){
    return this.http.get<Student>(this.baseUrl+'students/'+ username ,this.httpOptions);
  }

  getCourses(username: string){
    return this.http.get<Student>(this.baseUrl+'students/'+ username,this.httpOptions).pipe(
      map(response=>{
        if (response?.courses) {
            return response.courses;
        }
      })
    );
  }
}

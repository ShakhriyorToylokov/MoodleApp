import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Student } from '../_models/student';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token
  })
}

@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  baseUrl= environment.apiUrl;
  constructor(private http: HttpClient) { }

  getStudents(){
    return this.http.get<Student[]>(this.baseUrl+'students', httpOptions);
  }

  getStudent(username: string){
    return this.http.get<Student>(this.baseUrl+'students/'+ username ,httpOptions);
  }

  getCourses(username: string){
    return this.http.get<Student>(this.baseUrl+'students/'+ username,httpOptions).pipe(
      map(response=>{
        if (response?.courses) {
            return response.courses;
        }
      })
    );
  }
}

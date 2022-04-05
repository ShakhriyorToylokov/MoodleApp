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
  constructor(private http: HttpClient) { }

  getStudents(){
    return this.http.get<Student[]>(this.baseUrl+'students');
  }

  getStudent(username: string){
    console.log(username);
    return this.http.get<Student>(this.baseUrl+'students/'+ username);
  }
  getCourses(username: string){
    return this.http.get<Student>(this.baseUrl+'students/'+ username).pipe(
      map(response=>{ 
        if (response?.courses) {
            return response.courses;
        }
      })
    );
  }
  updateStudent(student: Student){
    return this.http.put(this.baseUrl+'students',student);
  }
}

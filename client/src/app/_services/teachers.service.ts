import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Course } from '../_models/course';
import { Teacher } from '../_models/teacher';

@Injectable({
  providedIn: 'root'
})
export class TeachersService {
  teachers: Teacher[]=[]; 
  courses: Course[]=[];
  baseUrl= environment.apiUrl;
  constructor(private http: HttpClient) { }

  getTeachers(){
    if(this.teachers.length>0) return of(this.teachers);
    return this.http.get<Teacher[]>(this.baseUrl+'teachers').pipe(
      map(response=>{
        this.teachers=response;
        return this.teachers;
      })
    );
  }

  getTeacher(username: string){
    const teacher= this.teachers.find(x=>x.username===username);
    if(teacher!==undefined) return of(teacher);
    return this.http.get<Teacher>(this.baseUrl+'teachers/'+ username);
  }

  
  getCourses(username: string){
    if(this.courses.length>0) return of(this.courses);
    return this.http.get<Teacher>(this.baseUrl+'teachers/'+ username).pipe(
      map(response=>{
        if (response?.courses) {
          this.courses=response.courses;
            return this.courses;
        }
      })
    );
  }

  updateTeacher(teacher: Teacher){
    return this.http.put(this.baseUrl+'teachers',teacher).pipe(
      map(()=>{
        const index= this.teachers.indexOf(teacher);
        this.teachers[index]=teacher;
      })
    );
  }
}

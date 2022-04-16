import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Course } from '../_models/course';
import { Student } from '../_models/student';



@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  baseUrl= environment.apiUrl;
  students: Student[] = [];
  courses: Course[]=[];
  constructor(private http: HttpClient) { }

  getStudents(){
    if (this.students.length>0) {
        return of(this.students);
    }
    return this.http.get<Student[]>(this.baseUrl+'students').pipe(
      map(response=>{
        this.students=response;
        return this.students;
      })
    );
  }

  getStudent(username: string){
    const student= this.students.find(x=>x.username===username);
    console.log(student);
    
    if(student!==undefined) return of(student);
    return this.http.get<Student>(this.baseUrl+'students/'+ username);
  }
  getCourses(username: string){
    if(this.courses.length>0) return of(this.courses);
    return this.http.get<Student>(this.baseUrl+'students/'+ username).pipe(
      map(response=>{ 
        if (response?.courses) {
          this.courses=response.courses;
            return this.courses;
        }
      })
    );
  }
  setMainPhoto(photoId:number){
    return this.http.put(this.baseUrl+'students/set-main-photo/'+photoId,{});
  }
  updateStudent(student: Student){
    return this.http.put(this.baseUrl+'students',student).pipe(
      map(()=>{
        const index= this.students.indexOf(student);
        console.log(this.students);
        
        this.students[index]=student;
      })
    );
  }
  deletePhoto(photoId:number){
    return this.http.delete(this.baseUrl+'students/delete-photo/'+photoId);
  }
}

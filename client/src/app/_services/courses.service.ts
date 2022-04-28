import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Course } from '../_models/course';
import { Student } from '../_models/student';
import { Teacher } from '../_models/teacher';

// const httpOptions = {
//   headers: new HttpHeaders({
//     Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token
//   })
// }

@Injectable({
  providedIn: 'root'
})
export class CoursesService {
 
  baseUrl= environment.apiUrl;
  courses: Course[]=[];
  constructor(private http: HttpClient) { }

  getAllCourses(){
    if(this.courses.length>0) return of(this.courses);
    return this.http.get<Course[]>(this.baseUrl+'courses').pipe(
      map(response=>{
        this.courses=response;
        return this.courses;
      })
    );
  }

  getSpecificCourse( courseCode: string){
    const course= this.courses.find(x=>x.courseCode===courseCode);
    if(course !== undefined) return of(course);
    return this.http.get<Course>(this.baseUrl+'courses/'+ courseCode);

  }

  updateCourse(course: Course){
    return this.http.put(this.baseUrl+'courses',course).pipe(
      map(()=>{
        const index= this.courses.indexOf(course);
        console.log(this.courses);
        
        this.courses[index]=course;
      })
    );
  }

  deleteFile(fileId:number,courseCode: string){
    return this.http.delete(this.baseUrl+'courses/delete-file/'+fileId+'?courseCode='+courseCode);
  }
}

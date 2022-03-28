import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Course } from '../_models/course';

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
  
  constructor(private http: HttpClient) { }

  getAllCourses(){
    return this.http.get<Course[]>(this.baseUrl+'courses');
  }

  getSpecificCourse( courseCode: string){
    
    return this.http.get<Course>(this.baseUrl+'courses/'+ courseCode);

  }
}

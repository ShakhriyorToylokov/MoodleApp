import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Course } from '../_models/course';

@Injectable({
  providedIn: 'root'
})
export class CoursesService {
 
  baseUrl= environment.apiUrl;
  httpOptions = {
    headers: new HttpHeaders({
      Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token
    })
  }
  constructor(private http: HttpClient) { }

  getAllCourses(){
    return this.http.get<Course[]>(this.baseUrl+'courses',this.httpOptions);
  }
}

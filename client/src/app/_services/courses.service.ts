import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Announcements, Course } from '../_models/course';
import { Student } from '../_models/student';
import { Teacher } from '../_models/teacher';



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
  registerCourse(model:any){
    return this.http.post(this.baseUrl+'courses/register-course',model);
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

  uploadVideo(courseCode: string,videoUrl: string, name: string){
    let headers = new HttpHeaders().set('Content-Type', 'application/json');
    // return this.http.post(this.baseUrl+"courses/add-video?courseCode="+courseCode+
    //                         "&videoUrl="+videoUrl+"&name="+name,headers);
    return this.http.post(this.baseUrl+'courses/add-video',{courseCode,videoUrl,name})
  }
  uploadAnnouncement(courseCode:string, announcement: string){
    console.log(courseCode,announcement);
    
    return this.http.post(this.baseUrl+'courses/add-announcement',{courseCode,announcement});
  }
  deleteFile(fileId:number,courseCode: string){
    return this.http.delete(this.baseUrl+'courses/delete-file/'+fileId+'?courseCode='+courseCode);
  }
  
  deleteVideo(videoId:number,courseCode: string){
    return this.http.delete(this.baseUrl+'courses/delete-video/'+videoId+'?courseCode='+courseCode);
  }
  deleteAnnouncement(announcementId:number,courseCode: string){
    return this.http.delete(this.baseUrl+'courses/delete-announcement/'+announcementId+'?courseCode='+courseCode);
  } 

  updateAnnouncement(annoucement: Announcements){
    return this.http.put(this.baseUrl+'courses/update-announcement',annoucement);
  }

  setOutlineFile(courseCode:string,fileId:number){
    return this.http.put(this.baseUrl+'courses/set-outline-file/'+fileId+'?courseCode='+courseCode,{});
  }
}

import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/_models/student';
import { StudentsService } from 'src/app/_services/students.service';
import { Course } from 'src/app/_models/course';
import { AccountService } from 'src/app/_services/account.service';
import { User } from 'src/app/_models/user';
import { TeachersService } from 'src/app/_services/teachers.service';
import { CoursesService } from 'src/app/_services/courses.service';
import { take } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-courses-lists',
  templateUrl: './courses-lists.component.html',
  styleUrls: ['./courses-lists.component.css']
})
export class CoursesListsComponent implements OnInit {
  username: string="";
  userType: string;
  courses$: Observable<Course[]> ;
  constructor(private studentService: StudentsService,private accountService: AccountService,
               private teacherService: TeachersService, private courseService: CoursesService) { }

  ngOnInit(): void {
    this.accountService.currentUser$.pipe(take(1)).subscribe(response=>{
      this.username= response?.username;
    });
    if(this.username.includes("std")){
      this.loadStudentsCourses(); 
    }
    else if(this.username.includes("ins")){
      this.loadTeachersCourses();
    }
    else if(this.username.includes("@admin")){
      this.loadAllCourses();
    }
  }
  loadAllCourses(){
      this.courses$= this.courseService.getAllCourses();
  }
  loadTeachersCourses(){
    this.courses$= this.teacherService.getCourses(this.username);
  }
  loadStudentsCourses(){
    
   this.courses$= this.studentService.getCourses(this.username);
  }
}

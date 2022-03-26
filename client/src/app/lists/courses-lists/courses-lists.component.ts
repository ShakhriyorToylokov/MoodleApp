import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/_models/student';
import { StudentsService } from 'src/app/_services/students.service';
import { Course } from 'src/app/_models/course';
import { AccountService } from 'src/app/_services/account.service';
import { User } from 'src/app/_models/user';
import { TeachersService } from 'src/app/_services/teachers.service';

@Component({
  selector: 'app-courses-lists',
  templateUrl: './courses-lists.component.html',
  styleUrls: ['./courses-lists.component.css']
})
export class CoursesListsComponent implements OnInit {
  username: string="";
  userType: string;
  courses: Course[];
  constructor(private studentService: StudentsService,private accountService: AccountService,
               private teacherService: TeachersService) { }

  ngOnInit(): void {
    this.accountService.currentUser$?.subscribe(response=>{
      console.log(response);
      this.username= response?.username;
      console.log(this.username);
      
    });
    // var user= JSON.parse(localStorage.getItem('user'));
    // this.username=user?.username;
    console.log(this.username);
    if(this.username.includes("std")){
      this.loadStudents(); 
    }
    else if(this.username.includes("ins")){
      this.loadTeachers();
    }
    else if(this.username.includes("@admin")){
      this.loadAllCourses();
    }
  }
  loadAllCourses(){
      
  }
  loadTeachers(){
    console.log(this.username);

    this.teacherService.getCourses(this.username).subscribe(response=>{
      console.log(response);
      this.courses=response;
    })
  }
  loadStudents(){
    console.log(this.username);

    this.studentService.getCourses(this.username).subscribe(response=>{
      console.log(response);
      this.courses=response;
    })
  }
}

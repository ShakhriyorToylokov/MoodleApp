import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs/operators';
import { Course } from 'src/app/_models/course';
import { AccountService } from 'src/app/_services/account.service';
import { User } from 'src/app/_models/user';
import { StudentsService } from 'src/app/_services/students.service';
import { Homework } from 'src/app/_models/student';

@Component({
  selector: 'app-homework-page',
  templateUrl: './homework-page.component.html',
  styleUrls: ['./homework-page.component.css']
})
export class HomeworkPageComponent implements OnInit {
  user:User;
  homeworks:Homework[];
  constructor(private accountService:AccountService,private studentService: StudentsService) { 
    accountService.currentUser$.pipe(take(1)).subscribe(response=>{
      this.user=response
      this.loadHomeworks();      

    })
  }

  ngOnInit(): void {
  }

  loadHomeworks(){
    this.studentService.getStudent(this.user.username).subscribe(response=>{
      this.homeworks=response.homeworks
      console.log(this.homeworks);
      
    })
  }
  
}

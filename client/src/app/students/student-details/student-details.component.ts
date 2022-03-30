import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Student } from 'src/app/_models/student';
import { AccountService } from 'src/app/_services/account.service';
import { StudentsService } from 'src/app/_services/students.service';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent implements OnInit {
  student: Student;
  userType: string;
  constructor(private studentService: StudentsService,private route: ActivatedRoute,
              private accountService: AccountService) { }

  ngOnInit(): void {
    this.loadStudent();
  }

  
  getUserType(){
    this.userType = this.accountService.getUserType();
    if (this.userType.includes('@admin')) {
      return 'Admin';
    }
    else if (this.userType.includes('std')) {
      return 'Student';
    }
    return 'Teacher';
  }

  loadStudent(){
      this.studentService.getStudent(this.route.snapshot.paramMap.get('username')).subscribe(response=>{
        this.student=response;
      })
  }

}

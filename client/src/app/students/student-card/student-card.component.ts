import { Component, Input, OnInit } from '@angular/core';
import { Student } from 'src/app/_models/student';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-student-card',
  templateUrl: './student-card.component.html',
  styleUrls: ['./student-card.component.css']
})
export class StudentCardComponent implements OnInit {
  @Input() student: Student;
  userType: string;
  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

  isAdmin(){
    this.userType=this.accountService.getUserType();
   if (this.userType.includes('@admin')) {
      return true;
   }
   return false;
  }

  
  getDefaultPhoto(){
    if(this.student.gender==='female'){
      return './assets/student_female.png'
    }
        return './assets/student.png';
  }
}

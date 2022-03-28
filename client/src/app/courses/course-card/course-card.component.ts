import { Component, Input, OnInit } from '@angular/core';
import { Course } from 'src/app/_models/course';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-course-card',
  templateUrl: './course-card.component.html',
  styleUrls: ['./course-card.component.css']
})
export class CourseCardComponent implements OnInit {
  @Input() course: Course;
  userType:string;
  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

  UserType(){
    this.userType = this.accountService.getUserType();
    if (this.userType.includes('@admin')) {
      return 'Admin';
   }
   else if(this.userType.includes('std')){
   return 'Student';
  }
  return 'Teacher';
  }
}

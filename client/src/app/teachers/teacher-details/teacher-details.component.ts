import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Teacher } from 'src/app/_models/teacher';
import { AccountService } from 'src/app/_services/account.service';
import { TeachersService } from 'src/app/_services/teachers.service';

@Component({
  selector: 'app-teacher-details',
  templateUrl: './teacher-details.component.html',
  styleUrls: ['./teacher-details.component.css']
})
export class TeacherDetailsComponent implements OnInit {
  teacher: Teacher;
  userType: string;
  constructor(private teacherService: TeachersService,private route: ActivatedRoute,
              private accountService: AccountService) { }

  ngOnInit(): void {
    this.loadTeacher();
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
  loadTeacher(){
      this.teacherService.getTeacher(this.route.snapshot.paramMap.get('username')).subscribe(response=>{
        this.teacher=response;
      })
  }
}

import { Component, Input, OnInit } from '@angular/core';
import { Teacher } from 'src/app/_models/teacher';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-teacher-card',
  templateUrl: './teacher-card.component.html',
  styleUrls: ['./teacher-card.component.css']
})
export class TeacherCardComponent implements OnInit {
  @Input() teacher: Teacher
  userType: string;
  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

  isAdmin(){
    this.userType = this.accountService.getUserType();
    if (this.userType.includes('@admin')) {
      return true;
   }
   return false;
  }
}

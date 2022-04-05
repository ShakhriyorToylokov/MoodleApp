import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';
import { TeachersService } from '../_services/teachers.service';

@Component({
  selector: 'app-admin-edit',
  templateUrl: './admin-edit.component.html',
  styleUrls: ['./admin-edit.component.css']
})
export class AdminEditComponent implements OnInit {
  user: User;
  
  constructor(private accountService: AccountService, private teacherService: TeachersService) { }

  ngOnInit(): void {
  }

}

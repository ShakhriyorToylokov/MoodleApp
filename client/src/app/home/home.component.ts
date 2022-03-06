import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode=false;
  IsAdmin:string;
  currentUser$  : Observable<User>;
  constructor(private http: HttpClient,private accountService:AccountService) { }

  ngOnInit(): void {
    this.currentUser$=this.accountService.currentUser$;
  }
  registerToggle(){
    this.registerMode=!this.registerMode;
  }

  isAdmin(){
    this.IsAdmin=this.accountService.getAdminUserType();
    if (this.IsAdmin!==null) {
      return true;
    }
    return false;
  }
  registerModeCancel(event:boolean){
    this.registerMode = event;
  }

  

  
}

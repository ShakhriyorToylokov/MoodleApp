import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsDropdownConfig } from 'ngx-bootstrap/dropdown';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { Student } from '../_models/student';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
  providers: [{ provide: BsDropdownConfig, useValue: { isAnimated: true, autoClose: true } }]
})
export class NavComponent implements OnInit {
  model: any = {};
  currentUser$: Observable<User>;
  student: Student;
  user: User;
  constructor(private accountService : AccountService,private router: Router,
      private toastr: ToastrService) { }

  ngOnInit(): void {
    this.currentUser$=this.accountService.currentUser$;
    this.currentUser$.subscribe(response=>{
      this.user=response;
    })
    console.log(this.user);
    
  }
  login(){
    
    this.accountService.login(this.model).subscribe(response=>{
      console.log(response.username);
      
      if (response.username.includes('@admin')) {
      this.router.navigateByUrl('/');
      }
      else{
        this.router.navigateByUrl('/courses');
      }
    });
  }
  getUserType(){
    var username:string;
    this.currentUser$.subscribe(response=>{
      username=response?.username;  
    })
    if (username?.includes('std')) {
      
      return 'Student';
    }
    else if (username?.includes('@admin')) {
      return 'Admin';
    }
    else if (username?.includes('ins')) {
      return 'Teacher';
    }
  }
  logout(){
   this.accountService.logout();
   this.router.navigateByUrl('/');
   setTimeout(()=>{
    window.location.reload();
  }, 100);
  }
}

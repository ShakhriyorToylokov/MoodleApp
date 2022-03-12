import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.css']
})
export class ServerErrorComponent implements OnInit {
  error:any;
  currentUser$: Observable<User>;
  constructor(private router: Router,private accountService: AccountService) { 
    const navigation= this.router.getCurrentNavigation();
    this.error=navigation?.extras?.state?.error;
  }

  ngOnInit(): void {
    this.currentUser$=this.accountService.currentUser$;
  }

  getUserType(){
    
    var username: string ;
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
}

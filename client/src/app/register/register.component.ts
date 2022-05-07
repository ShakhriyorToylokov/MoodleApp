import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Admin } from '../_models/registerFile';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Input() studentsFromHomeComponent:any;
  @Output() cancelRegister=new EventEmitter();
  model: any = {};
  userModel:string;
  userType:string=null;
  user:User;
  admin: Admin;
  constructor(private accountService: AccountService,private toastr: ToastrService) { }

  ngOnInit(): void {
    this.accountService.currentUser$.subscribe(response=>{
          this.user=response;
    })
    this.getAdmin(this.user.username);
    console.log(this.admin);
    
  }
 
  getAdmin(username: string){
    this.accountService.getAdmin(username).subscribe(response=>{
        this.admin=response;
    })
  }
  register(){
    this.accountService.register(this.model).subscribe(response=>{
      console.log(response);
      this.cancel();
    },error=>{
      console.log(error);
      this.toastr.error(error.error);
    });
  }

  findUserType(){
    console.log(this.model.username);
    this.userModel=this.model?.username;
    this.userType=this.userModel?.slice(0,3);
    return this.userType;
  }

  isContainingNumbers(){
    var usernameString = this.model?.username;
    var stringNums= usernameString?.slice(3);
    var matches = stringNums?.match(/\D/g);
    if (matches){
      return false;
    }
    return true;
  }
  cancel(){
    this.cancelRegister.emit(false);
  }
}

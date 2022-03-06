import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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
  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    
  }

  register(){
    this.accountService.register(this.model).subscribe(response=>{
      console.log(response);
      this.cancel();
    },error=>{
      console.log(error);
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

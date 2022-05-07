import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-register-manually',
  templateUrl: './register-manually.component.html',
  styleUrls: ['./register-manually.component.css']
})
export class RegisterManuallyComponent implements OnInit {

  @Input() studentsFromHomeComponent:any;
  @Output() cancelRegister=new EventEmitter();
  model: any = {};
  userModel:string;
  userType:string=null;
  constructor(private accountService: AccountService,private toastr: ToastrService,
               private router: Router) { }

  ngOnInit(): void {
    
  }

  register(){
    this.accountService.register(this.model).subscribe(response=>{
      console.log(response);
      this.cancel();
      this.router.navigateByUrl('/');
    },error=>{
      console.log(error);
      this.toastr.error(error.error);
    });
  }

  findUserType(){
   // console.log(this.model.username);
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

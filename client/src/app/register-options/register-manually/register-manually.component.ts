import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Faculty } from 'src/app/_models/faculty';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-register-manually',
  templateUrl: './register-manually.component.html',
  styleUrls: ['./register-manually.component.css']
})
export class RegisterManuallyComponent implements OnInit {

  @Input() studentsFromHomeComponent:any;
  @Output() cancelRegister=new EventEmitter();
  userModel:string;
  userType:string='';
  registerForm: FormGroup;
  faculties: Faculty[];
  maxDate: Date;
  validationErrors:string[]=[];
  constructor(private accountService: AccountService,private toastr: ToastrService,
               private router: Router,private fb: FormBuilder) { }

  ngOnInit(): void {
    this.initilizeForm();
    
    this.loadFaculties();
    this.maxDate=new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear() -14);
  }

  initilizeForm(){
    this.registerForm= this.fb.group({
      username: ['',[Validators.required,Validators.minLength(6),Validators.maxLength(15)
                    ,this.matchValues('Idnum'),this.isContainingNumbers()]],
      name: ['',[Validators.required]],
      surname: ['',[Validators.required]],
      Idnum: ['',[Validators.required,Validators.minLength(3),Validators.maxLength(12)]],
      gender: ['male',[Validators.required]],
      email: ['',[Validators.minLength(6)]],
      country: [''],
      dateOfBirth: ['',[Validators.required]],
      faculty: ['',[Validators.required]],
      password: ['',[Validators.required,Validators.minLength(6),Validators.maxLength(15)]],
      confirmPassword: ['',[Validators.required,this.matchValues('password')]]
    })
    
    this.registerForm.controls.password.valueChanges.subscribe(()=>{
      this.registerForm.controls.confirmPassword.updateValueAndValidity();
    })
    this.registerForm.controls.Idnum.valueChanges.subscribe(()=>{
      this.registerForm.controls.username.updateValueAndValidity();
    })
    
  }
  matchValues(matchTo: string): ValidatorFn{
    
    return (control: AbstractControl)=>{
      if(matchTo==='Idnum'){
        var usernameString: string=control?.value
        var stringNums= usernameString?.slice(3);
        console.log(stringNums);
        
        return stringNums===control?.parent?.controls[matchTo].value ? null: {isMatchingIdnum:true}
      }
      return control?.value===control?.parent?.controls[matchTo].value ? null: {isMatching:true}
    }
  }

  isContainingNumbers(): ValidatorFn{
    return (control: AbstractControl)=>{
      
     var usernameString = control.value;
     var stringNums= usernameString?.slice(3);
    var matches = stringNums?.match(/\D/g);
    console.log(matches);
    
      return matches===null ? null: { isContainNums: true}
    }
}

  register(){

    console.log(this.registerForm.value);
    
    this.accountService.register(this.registerForm.value).subscribe(response=>{
      this.toastr.success('Registred Successfully!');
      this.registerForm.reset();
    },error=>{
      this.validationErrors=error;
    });
  }
  loadFaculties(){
    this.accountService.getFaculties().subscribe(response=>{
      this.faculties=response;
    })
  }

  findUserType(){
    this.userModel=this.registerForm.controls.username.value;
    
    this.userType=this.userModel?.slice(0,3);

    return this.userType;
  }

  cancel(){
    this.cancelRegister.emit(false);
  }
}

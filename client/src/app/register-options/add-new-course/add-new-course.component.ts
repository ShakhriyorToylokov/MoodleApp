import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Faculty } from 'src/app/_models/faculty';
import { AccountService } from 'src/app/_services/account.service';
import { CoursesService } from 'src/app/_services/courses.service';
import { Teacher } from 'src/app/_models/teacher';
import { TeachersService } from 'src/app/_services/teachers.service';

@Component({
  selector: 'app-add-new-course',
  templateUrl: './add-new-course.component.html',
  styleUrls: ['./add-new-course.component.css']
})
export class AddNewCourseComponent implements OnInit {
  userModel:string;
  userType:string='';
  @Output() cancelRegister=new EventEmitter();
  registerForm: FormGroup;
  faculties: Faculty[];
  maxDate: Date;
  validationErrors:string[]=[];
  teachers:Teacher[]
  constructor(private courseService: CoursesService,private toastr: ToastrService,
               private router: Router,private fb: FormBuilder,private accountService:AccountService,
               private teacherService:TeachersService) { }

  ngOnInit(): void {
    this.initilizeForm();
    this.loadTeachers();
    this.loadFaculties();
    this.maxDate=new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear() -14);
  }

  initilizeForm(){
    this.registerForm= this.fb.group({
      courseCode: ['',[Validators.required,Validators.minLength(4),Validators.maxLength(12)]],
      nameOfCourse: ['',[Validators.required,Validators.minLength(6),Validators.maxLength(30)]],
      definition: ['',[Validators.required,Validators.minLength(10)]],
      teacherName:['',[Validators.required]],
      // faculty:['',[Validators.required]]

    })
    
  }
  
  
  register(){

    console.log(this.registerForm.value);
    
    this.courseService.registerCourse(this.registerForm.value).subscribe(response=>{
      this.toastr.success('Registred Successfully!');
      this.registerForm.reset();
      console.log(response);
    },error=>{
      this.validationErrors=error;
    });
  }
  loadFaculties(){
    this.accountService.getFaculties().subscribe(response=>{
      this.faculties=response;
    })
  }

  loadTeachers(){
    this.teacherService.getTeachers().subscribe(response=>{
      this.teachers=response;
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

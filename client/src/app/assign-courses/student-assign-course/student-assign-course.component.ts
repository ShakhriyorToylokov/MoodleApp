import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { ToastrService } from 'ngx-toastr';
import { Course } from 'src/app/_models/course';
import { Student } from 'src/app/_models/student';
import { CoursesService } from 'src/app/_services/courses.service';
import { StudentsService } from 'src/app/_services/students.service';

@Component({
  selector: 'app-student-assign-course',
  templateUrl: './student-assign-course.component.html',
  styleUrls: ['./student-assign-course.component.css']
})
export class StudentAssignCourseComponent implements OnInit {
  courses: Course[];  
  assignForm: FormGroup;
  allCourses:Course[];
  @ViewChild('assignForm') editForm: NgForm;
  student: Student;
  dropdownList = [];
  dropdownSettings: IDropdownSettings={};
  selectedCourses:Course[];
  userCourses:Course[]
  constructor(private toastr: ToastrService,private courseService:CoursesService,
              private router: Router,private fb: FormBuilder,private studentService:StudentsService,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadStudent();
    this.initilizeForm();
    console.log(this.allCourses);
    this.dropdownSettings={
      idField: 'id',
      textField: 'nameOfCourse',
      allowSearchFilter: true
    }
  }
  initilizeForm(){
    this.assignForm= this.fb.group({
      course: ['',Validators.required],
    })

  }
  loadStudent(){
    this.studentService.getStudent(this.route.snapshot.paramMap.get('username')).subscribe(response=>{
      this.courses=response.courses;
      this.student=response;
      console.log(this.student);
      this.userCourses=response.courses;
      console.log(this.userCourses);
      
      this.getAllCourses();
      
    });
  } 
  register(){
    while(this.courses.length>0){
      this.courses.pop();
    }
    for (let i = 0; i < this.selectedCourses.length; i++) {
        
      for (let j = 0; j < this.allCourses.length; j++) {
      
        if (this.selectedCourses[i].nameOfCourse===this.allCourses[j].nameOfCourse) {
          var course=this.allCourses[j];
          this.courses.push(course);
        }
      }
    }
    this.student.courses=this.courses;
    this.studentService.updateStudentCourse(this.student).subscribe(()=>{
      this.toastr.success('Assigned Successfully!');
      this.editForm.reset(); 

    });
  }
  getAllCourses(){
    this.courseService.getAllCourses().subscribe(response=>{
      this.allCourses=response;
      console.log(this.courses);
      
      for (let i = 0; i < this.courses?.length; i++) {
        
        for (let j = 0; j < this.allCourses.length; j++) {
        
          if (this.courses[i].nameOfCourse===this.allCourses[j].nameOfCourse) {
            var course=this.courses[i];
            this.allCourses= this.allCourses.filter(x=>x.nameOfCourse!==course.nameOfCourse);
          }
          
        }
      }
      
    console.log(this.allCourses);
    
    });
  }   
}

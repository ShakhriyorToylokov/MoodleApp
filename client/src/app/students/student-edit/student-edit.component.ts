import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Faculty } from 'src/app/_models/faculty';
import { Student } from 'src/app/_models/student';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { StudentsService } from 'src/app/_services/students.service';

@Component({
  selector: 'app-student-edit',
  templateUrl: './student-edit.component.html',
  styleUrls: ['./student-edit.component.css']
})
export class StudentEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  faculties: Faculty[];
  student: Student;
  user: User;
  @HostListener('window:beforeunload',['$event']) unloadNotification($event:any){
    if (this.editForm.dirty) {
      $event.returnValue=true;
    }
  }
  constructor(private accountService: AccountService, private studentService: StudentsService,
              private route: ActivatedRoute,private toastr: ToastrService) { 
    accountService.currentUser$.pipe(take(1)).subscribe(response=>{
      this.user=response;
    })
  }

  ngOnInit(): void {
    this.loadStudent();
    this.loadFaculties();
  }
  loadFaculties(){
    this.accountService.getFaculties().subscribe(response=>{
      this.faculties=response;
    })
  }
  getUserType(){
    var username:string;
    this.accountService.currentUser$.subscribe(response=>{
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
  loadStudent(){
    this.studentService.getStudent(this.route.snapshot.paramMap.get('username')).subscribe(response=>{
      this.student=response;
      
    
    });
  }
  updateStudent(){
    
    this.studentService.updateStudent(this.student).subscribe(()=>{
        console.log(this.student);
        this.toastr.success("Updated Successfully!!!");
        this.editForm.reset(this.student);
    })
    
  }
}

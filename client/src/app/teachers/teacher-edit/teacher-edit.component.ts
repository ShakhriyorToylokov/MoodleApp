import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Faculty } from 'src/app/_models/faculty';
import { Teacher } from 'src/app/_models/teacher';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { TeachersService } from 'src/app/_services/teachers.service';

@Component({
  selector: 'app-teacher-edit',
  templateUrl: './teacher-edit.component.html',
  styleUrls: ['./teacher-edit.component.css']
})
export class TeacherEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  faculties: Faculty[];
  teacher: Teacher;
  user: User;
  constructor(private accountService: AccountService, private teacherService: TeachersService,
              private route: ActivatedRoute,private toastr: ToastrService) {
      accountService.currentUser$.pipe(take(1)).subscribe(response=>{
        this.user=response
      });
   }

  ngOnInit(): void {
    this.loadTeacher();
    this.loadFaculties();    
  }

  loadTeacher(){
    this.teacherService.getTeacher(this.route.snapshot.paramMap.get('username')).subscribe(response=>{
      this.teacher=response;
      
    });
  }

  loadFaculties(){
    this.accountService.getFaculties().subscribe(response=>{
      
      this.faculties=response;
    })
  }

  updateTeacher(){
    console.log(this.teacher);
    this.toastr.success("Updated Successfully!!!");
    this.editForm.reset(this.teacher);    
  }
}

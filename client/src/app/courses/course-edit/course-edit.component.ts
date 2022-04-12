import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Course } from 'src/app/_models/course';
import { AccountService } from 'src/app/_services/account.service';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-course-edit',
  templateUrl: './course-edit.component.html',
  styleUrls: ['./course-edit.component.css']
})
export class CourseEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  @ViewChild('editForm2') editForm2: NgForm;
  @ViewChild('name') textarea;
  announcement:string;
  course: Course;
  @HostListener('window:beforeunload',['$event']) unloadNotification($event:any){
    if (this.editForm.dirty) {
      $event.returnValue=true;
    }
  }
  constructor(private courseService: CoursesService, private route: ActivatedRoute,
              private toastr: ToastrService,private accountService: AccountService) { }

  ngOnInit(): void {
    this.loadCourse();
  }

  loadCourse(){
    this.courseService.getSpecificCourse(this.route.snapshot.paramMap.get('coursecode')).subscribe(
      response=>{
        this.course=response;
      }
    )
  }
  updateCourse(){
      this.course.announcements=[
        {
            "announcement": this.announcement
        }];
    this.courseService.updateCourse(this.course).subscribe(()=>{
      console.log(this.course);
      this.toastr.success("Updated Successfully!!!");
      this.editForm.reset(this.course);
      this.editForm2.reset(this.course);
      console.log(this.course.announcements);
      this.textarea.nativeElement.value = ' ';
    })
   
  }

  getUserType(){
    var username= this.accountService.getUserType();
    if(username.includes("@admin")) return 'Admin';
    if(username.includes("ins")) return 'Teacher';
    if(username.includes("std")) return 'Student';
  }
}

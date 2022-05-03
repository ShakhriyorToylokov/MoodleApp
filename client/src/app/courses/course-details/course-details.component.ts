import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Announcements, Course } from 'src/app/_models/course';
import { AccountService } from 'src/app/_services/account.service';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-course-details',
  templateUrl: './course-details.component.html',
  styleUrls: ['./course-details.component.css']
})
export class CourseDetailsComponent implements OnInit {
  course:  Course;
  userType: string;
  @ViewChild("editForm") editForm: NgForm; 
  @ViewChild('name') textarea;

  constructor(private courseService: CoursesService, private route: ActivatedRoute,
              private accountService:AccountService,private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadCourse();
  }

  getUserType(){
    this.userType = this.accountService.getUserType();
    if (this.userType.includes('@admin')) {
      return 'Admin';
    }
    else if (this.userType.includes('std')) {
      return 'Student';
    }
    return 'Teacher';
  }
  loadCourse(){
    this.courseService.getSpecificCourse(this.route.snapshot.paramMap.get('coursecode')).subscribe(
      response=>{
        
        this.course=response;
      }
    )
  }
  deleteAnnouncement(announcement:Announcements){
    this.courseService.deleteAnnouncement(announcement.id,this.course.courseCode).subscribe(()=>{
      this.toastr.info('Deleted Successfully!!!')
      this.course.announcements=this.course.announcements.filter(x=>x.id!==announcement.id);
      
    });
  }
  focusInput(annoucement:Announcements){
      document.getElementById("inputText").focus();
  }
  updateAnnouncement(annoucement:Announcements){
  
    var text=annoucement.announcement
    this.courseService.updateAnnouncement(annoucement).subscribe(()=>{
      this.toastr.success("Updated Successfully!")
      this.editForm.reset();
      this.textarea.nativeElement.value = text;

    })
    
}
}

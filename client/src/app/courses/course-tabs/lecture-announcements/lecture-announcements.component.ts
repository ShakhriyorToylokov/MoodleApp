import { Component, HostListener, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Course } from 'src/app/_models/course';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-lecture-announcements',
  templateUrl: './lecture-announcements.component.html',
  styleUrls: ['./lecture-announcements.component.css']
})
export class LectureAnnouncementsComponent implements OnInit {
  @Input() course:Course;
  @Input() usertype: string;
  @ViewChild('editForm') editform: NgForm;
  @ViewChild('name') textarea;
  announcementText: string;

  @HostListener('window:beforeunload',['$event']) unloadNotification($event:any){
    if (this.editform.dirty) {
      $event.returnValue=true;
    }
  }
  constructor(private courseService: CoursesService,private toastr: ToastrService) { }

  ngOnInit(): void {
    
  }
  uploadAnnouncement(){
    console.log(this.course.courseCode,this.announcementText);
    //not coming to here search why?
    this.courseService.uploadAnnouncement(this.course.courseCode,this.announcementText).subscribe(response=>{
      console.log(response);
      this.toastr.success('Announced Successfully!!!');
      this.editform.reset();
      this.textarea.nativeElement.value = ' ';
    });
  }

}

import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Announcements, Course, CourseFiles } from 'src/app/_models/course';
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
  btnDisabled: boolean=false;
  announcement:Announcements
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
  this.btnDisabled=false;
    var text=annoucement.announcement
    this.courseService.updateAnnouncement(annoucement).subscribe(()=>{
      this.toastr.success("Updated Successfully!");
      // this.btnDisabled=true;
      this.editForm.form.markAsPristine();
    })
    
}

fileType(file: CourseFiles){
  if(file.fileName.includes('.pdf'))
    return 'assets/pdf_icon.png';
  else if(file.fileName.includes('.docx'))
    return 'assets/word_icon.png';
  
    else if(file.fileName.includes('.txt'))
    return 'assets/txt_icon.png';
    else if(file.fileName.includes('.pptx'))
    return 'assets/pptx_icon.png';
    
    else if(file.fileName.includes('.xlsx'))
    return 'assets/xlsx_icon.jpg';
  return 'undefined'
}
deleteFile(file:CourseFiles){
  this.courseService.deleteFile(file.id,this.course.courseCode).subscribe(()=>{
    this.course.courseFiles=this.course.courseFiles.filter(x=>x.id!==file.id);
  });
}
}

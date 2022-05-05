import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Course, CourseFiles } from 'src/app/_models/course';
import { AccountService } from 'src/app/_services/account.service';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-lecture-notes',
  templateUrl: './lecture-notes.component.html',
  styleUrls: ['./lecture-notes.component.css']
})
export class LectureNotesComponent implements OnInit {
  course:  Course;
  userType: string ;
  isOutline:boolean;
  constructor(private courseService: CoursesService, private route: ActivatedRoute,
              private accountService:AccountService) { }

  ngOnInit(): void {
    this.loadCourse();
    console.log(this.isOutline);
    
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
        console.log(this.course);
      }
    )
  }
  deleteFile(file:CourseFiles){
    this.courseService.deleteFile(file.id,this.course.courseCode).subscribe(()=>{
      this.course.courseFiles=this.course.courseFiles.filter(x=>x.id!==file.id);
    });
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
}

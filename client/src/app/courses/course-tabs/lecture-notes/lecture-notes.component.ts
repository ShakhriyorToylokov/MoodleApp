import { Component, OnInit } from '@angular/core';
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
  constructor(private courseService: CoursesService, private route: ActivatedRoute,
              private accountService:AccountService) { }

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
      return 'pdf';
    else if(file.fileName.includes('.docx'))
      return 'docx';
    
      else if(file.fileName.includes('.txt'))
      return 'txt';
      else if(file.fileName.includes('.pptx'))
      return 'pptx';
      
      else if(file.fileName.includes('.xlsx'))
      return 'xlsx';
    return 'undefined'
  }
}

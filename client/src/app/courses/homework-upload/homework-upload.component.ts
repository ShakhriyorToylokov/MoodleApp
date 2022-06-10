import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FileUploader } from 'ng2-file-upload';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Course, CourseFiles } from 'src/app/_models/course';
import { Homework } from 'src/app/_models/student';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { CoursesService } from 'src/app/_services/courses.service';
import { StudentsService } from 'src/app/_services/students.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-homework-upload',
  templateUrl: './homework-upload.component.html',
  styleUrls: ['./homework-upload.component.css']
})
export class HomeworkUploadComponent implements OnInit {
 course: Course;
  @Input() nameOfHomeWork : string;
  uploader:FileUploader;
  hasBaseDropZoneOver:false;
  baseUrl=environment.apiUrl;
  user:User;
  homeworks:Homework[];

  constructor(private accountService:AccountService,private studentService: StudentsService
            ,private courseService: CoursesService,private toastr:ToastrService,private router: Router
            ,private route: ActivatedRoute) {
    accountService.currentUser$.pipe(take(1)).subscribe(response=>{
      this.user=response
      this.loadHomeworks();
    })
   }

  ngOnInit(): void {
    this.loadCourse();
    this.initilizeUploader();
  }

  fileOverBase(event:any){
    this.hasBaseDropZoneOver=event;
  }
  initilizeUploader(){
    this.uploader=new FileUploader({
      url: this.baseUrl+'students/add-homework?nameofHomework='+this.nameOfHomeWork,
      authToken:'Bearer '+this.user.token,
      isHTML5:true,
      removeAfterUpload: true,
      autoUpload:false,
      maxFileSize:10*1024*1024
    });
    
    this.uploader.onAfterAddingFile=(file)=>{
      file.withCredentials=false;
    }
    this.uploader.onSuccessItem=(item,response,status,headers)=>{
      if (response) {
        console.log(response);        
        const file = JSON.parse(response);
        console.log(file.fileName);
      }
      this.toastr.success('Successfully uploaded homework');
      this.router.navigateByUrl('/courses/'+this.course.courseCode);
      
    },error=>{
      console.log(error);
      this.toastr.error('Failed to upload homework');
    }
  }
  deleteFile(file:CourseFiles){
    this.studentService.deleteHomework(file.id).subscribe(response=>{
      this.toastr.info('Deleted Successfully');
      this.homeworks=this.homeworks.filter(x=>x.id!==file.id);
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
  loadCourse(){
    this.courseService.getSpecificCourse(this.route.snapshot.paramMap.get('coursecode')).subscribe(
      response=>{
        this.course=response;
      }
    )
  }
  loadHomeworks(){
    this.studentService.getStudent(this.user.username).subscribe(response=>{
      this.homeworks=response.homeworks
      console.log(this.homeworks);
      
    })
  }
  
}

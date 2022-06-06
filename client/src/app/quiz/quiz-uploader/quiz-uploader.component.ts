import { HttpHeaders } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FileUploader } from 'ng2-file-upload';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Course, CourseFiles, QuizFiles } from 'src/app/_models/course';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { CoursesService } from 'src/app/_services/courses.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-quiz-uploader',
  templateUrl: './quiz-uploader.component.html',
  styleUrls: ['./quiz-uploader.component.css']
})
export class QuizUploaderComponent implements OnInit {
  @Input() course: Course;
  uploader:FileUploader;
  hasBaseDropZoneOver:false;
  baseUrl=environment.apiUrl;
  user:User;
  @Input() time: number;
  @Input() definition: string;

  
  constructor(private accountService:AccountService,private courseService: CoursesService
            ,private toastr: ToastrService,private route: ActivatedRoute) {
    accountService.currentUser$.pipe(take(1)).subscribe(response=>{
      this.user=response
    })
   }
 
  ngOnInit(): void {
    this.loadCourse();
    console.log(this.time,this.course?.courseCode,this.definition);
    
    this.initilizeUploader();
  }
  loadCourse(){
    this.courseService.getSpecificCourse(this.route.snapshot.paramMap.get('coursecode')).subscribe(
      response=>{
        this.course=response;
      }
    )
  }
  fileOverBase(event:any){
    this.hasBaseDropZoneOver=event;
  }
  initilizeUploader(){
    
    this.uploader=new FileUploader({
      url: "https://localhost:5001/api/courses/add-quiz?courseCode="+this.course?.courseCode+"&"+"time="+this.time+"&"+"definition="+this.definition,
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
        
        this.toastr.success('Successfully uploaded quiz');
        setTimeout(() => {
          console.log(response);          
        }, 1000);
      }
    },error=>{
      console.log(error);
      
    }
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
    return 'assets/undefined_icon.png'
  }  
  
}

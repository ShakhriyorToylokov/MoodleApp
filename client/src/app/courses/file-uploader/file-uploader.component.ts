import { Component, Input, OnInit } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { take } from 'rxjs/operators';
import { Course, CourseFiles } from 'src/app/_models/course';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { CoursesService } from 'src/app/_services/courses.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-file-uploader',
  templateUrl: './file-uploader.component.html',
  styleUrls: ['./file-uploader.component.css']
})
export class FileUploaderComponent implements OnInit {
  @Input() course: Course;
  uploader:FileUploader;
  hasBaseDropZoneOver:false;
  baseUrl=environment.apiUrl;
  user:User;

  constructor(private accountService:AccountService,private courseService: CoursesService) {
    accountService.currentUser$.pipe(take(1)).subscribe(response=>{
      this.user=response
    })
   }

  ngOnInit(): void {
    this.initilizeUploader();
  }

  fileOverBase(event:any){
    this.hasBaseDropZoneOver=event;
  }
  initilizeUploader(){
    this.uploader=new FileUploader({
      url: this.baseUrl+'courses/add-file?courseCode='+this.course.courseCode,
      authToken:'Bearer '+this.user.token,
      isHTML5:true,
      allowedFileType:['image','pdf','doc','ppt','txt','xls'],
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

        this.course.courseFiles?.push(file);
      }
    },error=>{
      console.log(error);
      
    }
  }
  setOutlineFile(file:CourseFiles){
    this.courseService.setOutlineFile(this.course.courseCode,file.id).subscribe(()=>{
      this.course.courseFiles.forEach(f => {
        if(f.isOutline) f.isOutline=false;
        if(f.id===file.id) f.isOutline=true;
      });
    })
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

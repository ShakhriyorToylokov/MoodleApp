import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { FileUploader } from 'ng2-file-upload';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Course, CourseFiles } from 'src/app/_models/course';
import { Admin, RegisterFiles } from 'src/app/_models/registerFile';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { CoursesService } from 'src/app/_services/courses.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-register-by-file',
  templateUrl: './register-by-file.component.html',
  styleUrls: ['./register-by-file.component.css'],
})
export class RegisterByFileComponent implements OnInit {
  file: RegisterFiles;
  uploader:FileUploader;
  hasBaseDropZoneOver:false;
  baseUrl=environment.apiUrl;
  user:User;
  @Input() admin: Admin;
    constructor(private accountService:AccountService,private courseService: CoursesService,
              private toast: ToastrService,private route: Router) {
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
    //usertype is undefined make form maybe to make ngform
    this.uploader=new FileUploader({
      url: this.baseUrl+'account/register-by-file?usertype=Student',
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
        this.toast.success('Registered Successfully!')   
        const file = JSON.parse(response);
        console.log(file.fileName);
        console.log( this.admin.registerFiles);
        
        this.admin.registerFiles?.push(file);
      }
    },error=>{
      console.log(error);
      this.toast.error('Failed to Register!')
    }
  }
  
 
  deleteFile(file:CourseFiles){
    this.accountService.deleteRegisterFile(file.id).subscribe(()=>{
      this.admin.registerFiles=this.admin.registerFiles.filter(x=>x.id!==file.id);
      //functionalities are added now work on how to send the files to Seed.cs and register by files
    });
  }
  fileType(file: RegisterFiles){
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

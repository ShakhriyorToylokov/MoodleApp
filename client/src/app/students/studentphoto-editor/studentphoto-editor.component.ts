import { Component, Input, OnInit } from '@angular/core';
import { StdPhoto, Student } from 'src/app/_models/student';
import {FileUploader} from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { take } from 'rxjs/operators';
import { StudentsService } from 'src/app/_services/students.service';
@Component({
  selector: 'app-studentphoto-editor',
  templateUrl: './studentphoto-editor.component.html',
  styleUrls: ['./studentphoto-editor.component.css']
})
export class StudentphotoEditorComponent implements OnInit {
  @Input() student:Student;
  uploader:FileUploader;
  hasBaseDropZoneOver:false;
  baseUrl=environment.apiUrl;
  user:User;
  constructor(private accountService:AccountService,private studentService: StudentsService) {
    accountService.currentUser$.pipe(take(1)).subscribe(response=>{
      this.user=response
    })
   }
  // give chance to users to edit photos themselves
  ngOnInit(): void {
    this.initilizeUploader()
  }

  setMainPhoto(photo:StdPhoto){
    this.studentService.setMainPhoto(photo.id).subscribe(()=>{
      this.user.photoUrl=photo.url;
      this.accountService.setCurrentUser(this.user);
      this.student.photoUrl=photo.url;
      this.student.photos.forEach(p => {
        if(p.isMain) p.isMain=false;
        if(p.id===photo.id) p.isMain=true;
      });
    })
  }
  deletePhoto(photo:StdPhoto){
    this.studentService.deletePhoto(photo.id).subscribe(()=>{
      this.student.photos=this.student.photos.filter(x=>x.id!==photo.id);
    });
}
  fileOverBase(event:any){
    this.hasBaseDropZoneOver=event;
  }
  initilizeUploader(){
    this.uploader=new FileUploader({
      url: this.baseUrl+'students/add-photo',
      authToken:'Bearer '+this.user.token,
      isHTML5:true,
      allowedFileType:['image'],
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
        
        const photo = JSON.parse(response);
        this.student.photos.push(photo);
      }
    }
  }
}

import { Component, Input, OnInit } from '@angular/core';
import { Student } from 'src/app/_models/student';
import {FileUploader} from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { take } from 'rxjs/operators';
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
  constructor(private accountService:AccountService) {
    accountService.currentUser$.pipe(take(1)).subscribe(response=>{
      this.user=response
    })
   }
  // give chance to users to edit photos themselves
  ngOnInit(): void {
    this.initilizeUploader()
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
        const photo = JSON.parse(response);
        this.student.photos.push(photo);
      }
    }
  }
}

import { Component, Input, OnInit } from '@angular/core';
import { Teacher, TeacherPhoto } from 'src/app/_models/teacher';
import {FileUploader} from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { take } from 'rxjs/operators';
import { TeachersService } from 'src/app/_services/teachers.service';
import { StdPhoto } from 'src/app/_models/student';
@Component({
  selector: 'app-teacherphoto-editor',
  templateUrl: './teacherphoto-editor.component.html',
  styleUrls: ['./teacherphoto-editor.component.css']
})
export class TeacherphotoEditorComponent implements OnInit {
  @Input() teacher:Teacher;
  uploader:FileUploader;
  hasBaseDropZoneOver:false;
  baseUrl=environment.apiUrl;
  user:User;
  constructor(private accountService:AccountService,private teacherService: TeachersService) {
    accountService.currentUser$.pipe(take(1)).subscribe(response=>{
      this.user=response
    })
   }
   ngOnInit(): void {
    this.initilizeUploader()
  }
  setMainPhoto(photo:TeacherPhoto){
    this.teacherService.setMainPhoto(photo.id).subscribe(()=>{
      this.user.photoUrl=photo.url;
      this.accountService.setCurrentUser(this.user);
      this.teacher.photoUrl=photo.url;
      this.teacher.photos.forEach(p=>{
        if(p.isMain) p.isMain=false;
        if(p.id===photo.id) p.isMain=true;
        
      })
    })
  }
  deletePhoto(photo:TeacherPhoto){
      this.teacherService.deletePhoto(photo.id).subscribe(()=>{
        this.teacher.photos=this.teacher.photos.filter(x=>x.id!==photo.id);
      });
  }
  fileOverBase(event:any){
    this.hasBaseDropZoneOver=event;
  }
  initilizeUploader(){
    this.uploader=new FileUploader({
      url: this.baseUrl+'teachers/add-photo',
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
        this.teacher.photos.push(photo);
      }
    }
  }

}

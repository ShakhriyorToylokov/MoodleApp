import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Teacher } from 'src/app/_models/teacher';
import { AccountService } from 'src/app/_services/account.service';
import { TeachersService } from 'src/app/_services/teachers.service';
import {NgxGalleryOptions} from '@kolkov/ngx-gallery';
import {NgxGalleryImage} from '@kolkov/ngx-gallery';
import {NgxGalleryAnimation} from '@kolkov/ngx-gallery';

@Component({
  selector: 'app-teacher-details',
  templateUrl: './teacher-details.component.html',
  styleUrls: ['./teacher-details.component.css']
})
export class TeacherDetailsComponent implements OnInit {
  
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  teacher: Teacher;
  userType: string;
  constructor(private teacherService: TeachersService,private route: ActivatedRoute,
              private accountService: AccountService) { }

  ngOnInit(): void {
    this.loadTeacher();
    this.galleryOptions=[{
      width:'400px',
      height:'400px',
      imagePercent:100,
      thumbnailsColumns: 6,
      imageAnimation: NgxGalleryAnimation.Slide,
      preview: false
    }];
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
  loadTeacher(){
      this.teacherService.getTeacher(this.route.snapshot.paramMap.get('username')).subscribe(response=>{
        this.teacher=response;
        this.galleryImages= this.getImages();

      })
  }

  getImages() : NgxGalleryImage[]{
    const imageUrls=[];
    for(const photo of this.teacher.photos){
      imageUrls.push({
        small: photo?.url,
        medium: photo?.url,
        big: photo?.url,
      })
    }

    return imageUrls;
  }
}

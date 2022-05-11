import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Student } from 'src/app/_models/student';
import { AccountService } from 'src/app/_services/account.service';
import { StudentsService } from 'src/app/_services/students.service';
import {NgxGalleryOptions} from '@kolkov/ngx-gallery';
import {NgxGalleryImage} from '@kolkov/ngx-gallery';
import {NgxGalleryAnimation} from '@kolkov/ngx-gallery';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent implements OnInit {

  student: Student;
  userType: string;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  constructor(private studentService: StudentsService,private route: ActivatedRoute,
              private accountService: AccountService) { }

  ngOnInit(): void {
    this.loadStudent();
    this.galleryOptions=[{
      width:'400px',
      height:'400px',
      imagePercent:100,
      thumbnailsColumns: 4,
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

  loadStudent(){
      this.studentService.getStudent(this.route.snapshot.paramMap.get('username')).subscribe(response=>{
        this.student=response;
        this.galleryImages= this.getImages();
      })
  }

  getImages(): NgxGalleryImage[]{
    const imageUrls=[];
    for(const photo of this.student.photos){
      imageUrls.push({
        small: photo?.url,
        medium: photo?.url,
        big: photo?.url,
      })
    }
    return imageUrls;
  }

  getDefaultPhoto(){
    if(this.student.gender==='female'){
      return './assets/student_female.png'
    }
        return './assets/student.png';
  }
}

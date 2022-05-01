import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Course } from 'src/app/_models/course';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-video-upload',
  templateUrl: './video-upload.component.html',
  styleUrls: ['./video-upload.component.css']
})
export class VideoUploadComponent implements OnInit {

  @ViewChild('editForm') editForm: NgForm;

  @Input() course: Course;
  videoUrl: string;
  videoName: string;
  constructor(private courseService: CoursesService,private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  uploadVideo(){
    var videoParams={courseCode:this.course.courseCode,
                     videoUrl:this.videoUrl,name:this.videoName};
      console.log(videoParams);
      
    //check params in services because it is sending null
    this.courseService.uploadVideo(this.course.courseCode,this.videoUrl,this.videoName).subscribe(response=>{
      console.log(response);
      this.editForm.reset(this.course);
      this.toastr.success("Uploaded Successfully!")
    })
  }
}

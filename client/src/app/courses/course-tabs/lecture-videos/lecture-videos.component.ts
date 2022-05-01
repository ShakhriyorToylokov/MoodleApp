import { Component, Input, OnInit } from '@angular/core';
import { Course, LectureVideos } from 'src/app/_models/course';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-lecture-videos',
  templateUrl: './lecture-videos.component.html',
  styleUrls: ['./lecture-videos.component.css']
})
export class LectureVideosComponent implements OnInit {
  @Input() course:Course;
  @Input() usertype: string;
  constructor(private courseService: CoursesService) { }

  ngOnInit(): void {
    
  }

  deleteVideo(video:LectureVideos){
    this.courseService.deleteVideo(video.id,this.course.courseCode).subscribe(()=>{
      this.course.lectureVideos=this.course.lectureVideos.filter(x=>x.id!==video.id);
    });
  }
}

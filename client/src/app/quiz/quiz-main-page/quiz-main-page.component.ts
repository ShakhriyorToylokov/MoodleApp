import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Course, QuizFiles } from 'src/app/_models/course';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-quiz-main-page',
  templateUrl: './quiz-main-page.component.html',
  styleUrls: ['./quiz-main-page.component.css']
})
export class QuizMainPageComponent implements OnInit {
  quizFiles:QuizFiles
  constructor(private courseService:CoursesService,private route:ActivatedRoute) { }
  
  ngOnInit(): void {
    this.loadCourse();
  }
  loadCourse(){
    this.courseService.getSpecificCourse(this.route.snapshot.paramMap.get('coursecode')).subscribe(
      response=>{
        console.log(response);
        this.quizFiles=response.quizFiles[response.quizFiles.length-1];
        
        console.log(this.quizFiles);
        
      }
    )
  }
}

import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Course } from 'src/app/_models/course';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-quiz-set',
  templateUrl: './quiz-set.component.html',
  styleUrls: ['./quiz-set.component.css']
})
export class QuizSetComponent implements OnInit {
  course: Course;
  time:number;
  definition:string='';
  constructor(private courseService: CoursesService,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadCourse();
  }
  setQuiz(time:number,definition:string){
    
    this.time=time;
    this.definition=definition;
    console.log(this.time,this.definition);
    
  }
  loadCourse(){
    this.courseService.getSpecificCourse(this.route.snapshot.paramMap.get('coursecode')).subscribe(
      response=>{
        this.course=response;
      }
    )
  }
}
